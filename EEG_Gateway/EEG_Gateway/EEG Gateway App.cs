using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emotiv;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Management.Automation;
using System.Threading;
using System.ServiceModel;
using MessagingInterfaces;

namespace EEG_Gateway
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public partial class EEG_Main : Form, IFromClientToServerMessages
    {
        bool cogAction;
        
        public bool isLoad = true;
        public bool updateChartData = false;
        List<Affective> eegAffectiveData = new List<Affective>();
        EdkDll.EE_CognitivAction_t latestAction;
        EmoEngine engine = EmoEngine.Instance;
        ApplicationSettings appSettings = new ApplicationSettings();

        //used to contact simulation
        ServiceHost _serverHost;
        List<Guid> _registeredClients = new List<Guid>();

        public EEG_Main()
        {
            InitializeComponent();
            //liveEEG.Enabled = false;
            
            //Used for application configuration settings, such as enable/disable logging
            //add more here

            //Set the correct directory for loading the user profile data file
            browseForProfileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profiles";
            
            //set configuration settings
            if (File.Exists("ConfigurationSettings.bin"))
                deserializeSettings();
            loggingLbl.Text = appSettings.Logging.ToString();

            //Modifications to GUI after init completed
            eegEmotionChart.ChartAreas[0].AxisY.Maximum = 1;
            setupControls();

            //Make first connection to Emotiv Engine
            engine.Connect();

            //Custom EventHandler that sees when an EmoState or CognitivEvent has occurred
            EmoEngine.Instance.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(Instance_EmoStateUpdated);
            EmoEngine.Instance.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(Instance_CognitivEmoStateUpdated);
            
            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            /*ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:\\Users\\Webby\\Microsoft Robotics Dev Studio 4\\bin\\DssHost32.exe";
            startInfo.Arguments = "-p:50000 -t:50001 -m:Config\\SimpleSimulatedRobot.user.manifest.xml";
            Process.Start(startInfo);*/


        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                //Try to disconnect from the emotiv engine as the app closes
                engine.Disconnect();
                //TODO could backup or log data completed to a csv file
            }
            catch(Exception eX)
            {
                logEEG_Data(eX, "error");
            }
        }

        private void cognitiveActionTimer_Tick(object sender, EventArgs e)
        {
            string val = latestCogTxt.Text;
            if (val != "")
            {
                try
                {
                    int cog = Convert.ToInt16(latestCogTxt.Text);
                    run_cmd(cog);
                }
                catch (Exception eX)
                {
                    //incorrect value
                    logEEG_Data(eX, "error");
                }

                latestCogTxt.Text = "";
                cogAction = true;
            }
            else
            {
                if (cogAction == true)
                    setupControls();
                cogAction = false;
            }               
        }

        private void run_cmd(int cog)
        {
            setupControls();
            switch (cog)
            {
                case 1:
                    ButtonClicked(upBtn, EventArgs.Empty);                    
                    break;
                case 2:
                    ButtonClicked(downBtn, EventArgs.Empty);
                    break;
                case 3:
                    ButtonClicked(leftBtn, EventArgs.Empty);
                    break;
                case 4:
                    ButtonClicked(rightBtn, EventArgs.Empty);
                    break;
            }
        }

        private void setupControls()
        {
            upBtn.BackColor = Color.Empty;
            downBtn.BackColor = Color.Empty;
            leftBtn.BackColor = Color.Empty;
            rightBtn.BackColor = Color.Empty;
        }

        /*private void liveEEG_Tick(object sender, EventArgs e)
        {
            //Reset after EEG reading finished
            textBox1.Text = "";
        }*/

        void ButtonClicked(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            thisButton.BackColor = Color.CornflowerBlue;

            if (latestAction != 0)
            {
                float cogPower;
                if (powerLbl.Text != "Power")//ensure some power value is set
                    cogPower = float.Parse(powerLbl.Text);
                else
                    cogPower = 0;

                logEEG_Data(latestAction, cogPower, "data");
            }
            //use button text as command to send to robot
            string cBtn = thisButton.Text;
            textBox1.Text = cBtn;

            //only do this is simulation is open
            string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\robot.log";
            //RobotCmd(cBtn, logFile);
            //todo REMOVE ROBOTcmD and related stuff

            //ONLY IF SIMULATOR IS RUNNING
            Guid client = new Guid(_registeredClients[0].ToString());
            SendText(client, cBtn);


        }

        void Instance_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            if (isLoad)
            {
                loadUp("_webby.emu",1);
                isLoad = false;
            }

            if (updateChartData == true)
                updateChart(e); 
        }

        private void logEEG_Data(EdkDll.EE_CognitivAction_t currentAction, float power, string file)//overloaded, used for data logs for cognitive actions
        {
            //ensure logging is enabled first
            if (appSettings.Logging == true)
            {
                string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\data.log";
                
                string logData = convertCAtoString(currentAction, power);
                LogData(logData, logFile);
            }
        }

        

        public void logEEG_Data(Affective af, string file)//overloaded, used for data logs for affective info
        {
            //ensure logging is enabled first
            if (appSettings.Logging == true)
            {
                string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\data.log";
                string logData = convertAftoString(af);
                LogData(logData, logFile);
            }
        }
        public void logEEG_Data(Exception eX, string file)//overloaded, used for error logs
        {
            //ensure logging is enabled first
            if (appSettings.Logging == true)
            {
                string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\error.log";
                string logData = eX.ToString();
                LogData(logData, logFile);
            }
        }
        

        public string convertAftoString(Affective af)
        {
            string afString="";
            //use reflection to get all property names and values of object
            Type type = af.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                afString += "Name: " + property.Name + ", Value: " + property.GetValue(af, null) + Environment.NewLine;
            }
            return afString;
        }
        private string convertCAtoString(EdkDll.EE_CognitivAction_t currentAction, float power)
        {
            string cgString = "";
            //use reflection to get all property names and values of object
            cgString = currentAction.ToString() + " - " + power; 
            return cgString;
        }

        public static void LogData(string logData, string logFile)
        {
            if (logFile != "")//ensure a file is being appended
            {
                using (StreamWriter w = File.AppendText(logFile))
                {
                    Log(logData, w);
                }
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            DateTime now = DateTime.Now;
            w.WriteLine("{0} {1} ", now.ToLongTimeString(), now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine(logMessage);
            w.WriteLine("-------------------------------");
        }
        public static void RobotCmd(string cmdData, string logFile)
        {
            if (logFile != "")//ensure a file is being appended
            {
                using (StreamWriter w = File.CreateText(logFile))
                {
                    RobotCmdFile(cmdData, w);
                }
            }
        }
        public static void RobotCmdFile(string cmd, TextWriter w)
        {
            w.WriteLine(cmd);
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        public void updateChart(EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;
            Affective af = new Affective(es);
            
            logEEG_Data(af, "data");

            eegAffectiveData.Add(af);
            
            int totalChartPoints = 8;
            //Only draw a limited amount of data to the chart.
            if (eegEmotionChart.Series["Short Term Excitement"].Points.Count >= totalChartPoints)
            {
                eegEmotionChart.Series["Short Term Excitement"].Points.RemoveAt(0);
                eegEmotionChart.Series["Long Term Excitement"].Points.RemoveAt(0);
                eegEmotionChart.Series["Engagement/Boredom"].Points.RemoveAt(0);
                eegEmotionChart.Series["Frustration"].Points.RemoveAt(0);
                eegEmotionChart.Series["Smile"].Points.RemoveAt(0);
                eegEmotionChart.Series["Valence"].Points.RemoveAt(0);
            }

            try
            {
                //use i as the index for collection of objects (-1 to not go out of bounds)
                int i = eegAffectiveData.Count-1;
                
                double timeVal = Math.Round(Convert.ToDouble(eegAffectiveData[i].Timestamp), 2);
                //EEG Emotion data
                //first time through a data set, set the x axis to the correct time stamp
                //@Trick, using toString() and manually adding the X value (for time)
                //adds the same value to all subsequent series in this chart.
                eegEmotionChart.Series["Short Term Excitement"].Points.AddXY(timeVal.ToString(), eegAffectiveData[i].ShortExcitementLevel);
                eegEmotionChart.Series["Long Term Excitement"].Points.AddY(eegAffectiveData[i].LongExcitementLevel);
                eegEmotionChart.Series["Engagement/Boredom"].Points.AddY(eegAffectiveData[i].EngagementBoredomLevel);
                eegEmotionChart.Series["Frustration"].Points.AddY(eegAffectiveData[i].FrustrationLevel);
                eegEmotionChart.Series["Smile"].Points.AddY(eegAffectiveData[i].SmileLevel);
                eegEmotionChart.Series["Valence"].Points.AddY(eegAffectiveData[i].ValenceLevel);

                //if not the first time loading then update signal img if changed from previous
                if (i != 0)
                {
                    EdkDll.EE_SignalStrength_t signalStrength = eegAffectiveData[i].SignalStrength;
                    if (signalStrength != eegAffectiveData[i - 1].SignalStrength)
                        setSignalImg(signalStrength.ToString());
                }
            }
            catch (Exception eX)
            {
                logEEG_Data(eX, "error");
            }
            updateChartData = false;
        }

        public void setSignalImg(string signalStrength)
        {
            Image img;
            switch (signalStrength)
            {
                case "EXCELLENT_SIGNAL":
                    img = Properties.Resources.signal4;
                    break;
                case "GOOD_SIGNAL":
                    img = Properties.Resources.signal3;
                    break;
                case "FAIR_SIGNAL":
                    img = Properties.Resources.signal2;
                    break;
                case "BAD_SIGNAL":
                    img = Properties.Resources.signal1;
                    break;
                case "NO_SIGNAL":
                    img = Properties.Resources.signal0;
                    break;
                default:
                    img = null;
                    break;
            }
            signalImg.Image = img;
        }

        public void loadUp(string fName, int init)
        {
            Profile profile = new Profile();
            uint userId = 0;

            try
            {
                engine.LoadUserProfile(userId, "Profiles\\" + fName);
                profile = engine.GetUserProfile(userId);
                engine.SetUserProfile(userId, profile);

                //Parse username from file and update label
                if (fName.Contains('_'))
                    fName = fName.Split('_')[1].Split('.')[0];
                else
                    fName = fName.Split('.')[0];
                profileNameLbl.Text = "Profile: " + fName;
                //if not initializing (first time through) then reset all chart data
                if (init == 0)
                {
                    //reset emotive engine
                    engine.Disconnect();
                    engine.Connect();

                    //reset profile data
                    eegAffectiveData.Clear();

                    //clear user data from chart
                    foreach (var series in eegEmotionChart.Series)
                        series.Points.Clear();
                }
            }
            catch (Exception eX)
            {
                logEEG_Data(eX, "error");
            }
        }

        void Instance_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;
            EdkDll.EE_CognitivAction_t currentAction = es.CognitivGetCurrentAction();
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_NEUTRAL)
                latestCogTxt.Text = "0";
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_PUSH)
                latestCogTxt.Text = "1";
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_PULL)
                latestCogTxt.Text = "2";
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_LEFT)
                latestCogTxt.Text = "3";
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_RIGHT)
                latestCogTxt.Text = "4";
            float power = es.CognitivGetCurrentActionPower();
            powerLbl.Text = power.ToString();
            latestAction = currentAction;
        }

        

        private void loadProfBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = browseForProfileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string fName = browseForProfileDialog.SafeFileName;
                try
                {
                    loadUp(fName, 0);
                }
                catch (EmoEngineException eX)
                {
                    engine.Connect();
                    loadUp(fName, 0);
                    //if (eX.Message == "EmoEngine has not been initialized")
                    
                }
                catch (Exception eX){
                    logEEG_Data(eX, "error");
                }
            }
        }

        private void eegTimer_Tick(object sender, EventArgs e)
        {
            engine.ProcessEvents();
        }

        private void emotionTimer_Tick(object sender, EventArgs e)
        {
            //used to update the chart at a consistent speed/time
            updateChartData = true;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            //ensure that correct settings are already loaded before attempting to change them
            if (File.Exists("ConfigurationSettings.bin"))
                deserializeSettings();

            //invert the logging value from appSettings class
            switchLoggingSettings();

            //serialize the settings to be remembered
            serializeSettings(appSettings);

            //Update the relevant GUI label with latest status
            loggingLbl.Text = appSettings.Logging.ToString();
        }

        public void switchLoggingSettings()
        {
            appSettings.Logging = !appSettings.Logging;
        }


        public void serializeSettings(ApplicationSettings appSettings)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("ConfigurationSettings.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, appSettings);
                stream.Close();
            }
            catch(Exception eX)
            {
                logEEG_Data(eX, "error");
                MessageBox.Show("Unable to serialize settings:"+ eX);
            }
            
        }
        public void deserializeSettings()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("ConfigurationSettings.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                appSettings = (ApplicationSettings)formatter.Deserialize(stream);
                stream.Close();
            }
            catch(Exception eX)
            {
                logEEG_Data(eX, "error");
                MessageBox.Show("Unable to deserialize settings:"+eX);
            }
        }

        private void newProfileBtn_Click(object sender, EventArgs e)
        {
            CognitiveTraining cognitiveTraining = new CognitiveTraining();
            
            cognitiveTraining.Initialize();
        }

        /*cognitiveTraining += new FormClosedEventHandler(CognitiveTraining_FormClosed);
        private void CognitiveTraining_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("CLOSED");
        }*/

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Do something
        }

        private void btnRunSimulator_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                //listen for simulation localhost
                //setup WCF details
                _serverHost = new ServiceHost(this);
                _serverHost.AddServiceEndpoint((typeof(IFromClientToServerMessages)), new NetNamedPipeBinding(), "net.pipe://localhost/Server");
               
                try
                {
                    _serverHost.Open();
                    MessageBox.Show("SERVER STATE: " + _serverHost.State.ToString());
                }
                catch (Exception eX)
                {
                    MessageBox.Show(eX.ToString());
                }

            }).Start();

            //execute Simulation program, just run PS with parameters for correct manifest (simulation info)
            //use new thread, improved performance and "async"
            new Thread(() =>
            {
                //Set as background thread
                //Taken from MSDN
                //Background threads are identical to foreground threads, except that background threads do not prevent a process from terminating
                Thread.CurrentThread.IsBackground = true;
                PowerShell ps = PowerShell.Create();
                Console.WriteLine("Running Simulator");
                ps.AddScript(@"& 'C:\Users\Webby\Microsoft Robotics Dev Studio 4\bin\DssHost32.exe' -port:50000 -tcpport:50001 -manifest:'C:\Users\Webby\Microsoft Robotics Dev Studio 4\samples\Config\LEGO.NXT.Tribot.Simulation.user.manifest.xml' -manifest:'C:\Users\Webby\Microsoft Robotics Dev Studio 4\samples\Config\SimpleDashboard.user.manifest.xml'");
                ps.Invoke();
            }).Start();
            
            
        }

        public void Register(Guid clientID)
        {
            if (!_registeredClients.Contains(clientID))
                _registeredClients.Add(clientID);
            MessageBox.Show(clientID.ToString());
        }

        public void DisplayTextOnServer(string text)
        {
            throw new NotImplementedException();
        }

        public void DisplayTextOnServerAsFromThisClient(Guid clientID, string text)
        {
            throw new NotImplementedException();
        }

        public string GetLastAnonMessage()
        {
            throw new NotImplementedException();
        }
        private void SendText(Guid client, string text)
        {
            using (ChannelFactory<IFromServerToClientMessages> factory = new ChannelFactory<IFromServerToClientMessages>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/Client_" + client.ToString())))
            {
                IFromServerToClientMessages serverToClientChannel = factory.CreateChannel();
                try
                {
                    serverToClientChannel.DisplayTextInClient(text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    CloseChannel((ICommunicationObject)serverToClientChannel);
                }
            }
        }
        private void CloseChannel(ICommunicationObject channel)
        {
            try
            {
                channel.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                channel.Abort();
            }
        }
    }
}
