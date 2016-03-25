using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EEG_Gateway;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using EEG_Gateway_UnitTests;
using System.ServiceModel;
using MessagingInterfaces;
using System.Windows.Forms.DataVisualization.Charting;

namespace EEG_Gateway_UnitTests
{
    [TestClass]
    public class MainTests
    {
        EEG_Main form;
        public static int testCount = 0;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            form = new EEG_Gateway.EEG_Main();
        }

        [TestMethod]
        public void StartGUI()
        {
            
            //Thread.CurrentThread.IsBackground = true;
            //Application.DoEvents();
            //var form = new EEG_Gateway.EEG_Main();
            form.Load += (sender, e) => (sender as EEG_Gateway.EEG_Main).Visible = true;
            form.Show();
            form.MinimizeBox = false;
            Assert.IsTrue(form != null);
            incTestCount();
            MessageBox.Show("Tests started!");
            form.Focus();
        }

        [TestMethod]
        public void UI_Updates()
        {
            Random r = new Random();
            for (int i = 0; i < 30; i++)
            {
                int x = r.Next(1, 5);
                moveRobot(2);
                isUIMoveBtnSet(2);
            }
        }

        [TestMethod]
        public void graphUpdates()
        {
            //
            new Thread(() =>
            {
                Thread.Sleep(2000);
                int series = form.eegEmotionChart.Series.Count-1;
                //MessageBox.Show(form.eegEmotionChart.Series["Engagement/Boredom"].Points[0].ToString());
                for (int l = 0; l < series; l++)
                {
                    Assert.IsTrue(form.eegEmotionChart.Series[l].Points[0] != null);
                    incTestCount();                    
                }
            }).Start();

        }

        [TestMethod]
        public void ConnectToPhysicalRobot()
        {
            form.connectToRobot();
            Assert.IsTrue(form.serialPortArduino.IsOpen);
            Assert.IsTrue(form.serialPortArduino.BaudRate == 9600);
            Assert.IsTrue(form.serialPortArduino.PortName == "COM5");
            incTestCount();
            incTestCount();
            incTestCount();

            new Thread(() =>
            {
                Random r = new Random();
                for (int i = 0; i < 6; i++)
                {
                    form.Focus();
                    int x = r.Next(1, 5);
                    moveRobot(x);
                    //also test colours blue here
                    Assert.IsTrue(x > 0 && x < 5);
                    incTestCount();
                    Thread.Sleep(1200);
                }
                //MessageBox.Show("Completed robot tests!");
                
            }).Start();
            //MessageBox.Show("Running robot tests");
        }

        [TestMethod]
        public void ConnectToRobotSim()
        {
            form.Focus();
            form.runSim();

            Assert.IsTrue(form.simRunning == true);
            incTestCount();
            new Thread(() =>
            {
                //only try a set amount of times or will loop forever
                int l = 0;
                while (form._registeredClients.Count == 0)
                {
                    Thread.Sleep(2000);
                    l++;
                    if (l > 5)
                    {
                        //do assert failed if hit limit
                        Assert.IsTrue(form._registeredClients.Count > 0);
                    }                    
                }
                Assert.IsTrue(form._registeredClients.Count > 0);
                incTestCount();

                Random r = new Random();
                form.Focus();
                for (int i = 0; i < 10; i++)
                {                    
                    int x = r.Next(1, 5);
                    moveRobot(x);
                    //also test colours blue here
                    Assert.IsTrue(x > 0 && x < 5);
                    incTestCount();
                    Thread.Sleep(1500);
                }                
                MessageBox.Show("Completed robot sim tests!");
                form.Focus();
                MessageBox.Show(testCount + ": Tests passed");
                
            }).Start();
            MessageBox.Show("Running robot movement tests ");
        }

        private void moveRobot(int dir)
        {
            form.latestCogTxt.Text = dir.ToString();
        }

        private void isUIMoveBtnSet(int dir)
        {    
            Button btn = getUIMoveBtns(dir);
            Assert.IsTrue(btn.BackColor == Color.CornflowerBlue);
            incTestCount();
        }

        private Button getUIMoveBtns(int dir)
        {
            switch (dir)
            {
                case 1:
                    return form.upBtn;
                case 2:
                    return form.downBtn;
                case 3:
                    return form.leftBtn;
                case 4:
                    return form.rightBtn;
            }
            return null;
            
        }

        private void updateUI(int time)
        {
            form.Refresh();
            Thread.Sleep(time);
        }

        private void incTestCount()
        {
            testCount++;            
        }
    }
           
}
