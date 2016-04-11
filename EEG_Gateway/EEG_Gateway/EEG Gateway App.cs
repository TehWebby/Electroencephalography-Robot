//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

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
    /// <summary>
    /// EEG_Main Gateway Application
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public partial class EEG_Main : Form, IFromClientToServerMessages
    {        
        public bool isLoad = true; /// Is user profile loaded
        public bool updateChartData = false; /// Used to monitor updates of Chart Data
        public List<Affective> eegAffectiveData = new List<Affective>(); /// List of Affective data
        public EdkDll.EE_CognitivAction_t latestAction; /// Latest cognitive action interpreted
        public EmoEngine engine = EmoEngine.Instance; /// EmoEngine instance
        public ApplicationSettings appSettings = new ApplicationSettings(); /// Settings the application should use
        
        //Required for simulator
        public ServiceHost _serverHost; /// used to contact simulation
        public List<Guid> _registeredClients = new List<Guid>(); /// Lists the registered users GUID
        public bool simRunning = false; /// Is the simulator active
        public static bool[] allowedActions = new bool[5];

        /// <summary>
        /// EEG Main Constructor
        /// </summary>
        public EEG_Main()
        {
            InitializeComponent();
            //Setup which controls (directions) are enabled
            setupAllowedActions();
            
            

            //Set the correct directory for loading the user profile data file
            browseForProfileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profiles";
            
            //set configuration settings
            if (File.Exists("ConfigurationSettings.bin"))
                deserializeSettings();
            lblLogging.Text = appSettings.Logging.ToString();
            
            setButtonSettings(appSettings.Logging);
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

            //listen for simulation localhost
            //setup WCF details
            _serverHost = new ServiceHost(this);

            serialPortArduino.PortName = "COM5";
            serialPortArduino.BaudRate = 9600;

        }

        private void setButtonSettings(bool logging)
        {
            if (logging)
                btnSettings.Text = "Disable";
            else
                btnSettings.Text = "Enable";
        }

        private void setupAllowedActions()
        {
            for (int i=1;i<5;i++)
                allowedActions[i] = true;
        }

        /// <summary>
        /// Handles application closes
        /// </summary>
        public void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                //Try to disconnect from the emotiv engine as the app closes
                engine.Disconnect();
                
            }
            catch(Exception eX)
            {
                logEEG_Data(eX, "error");
            }
        }

        /// <summary>
        /// Emotion state updated
        /// </summary>
        public void Instance_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            if (isLoad)
            {
                loadUp("_webby.emu",1);
                isLoad = false;
            }

            if (updateChartData == true)
                updateChart(e); 
        }

        /// <summary>
        /// Log EEG Data
        /// </summary>
        public void logEEG_Data(EdkDll.EE_CognitivAction_t currentAction, float power, string file)//overloaded, used for data logs for cognitive actions
        {
            //ensure logging is enabled first
            if (appSettings.Logging == true)
            {
                string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\data.log";
                
                string logData = convertCAtoString(currentAction, power);
                LogData(logData, logFile);
            }
        }
        
        /// <summary>
        /// Log EEG Data
        /// </summary>
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

        /// <summary>
        /// Log EEG Data
        /// </summary>
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

        /// <summary>
        /// Affectiv to String
        /// </summary>
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

        /// <summary>
        /// Cognitiv to String
        /// </summary>
        public string convertCAtoString(EdkDll.EE_CognitivAction_t currentAction, float power)
        {
            string cgString = "";
            //use reflection to get all property names and values of object
            cgString = currentAction.ToString() + " - " + power; 
            return cgString;
        }

        /// <summary>
        /// Log Data
        /// </summary>
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

        /// <summary>
        /// Logging
        /// </summary>
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            DateTime now = DateTime.Now;
            w.WriteLine("{0} {1} ", now.ToLongTimeString(), now.ToLongDateString());            
            w.WriteLine(logMessage);
            w.WriteLine("-------------------------------");
        }

        /// <summary>
        /// Robot command log
        /// </summary>
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

        /// <summary>
        /// Robot command write log
        /// </summary>
        public static void RobotCmdFile(string cmd, TextWriter w)
        {
            w.WriteLine(cmd);
        }

        /// <summary>
        /// Dump log
        /// </summary>
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Update Chart
        /// </summary>
        public void updateChart(EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState; /// update EmoState on chart
            Affective af = new Affective(es); /// new Affective from EmoState
            
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

        /// <summary>
        /// Sets the Signal Image
        /// </summary>
        public void setSignalImg(string signalStrength)
        {
            Image img; /// Image for signal picture
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

        /// <summary>
        /// Load a profile
        /// </summary>
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

        /// <summary>
        /// Cogntitv action updated
        /// </summary>
        public void Instance_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;
            EdkDll.EE_CognitivAction_t currentAction = es.CognitivGetCurrentAction();
            //if (currentAction == EdkDll.EE_CognitivAction_t.COG_NEUTRAL)
                //latestCogTxt.Text = "0";
            if (currentAction == EdkDll.EE_CognitivAction_t.COG_PUSH)
                latestCogTxt.Text = "1";
            else if (currentAction == EdkDll.EE_CognitivAction_t.COG_PULL)
                latestCogTxt.Text = "2";
            else if (currentAction == EdkDll.EE_CognitivAction_t.COG_LEFT)
                latestCogTxt.Text = "3";
            else if (currentAction == EdkDll.EE_CognitivAction_t.COG_RIGHT)
                latestCogTxt.Text = "4";
            float power = es.CognitivGetCurrentActionPower();
            lblPower.Text = power.ToString();
            latestAction = currentAction;
        }
        
        /// <summary>
        /// Load profle button event
        /// </summary>
        public void loadProfBtn_Click(object sender, EventArgs e)
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

        /// <summary>
        /// EEG Timer
        /// </summary>
        public void eegTimer_Tick(object sender, EventArgs e)
        {
            engine.ProcessEvents();
            simRunning = true;
        }

        /// <summary>
        /// Emotion timer
        /// </summary>
        public void emotionTimer_Tick(object sender, EventArgs e)
        {
            //used to update the chart at a consistent speed/time
            updateChartData = true;
            if (this.ContainsFocus)
                latestCogTxt.Focus();
        }

        /// <summary>
        /// Settings button event click
        /// </summary>
        public void settingsBtn_Click(object sender, EventArgs e)
        {
            //ensure that correct settings are already loaded before attempting to change them
            if (File.Exists("ConfigurationSettings.bin"))
                deserializeSettings();

            //invert the logging value from appSettings class
            switchLoggingSettings();

            //serialize the settings to be remembered
            serializeSettings(appSettings);

            //Update the relevant GUI label with latest status
            lblLogging.Text = appSettings.Logging.ToString();
            setButtonSettings(appSettings.Logging);
        }

        /// <summary>
        /// Turns on/off logging
        /// </summary>
        public void switchLoggingSettings()
        {
            appSettings.Logging = !appSettings.Logging;
        }

        /// <summary>
        /// Serialize application settings for persistence
        /// </summary>
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

        /// <summary>
        /// Deserialize application settings for persistence
        /// </summary>
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

        /// <summary>
        /// New profile button event click
        /// </summary>
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
            runSim();
        }

        /// <summary>
        /// Starts the robot simulator
        /// </summary>
        public void runSim()
        {
            new Task(() =>
            {
                //listen for simulation localhost
                //setup WCF details
                _serverHost = new ServiceHost(this);
                _serverHost.AddServiceEndpoint((typeof(IFromClientToServerMessages)), new NetNamedPipeBinding(), "net.pipe://localhost/Server");

                try
                {
                    _serverHost.Open();
                    //MessageBox.Show("SERVER STATE: " + _serverHost.State.ToString());
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

            simRunning = true;
        }

        /// <summary>
        /// Registers client WCF
        /// </summary>
        public void Register(Guid clientID)
        {
            if (!_registeredClients.Contains(clientID))
                _registeredClients.Add(clientID);
            //MessageBox.Show(clientID.ToString());
        }

        /// <summary>
        /// Displays Text on WCF Server
        /// </summary>
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

        /// <summary>
        /// Sends Command to client WCF
        /// </summary>
        public void SendText(Guid client, string text)
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
                    //MessageBox.Show(ex.ToString());
                    disconnectFromSim();
                }
                finally
                {
                    CloseChannel((ICommunicationObject)serverToClientChannel);
                }
            }
        }

        /// <summary>
        /// Closes WCF channel
        /// </summary>
        public void CloseChannel(ICommunicationObject channel)
        {
            try
            {
                channel.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                channel.Abort();
            }
        }

        private void btnRobot_Click(object sender, EventArgs e)
        {
            connectToRobot();
        }

        /// <summary>
        /// Connect to real robot
        /// </summary>
        public void connectToRobot()
        {
            if (serialPortArduino.IsOpen)
            {
                serialPortArduino.Close();
            }
            else
            {
                try
                {
                    serialPortArduino.Open();
                }
                catch (IOException eX)
                {
                    MessageBox.Show(eX.ToString());
                }
                catch (UnauthorizedAccessException eX)
                {
                    MessageBox.Show(eX.ToString());
                }

            }

            //check status before updating UI
            if (serialPortArduino.IsOpen)
            {
                btnRobot.BackColor = Color.White;
                btnRobot.Text = "Disconnect";
                lblRobotStatusData.Text = "Connected";
                lblRobotStatusData.ForeColor = Color.Lime;
            }
            else
            {
                btnRobot.BackColor = SystemColors.ButtonFace;
                btnRobot.Text = "Connect to Robot";
                lblRobotStatusData.Text = "Disconnected";
                lblRobotStatusData.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// On command execute
        /// </summary>
        public void run_cmd(int cog)
        {
            cog = invertCheck(cog);      
            switch (cog)
            {
                case 1:
                    ButtonClicked(upBtn, EventArgs.Empty, cog);
                    break;
                case 2:
                    ButtonClicked(downBtn, EventArgs.Empty, cog);
                    break;
                case 3:
                    ButtonClicked(leftBtn, EventArgs.Empty, cog);
                    break;
                case 4:
                    ButtonClicked(rightBtn, EventArgs.Empty, cog);
                    break;
            }
        }

        private int invertCheck(int cog)
        {
            if (chkBoxInvert.Checked)
            {
                if (cog == 1)
                    cog = 3;
                else if (cog == 2)
                    cog = 4;
                else if (cog == 3)
                    cog = 1;
                else if (cog == 4)
                    cog = 2;
            }
            return cog;
        }

        /// <summary>
        /// Setup UI controls
        /// </summary>
        public void setupControls()
        {  
            upBtn.BackColor = Color.Empty;
            downBtn.BackColor = Color.Empty;
            leftBtn.BackColor = Color.Empty;
            rightBtn.BackColor = Color.Empty;
        }

        /// <summary>
        /// Execute button/Command sent
        /// </summary>
        public void ButtonClicked(object sender, EventArgs e, int cog)
        {            
            Button thisButton = (Button)sender;
            thisButton.BackColor = Color.CornflowerBlue;
            
            if (latestAction != 0)
            {
                float cogPower;
                if (lblPower.Text != "Power")//ensure some power value is set
                    cogPower = float.Parse(lblPower.Text);
                else
                    cogPower = 0;

                logEEG_Data(latestAction, cogPower, "data");
            }

            //use button text as command to send to robot
            string cBtn = thisButton.Text;
            textBox1.Text = cBtn;

            //string simState = _serverHost.State.ToString();
            if (simRunning)
            {
                new Task(() =>
                {
                    //Thread.CurrentThread.IsBackground = true;
                    //only do this is simulation is open
                    string logFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logging\\robot.log";
                    //RobotCmd(cBtn, logFile);

                    //ONLY IF SIMULATOR IS RUNNING 
                    //SendText handles cancelling the sim disconnect if it was somehow left open
                    if (_registeredClients.Count > 0)
                    {
                        Guid client = new Guid(_registeredClients[0].ToString());
                        SendText(client, cBtn);
                        simRunning = false;
                    }
                    
                }).Start();
            }

            //Only if robot is connected
            if (serialPortArduino.IsOpen)
            {
                new Task(() =>
                {
                    //Thread.CurrentThread.IsBackground = true;
                    Console.WriteLine("Connected!");
                    // If the port is Open, declare a char[] array with one element.
                    char[] buff = new char[1];
                    // Load element 0 with the key character.
                    Console.WriteLine(cog);
                    buff[0] = Convert.ToChar(cog.ToString());
                    try
                    {
                        //// Send the one character buffer. As .Write requires char[]
                        serialPortArduino.Write(buff, 0, 1);
                        //// Set the KeyPress event as handled so the character won't
                        //// display locally. If you want it to display, omit the next line.
                        //e.Handled = true;
                    }
                    catch(Exception eX)
                    {
                        Console.WriteLine(eX);
                    }



                }).Start();
            }
            //Thread.Sleep(2000);
            //thisButton.BackColor
            //setupControls();
        }

        private void latestCogTxt_TextChanged(object sender, EventArgs e)
        {
            
            if (isCmdValid())
            {
                setupControls();
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
                //setupControls();
            }
            else
            {
                Thread.Sleep(100);
                latestCogTxt.Text = "";
            }
                

        }

        /// <summary>
        /// Is command valid
        /// </summary>
        public bool isCmdValid()
        {
            string cmd = latestCogTxt.Text;
            if (cmd == "1" || cmd == "2" || cmd == "3" || cmd == "4")
            {
                if (allowedActions[Convert.ToInt16(cmd)] == true)
                    return true;

            }  
            return false;
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(_registeredClients.Count);
            Console.WriteLine(_serverHost.State);
        }

        private void btnExitSim_Click(object sender, EventArgs e)
        {
            disconnectFromSim();
        }

        /// <summary>
        /// Displays from robot simulator
        /// </summary>
        public void disconnectFromSim()
        {
            _serverHost.Close();
            if (_registeredClients.Count > 0)
                _registeredClients.RemoveAt(0);
            simRunning = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
