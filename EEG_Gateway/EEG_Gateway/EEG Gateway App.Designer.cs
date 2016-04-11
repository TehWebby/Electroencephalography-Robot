namespace EEG_Gateway
{
    partial class EEG_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EEG_Main));
            this.latestCogTxt = new System.Windows.Forms.TextBox();
            this.upBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.eegCogLbl = new System.Windows.Forms.Label();
            this.eegEmotionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.eegTimelbl2 = new System.Windows.Forms.Label();
            this.eegStrlbl2 = new System.Windows.Forms.Label();
            this.btnLoadProf = new System.Windows.Forms.Button();
            this.eegTimer = new System.Windows.Forms.Timer(this.components);
            this.emotionTimer = new System.Windows.Forms.Timer(this.components);
            this.signalImg = new System.Windows.Forms.PictureBox();
            this.browseForProfileDialog = new System.Windows.Forms.OpenFileDialog();
            this.profileNameLbl = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.loggingLbl = new System.Windows.Forms.Label();
            this.loggingEnabledLbl = new System.Windows.Forms.Label();
            this.powerLbl = new System.Windows.Forms.Label();
            this.btnNewProfile = new System.Windows.Forms.Button();
            this.btnRunSimulator = new System.Windows.Forms.Button();
            this.btnRobot = new System.Windows.Forms.Button();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.lblRobotStatus = new System.Windows.Forms.Label();
            this.lblRobotStatusData = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnExitSim = new System.Windows.Forms.Button();
            this.lblSignal = new System.Windows.Forms.Label();
            this.chkBoxInvert = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCmdWindow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eegEmotionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // latestCogTxt
            // 
            this.latestCogTxt.BackColor = System.Drawing.Color.Black;
            this.latestCogTxt.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestCogTxt.ForeColor = System.Drawing.Color.White;
            this.latestCogTxt.Location = new System.Drawing.Point(77, 31);
            this.latestCogTxt.MaxLength = 1;
            this.latestCogTxt.Name = "latestCogTxt";
            this.latestCogTxt.Size = new System.Drawing.Size(28, 23);
            this.latestCogTxt.TabIndex = 0;
            this.latestCogTxt.TextChanged += new System.EventHandler(this.latestCogTxt_TextChanged);
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(751, 99);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(76, 44);
            this.upBtn.TabIndex = 1;
            this.upBtn.Text = "UP";
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Location = new System.Drawing.Point(751, 183);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(76, 44);
            this.downBtn.TabIndex = 2;
            this.downBtn.Text = "DOWN";
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Location = new System.Drawing.Point(657, 140);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(76, 44);
            this.leftBtn.TabIndex = 3;
            this.leftBtn.Text = "LEFT";
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Location = new System.Drawing.Point(848, 140);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(76, 44);
            this.rightBtn.TabIndex = 4;
            this.rightBtn.Text = "RIGHT";
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 23);
            this.textBox1.TabIndex = 5;
            // 
            // eegCogLbl
            // 
            this.eegCogLbl.AutoSize = true;
            this.eegCogLbl.Location = new System.Drawing.Point(673, 76);
            this.eegCogLbl.Name = "eegCogLbl";
            this.eegCogLbl.Size = new System.Drawing.Size(215, 17);
            this.eegCogLbl.TabIndex = 6;
            this.eegCogLbl.Text = "EEG Interpreted Cognitive Action";
            // 
            // eegEmotionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.eegEmotionChart.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 8;
            legend1.Name = "Legend1";
            this.eegEmotionChart.Legends.Add(legend1);
            this.eegEmotionChart.Location = new System.Drawing.Point(80, 35);
            this.eegEmotionChart.Name = "eegEmotionChart";
            this.eegEmotionChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Short Term Excitement";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Sienna;
            series2.Legend = "Legend1";
            series2.Name = "Long Term Excitement";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "Engagement/Boredom";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series4.Legend = "Legend1";
            series4.Name = "Smile";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.LightSkyBlue;
            series5.Legend = "Legend1";
            series5.Name = "Valence";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series6.Legend = "Legend1";
            series6.Name = "Frustration";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.CornflowerBlue;
            series7.Legend = "Legend1";
            series7.Name = "Meditation";
            this.eegEmotionChart.Series.Add(series1);
            this.eegEmotionChart.Series.Add(series2);
            this.eegEmotionChart.Series.Add(series3);
            this.eegEmotionChart.Series.Add(series4);
            this.eegEmotionChart.Series.Add(series5);
            this.eegEmotionChart.Series.Add(series6);
            this.eegEmotionChart.Series.Add(series7);
            this.eegEmotionChart.Size = new System.Drawing.Size(571, 202);
            this.eegEmotionChart.TabIndex = 8;
            this.eegEmotionChart.Text = "chart1";
            // 
            // eegTimelbl2
            // 
            this.eegTimelbl2.AutoSize = true;
            this.eegTimelbl2.Location = new System.Drawing.Point(253, 231);
            this.eegTimelbl2.Name = "eegTimelbl2";
            this.eegTimelbl2.Size = new System.Drawing.Size(39, 17);
            this.eegTimelbl2.TabIndex = 10;
            this.eegTimelbl2.Text = "Time";
            // 
            // eegStrlbl2
            // 
            this.eegStrlbl2.AutoSize = true;
            this.eegStrlbl2.Location = new System.Drawing.Point(12, 103);
            this.eegStrlbl2.Name = "eegStrlbl2";
            this.eegStrlbl2.Size = new System.Drawing.Size(62, 17);
            this.eegStrlbl2.TabIndex = 12;
            this.eegStrlbl2.Text = "Strength";
            // 
            // btnLoadProf
            // 
            this.btnLoadProf.Location = new System.Drawing.Point(848, 532);
            this.btnLoadProf.Name = "btnLoadProf";
            this.btnLoadProf.Size = new System.Drawing.Size(114, 26);
            this.btnLoadProf.TabIndex = 13;
            this.btnLoadProf.Text = "Load Profile";
            this.btnLoadProf.UseVisualStyleBackColor = true;
            this.btnLoadProf.Click += new System.EventHandler(this.loadProfBtn_Click);
            // 
            // eegTimer
            // 
            this.eegTimer.Enabled = true;
            this.eegTimer.Interval = 1000;
            this.eegTimer.Tick += new System.EventHandler(this.eegTimer_Tick);
            // 
            // emotionTimer
            // 
            this.emotionTimer.Enabled = true;
            this.emotionTimer.Interval = 1000;
            this.emotionTimer.Tick += new System.EventHandler(this.emotionTimer_Tick);
            // 
            // signalImg
            // 
            this.signalImg.Image = global::EEG_Gateway.Properties.Resources.signal0;
            this.signalImg.Location = new System.Drawing.Point(866, 3);
            this.signalImg.Name = "signalImg";
            this.signalImg.Size = new System.Drawing.Size(100, 58);
            this.signalImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signalImg.TabIndex = 14;
            this.signalImg.TabStop = false;
            // 
            // profileNameLbl
            // 
            this.profileNameLbl.AutoSize = true;
            this.profileNameLbl.Location = new System.Drawing.Point(1, 3);
            this.profileNameLbl.Name = "profileNameLbl";
            this.profileNameLbl.Size = new System.Drawing.Size(91, 17);
            this.profileNameLbl.TabIndex = 15;
            this.profileNameLbl.Text = "Profile: name";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(782, 400);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(88, 30);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // loggingLbl
            // 
            this.loggingLbl.AutoSize = true;
            this.loggingLbl.Location = new System.Drawing.Point(858, 371);
            this.loggingLbl.Name = "loggingLbl";
            this.loggingLbl.Size = new System.Drawing.Size(38, 17);
            this.loggingLbl.TabIndex = 17;
            this.loggingLbl.Text = "True";
            // 
            // loggingEnabledLbl
            // 
            this.loggingEnabledLbl.AutoSize = true;
            this.loggingEnabledLbl.Location = new System.Drawing.Point(734, 371);
            this.loggingEnabledLbl.Name = "loggingEnabledLbl";
            this.loggingEnabledLbl.Size = new System.Drawing.Size(118, 17);
            this.loggingEnabledLbl.TabIndex = 18;
            this.loggingEnabledLbl.Text = "Logging enabled:";
            // 
            // powerLbl
            // 
            this.powerLbl.AutoSize = true;
            this.powerLbl.Location = new System.Drawing.Point(111, 31);
            this.powerLbl.Name = "powerLbl";
            this.powerLbl.Size = new System.Drawing.Size(47, 17);
            this.powerLbl.TabIndex = 19;
            this.powerLbl.Text = "Power";
            // 
            // btnNewProfile
            // 
            this.btnNewProfile.Location = new System.Drawing.Point(848, 493);
            this.btnNewProfile.Name = "btnNewProfile";
            this.btnNewProfile.Size = new System.Drawing.Size(114, 28);
            this.btnNewProfile.TabIndex = 20;
            this.btnNewProfile.Text = "New Profile";
            this.btnNewProfile.UseVisualStyleBackColor = true;
            this.btnNewProfile.Click += new System.EventHandler(this.newProfileBtn_Click);
            // 
            // btnRunSimulator
            // 
            this.btnRunSimulator.Location = new System.Drawing.Point(657, 493);
            this.btnRunSimulator.Name = "btnRunSimulator";
            this.btnRunSimulator.Size = new System.Drawing.Size(170, 28);
            this.btnRunSimulator.TabIndex = 21;
            this.btnRunSimulator.Text = "Run Simulator";
            this.btnRunSimulator.UseVisualStyleBackColor = true;
            this.btnRunSimulator.Click += new System.EventHandler(this.btnRunSimulator_Click);
            // 
            // btnRobot
            // 
            this.btnRobot.Location = new System.Drawing.Point(224, 493);
            this.btnRobot.Name = "btnRobot";
            this.btnRobot.Size = new System.Drawing.Size(162, 33);
            this.btnRobot.TabIndex = 23;
            this.btnRobot.Text = "Connect to Robot";
            this.btnRobot.UseVisualStyleBackColor = true;
            this.btnRobot.Click += new System.EventHandler(this.btnRobot_Click);
            // 
            // lblRobotStatus
            // 
            this.lblRobotStatus.AutoSize = true;
            this.lblRobotStatus.Location = new System.Drawing.Point(221, 529);
            this.lblRobotStatus.Name = "lblRobotStatus";
            this.lblRobotStatus.Size = new System.Drawing.Size(94, 17);
            this.lblRobotStatus.TabIndex = 24;
            this.lblRobotStatus.Text = "Robot Status:";
            // 
            // lblRobotStatusData
            // 
            this.lblRobotStatusData.AutoSize = true;
            this.lblRobotStatusData.ForeColor = System.Drawing.Color.Red;
            this.lblRobotStatusData.Location = new System.Drawing.Point(321, 529);
            this.lblRobotStatusData.Name = "lblRobotStatusData";
            this.lblRobotStatusData.Size = new System.Drawing.Size(94, 17);
            this.lblRobotStatusData.TabIndex = 25;
            this.lblRobotStatusData.Text = "Disconnected";
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // btnExitSim
            // 
            this.btnExitSim.Location = new System.Drawing.Point(657, 532);
            this.btnExitSim.Name = "btnExitSim";
            this.btnExitSim.Size = new System.Drawing.Size(170, 26);
            this.btnExitSim.TabIndex = 26;
            this.btnExitSim.Text = "Disconnect from Sim";
            this.btnExitSim.UseVisualStyleBackColor = true;
            this.btnExitSim.Click += new System.EventHandler(this.btnExitSim_Click);
            // 
            // lblSignal
            // 
            this.lblSignal.AutoSize = true;
            this.lblSignal.Location = new System.Drawing.Point(899, 61);
            this.lblSignal.Name = "lblSignal";
            this.lblSignal.Size = new System.Drawing.Size(47, 17);
            this.lblSignal.TabIndex = 27;
            this.lblSignal.Text = "Signal";
            // 
            // chkBoxInvert
            // 
            this.chkBoxInvert.AutoSize = true;
            this.chkBoxInvert.Location = new System.Drawing.Point(15, 60);
            this.chkBoxInvert.Name = "chkBoxInvert";
            this.chkBoxInvert.Size = new System.Drawing.Size(65, 21);
            this.chkBoxInvert.TabIndex = 28;
            this.chkBoxInvert.Text = "Invert";
            this.chkBoxInvert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCmdWindow);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.chkBoxInvert);
            this.panel1.Controls.Add(this.latestCogTxt);
            this.panel1.Controls.Add(this.powerLbl);
            this.panel1.Location = new System.Drawing.Point(712, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 29;
            // 
            // lblCmdWindow
            // 
            this.lblCmdWindow.AutoSize = true;
            this.lblCmdWindow.Location = new System.Drawing.Point(15, 4);
            this.lblCmdWindow.Name = "lblCmdWindow";
            this.lblCmdWindow.Size = new System.Drawing.Size(124, 17);
            this.lblCmdWindow.TabIndex = 29;
            this.lblCmdWindow.Text = "Command Window";
            // 
            // EEG_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(967, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSignal);
            this.Controls.Add(this.btnExitSim);
            this.Controls.Add(this.lblRobotStatusData);
            this.Controls.Add(this.lblRobotStatus);
            this.Controls.Add(this.btnRobot);
            this.Controls.Add(this.btnRunSimulator);
            this.Controls.Add(this.btnNewProfile);
            this.Controls.Add(this.loggingEnabledLbl);
            this.Controls.Add(this.loggingLbl);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.profileNameLbl);
            this.Controls.Add(this.signalImg);
            this.Controls.Add(this.btnLoadProf);
            this.Controls.Add(this.eegStrlbl2);
            this.Controls.Add(this.eegTimelbl2);
            this.Controls.Add(this.eegEmotionChart);
            this.Controls.Add(this.eegCogLbl);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.upBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EEG_Main";
            this.Text = "EEG Gateway - Shaun Webb";
            ((System.ComponentModel.ISupportInitialize)(this.eegEmotionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label eegCogLbl;
        private System.Windows.Forms.Label eegTimelbl2;
        private System.Windows.Forms.Label eegStrlbl2;
        private System.Windows.Forms.Button btnLoadProf;
        private System.Windows.Forms.Timer emotionTimer;
        private System.Windows.Forms.OpenFileDialog browseForProfileDialog;
        private System.Windows.Forms.Label profileNameLbl;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label loggingLbl;
        private System.Windows.Forms.Label loggingEnabledLbl;
        private System.Windows.Forms.Label powerLbl;
        private System.Windows.Forms.Button btnNewProfile;
        private System.Windows.Forms.Label lblRobotStatus;
        private System.Windows.Forms.Label lblRobotStatusData;
        private System.Windows.Forms.Button btnExitSim;
        public System.Windows.Forms.Button btnRobot;
        public System.Windows.Forms.DataVisualization.Charting.Chart eegEmotionChart;
        public System.Windows.Forms.Timer eegTimer;
        public System.Windows.Forms.Timer timerStatus;
        public System.Windows.Forms.TextBox latestCogTxt;
        public System.Windows.Forms.Button upBtn;
        public System.Windows.Forms.Button downBtn;
        public System.Windows.Forms.Button btnRunSimulator;
        public System.IO.Ports.SerialPort serialPortArduino;
        public System.Windows.Forms.Button leftBtn;
        public System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Label lblSignal;
        private System.Windows.Forms.PictureBox signalImg;
        private System.Windows.Forms.CheckBox chkBoxInvert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCmdWindow;
    }
}

