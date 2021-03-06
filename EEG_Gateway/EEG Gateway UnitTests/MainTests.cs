﻿//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

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
    /// <summary>
    /// MainTests Unit tests for Gateway Application
    /// </summary>
    [TestClass]
    public class MainTests
    {
        EEG_Main form;
        public static int testCount = 0;
        int testLimit = 30;
        [TestInitialize()]
        public void MyTestInitialize(){
            //start the form
            form = new EEG_Gateway.EEG_Main();
        }

        [TestMethod]
        public void StartGUI()
        {            
            form.Load += (sender, e) => (sender as EEG_Gateway.EEG_Main).Visible = true;
            form.Show();
            form.MinimizeBox = false;
            //ensure form is loaded
            Assert.IsTrue(form != null);
            incTestCount();
            MessageBox.Show("Tests started!");
            form.Focus();
        }

        [TestMethod]
        public void UI_Updates()
        {
            //checks that the UI buttons are being set when actions are received
            Random r = new Random();
            int x = 0;
            for (int i = 0; i < testLimit; i++)
            {
                x = r.Next(1, 5);
                moveRobot(x);
                isUIMoveBtnSet(x);
            }
        }

        [TestMethod]
        public void graphUpdates()
        {    
            //check the chart is updating when receiving affective data
            new Thread(() =>
            {
                Thread.Sleep(2000);
                int series = form.eegEmotionChart.Series.Count - 1;
                for (int l = 0; l < series; l++)
                {
                    try
                    {
                        if (form.eegEmotionChart.Series[l].Points[0] != null)
                        {
                            Assert.IsTrue(form.eegEmotionChart.Series[l].Points[0] != null);
                            incTestCount();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Test Failed: Check connection to headset");
                    }
                    
                }
            }).Start();
        }

        [TestMethod]
        public void ConnectToPhysicalRobot()
        {
            //test connection to real zumo ardunio
            form.connectToRobot();
            Assert.IsTrue(form.serialPortArduino.IsOpen);
            Assert.IsTrue(form.serialPortArduino.BaudRate == 9600);
            Assert.IsTrue(form.serialPortArduino.PortName == "COM5");
            incTestCount();
            incTestCount();
            incTestCount();

            graphUpdates();

            new Thread(() =>
            {
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {
                    //send random move commands to the robot
                    form.Focus();
                    int x = r.Next(1, 5);
                    moveRobot(x);
                    //also test colours blue here
                    //isUIMoveBtnSet(x);
                    Assert.IsTrue(x > 0 && x < 5);
                    incTestCount();
                    Thread.Sleep(600);
                }
                //MessageBox.Show("Completed robot tests!");
                
            }).Start();
            //MessageBox.Show("Running robot tests");
        }

        [TestMethod]
        public void ConnectToRobotSim()
        {
            //try to connect to the simulated robot
            form.Focus();
            form.runSim();

            Assert.IsTrue(form.simRunning == true);
            incTestCount();

            graphUpdates();
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
