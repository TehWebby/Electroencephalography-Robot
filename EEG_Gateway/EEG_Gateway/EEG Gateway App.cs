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

namespace EEG_Gateway
{
    public partial class EEG_Main : Form
    {
        bool cogAction;
        
        public bool isLoad = true;
        public bool updateChartData = false;
        List<Affective> eegAffectiveData = new List<Affective>();

        EmoEngine engine = EmoEngine.Instance;
        ApplicationSettings appSettings = new ApplicationSettings();

        public EEG_Main()
        {
            InitializeComponent();
            //liveEEG.Enabled = false;

            //Used for application configuration settings, such as enable/disable logging
            //add more here

            //Set the correct directory for loading the user profile data file
            browseForProfileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profiles";
            
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
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                //Try to disconnect from the emotiv engine as the app closes
                engine.Disconnect();
                //TODO could backup or log data completed to a csv file
            }
            catch
            {

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
            //use button text as command to send to robot
            string cBtn = thisButton.Text;
            textBox1.Text = cBtn;

            // do stuff
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

        public void updateChart(EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;
            Affective af = new Affective(es);
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
                
                double timeVal = Math.Round(Convert.ToDouble(eegAffectiveData[i].getTimestamp()), 2);
                //EEG Emotion data
                //first time through a data set, set the x axis to the correct time stamp
                //@Trick, using toString() and manually adding the X value (for time)
                //adds the same value to all subsequent series in this chart.
                eegEmotionChart.Series["Short Term Excitement"].Points.AddXY(timeVal.ToString(), eegAffectiveData[i].getShortExcitLvl());
                eegEmotionChart.Series["Long Term Excitement"].Points.AddY(eegAffectiveData[i].getLongExcitLvl());
                eegEmotionChart.Series["Engagement/Boredom"].Points.AddY(eegAffectiveData[i].getEngagementBoredomLvl());
                eegEmotionChart.Series["Frustration"].Points.AddY(eegAffectiveData[i].getFrustLvl());
                eegEmotionChart.Series["Smile"].Points.AddY(eegAffectiveData[i].getSmileLvl());
                eegEmotionChart.Series["Valence"].Points.AddY(eegAffectiveData[i].getValenceLvl());

                //if not the first time loading then update signal img if changed from previous
                if (i != 0)
                {
                    EdkDll.EE_SignalStrength_t signalStrength = eegAffectiveData[i].getSignalStrength();
                    if (signalStrength != eegAffectiveData[i - 1].getSignalStrength())
                        setSignalImg(signalStrength.ToString());
                }
            }
            catch
            {

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
            //MessageBox.Show("Profile " + fName + " loaded");
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
            
        }

        private void loadProfBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = browseForProfileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string fName = browseForProfileDialog.SafeFileName;
                loadUp(fName, 0);
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
            if (File.Exists("ConfigurationSettings.bin"))
                deserializeSettings();
            
            appSettings.Logging += 1;
            serializeSettings(appSettings);
            MessageBox.Show(appSettings.Logging.ToString());
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
            catch
            {
                MessageBox.Show("Unable to serialize settings");
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
            catch
            {
                MessageBox.Show("Unable to deserialize settings");
            }
            
        }

    }
}
