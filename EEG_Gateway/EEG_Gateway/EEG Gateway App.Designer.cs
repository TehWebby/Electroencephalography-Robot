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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.latestCogTxt = new System.Windows.Forms.TextBox();
            this.cognitiveActionTimer = new System.Windows.Forms.Timer(this.components);
            this.upBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.liveEEG = new System.Windows.Forms.Timer(this.components);
            this.eegCogLbl = new System.Windows.Forms.Label();
            this.eegEmotionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.eegTimelbl2 = new System.Windows.Forms.Label();
            this.eegStrlbl2 = new System.Windows.Forms.Label();
            this.loadProfBtn = new System.Windows.Forms.Button();
            this.eegTimer = new System.Windows.Forms.Timer(this.components);
            this.emotionTimer = new System.Windows.Forms.Timer(this.components);
            this.signalImg = new System.Windows.Forms.PictureBox();
            this.browseForProfileDialog = new System.Windows.Forms.OpenFileDialog();
            this.profileNameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eegEmotionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalImg)).BeginInit();
            this.SuspendLayout();
            // 
            // latestCogTxt
            // 
            this.latestCogTxt.Location = new System.Drawing.Point(702, 305);
            this.latestCogTxt.MaxLength = 1;
            this.latestCogTxt.Name = "latestCogTxt";
            this.latestCogTxt.Size = new System.Drawing.Size(192, 22);
            this.latestCogTxt.TabIndex = 0;
            // 
            // cognitiveActionTimer
            // 
            this.cognitiveActionTimer.Enabled = true;
            this.cognitiveActionTimer.Interval = 500;
            this.cognitiveActionTimer.Tick += new System.EventHandler(this.cognitiveActionTimer_Tick);
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(751, 35);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(76, 44);
            this.upBtn.TabIndex = 1;
            this.upBtn.Text = "UP";
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Location = new System.Drawing.Point(751, 119);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(76, 44);
            this.downBtn.TabIndex = 2;
            this.downBtn.Text = "DOWN";
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Location = new System.Drawing.Point(657, 76);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(76, 44);
            this.leftBtn.TabIndex = 3;
            this.leftBtn.Text = "LEFT";
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Location = new System.Drawing.Point(848, 76);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(76, 44);
            this.rightBtn.TabIndex = 4;
            this.rightBtn.Text = "RIGHT";
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 360);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(659, 102);
            this.textBox1.TabIndex = 5;
            // 
            // liveEEG
            // 
            this.liveEEG.Enabled = true;
            this.liveEEG.Interval = 1000;
            this.liveEEG.Tick += new System.EventHandler(this.liveEEG_Tick);
            // 
            // eegCogLbl
            // 
            this.eegCogLbl.AutoSize = true;
            this.eegCogLbl.Location = new System.Drawing.Point(691, 276);
            this.eegCogLbl.Name = "eegCogLbl";
            this.eegCogLbl.Size = new System.Drawing.Size(215, 17);
            this.eegCogLbl.TabIndex = 6;
            this.eegCogLbl.Text = "EEG Interpreted Cognitive Action";
            // 
            // eegEmotionChart
            // 
            chartArea3.Name = "ChartArea1";
            this.eegEmotionChart.ChartAreas.Add(chartArea3);
            legend3.AutoFitMinFontSize = 8;
            legend3.Name = "Legend1";
            this.eegEmotionChart.Legends.Add(legend3);
            this.eegEmotionChart.Location = new System.Drawing.Point(80, 35);
            this.eegEmotionChart.Name = "eegEmotionChart";
            this.eegEmotionChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series15.BorderWidth = 2;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Color = System.Drawing.Color.Red;
            series15.Legend = "Legend1";
            series15.Name = "Short Term Excitement";
            series16.BorderWidth = 2;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series16.Color = System.Drawing.Color.Sienna;
            series16.Legend = "Legend1";
            series16.Name = "Long Term Excitement";
            series17.BorderWidth = 2;
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series17.Color = System.Drawing.Color.Lime;
            series17.Legend = "Legend1";
            series17.Name = "Engagement/Boredom";
            series18.BorderWidth = 2;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series18.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series18.Legend = "Legend1";
            series18.Name = "Smile";
            series19.BorderWidth = 2;
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series19.Color = System.Drawing.Color.LightSkyBlue;
            series19.Legend = "Legend1";
            series19.Name = "Valence";
            series20.BorderWidth = 2;
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series20.Legend = "Legend1";
            series20.Name = "Frustration";
            series21.BorderWidth = 2;
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series21.Color = System.Drawing.Color.CornflowerBlue;
            series21.Legend = "Legend1";
            series21.Name = "Meditation";
            this.eegEmotionChart.Series.Add(series15);
            this.eegEmotionChart.Series.Add(series16);
            this.eegEmotionChart.Series.Add(series17);
            this.eegEmotionChart.Series.Add(series18);
            this.eegEmotionChart.Series.Add(series19);
            this.eegEmotionChart.Series.Add(series20);
            this.eegEmotionChart.Series.Add(series21);
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
            // loadProfBtn
            // 
            this.loadProfBtn.Location = new System.Drawing.Point(848, 542);
            this.loadProfBtn.Name = "loadProfBtn";
            this.loadProfBtn.Size = new System.Drawing.Size(114, 23);
            this.loadProfBtn.TabIndex = 13;
            this.loadProfBtn.Text = "Load Profile";
            this.loadProfBtn.UseVisualStyleBackColor = true;
            this.loadProfBtn.Click += new System.EventHandler(this.loadProfBtn_Click);
            // 
            // eegTimer
            // 
            this.eegTimer.Enabled = true;
            this.eegTimer.Interval = 500;
            this.eegTimer.Tick += new System.EventHandler(this.eegTimer_Tick);
            // 
            // emotionTimer
            // 
            this.emotionTimer.Enabled = true;
            this.emotionTimer.Interval = 500;
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
            // EEG_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(967, 577);
            this.Controls.Add(this.profileNameLbl);
            this.Controls.Add(this.signalImg);
            this.Controls.Add(this.loadProfBtn);
            this.Controls.Add(this.eegStrlbl2);
            this.Controls.Add(this.eegTimelbl2);
            this.Controls.Add(this.eegEmotionChart);
            this.Controls.Add(this.eegCogLbl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.upBtn);
            this.Controls.Add(this.latestCogTxt);
            this.Name = "EEG_Main";
            this.Text = "EEG Gateway - Shaun Webb";
            ((System.ComponentModel.ISupportInitialize)(this.eegEmotionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 

        private System.Windows.Forms.TextBox latestCogTxt;
        private System.Windows.Forms.Timer cognitiveActionTimer;
        private System.Windows.Forms.Button upBtn;
        private System.Windows.Forms.Button downBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer liveEEG;
        private System.Windows.Forms.Label eegCogLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart eegEmotionChart;
        private System.Windows.Forms.Label eegTimelbl2;
        private System.Windows.Forms.Label eegStrlbl2;
        private System.Windows.Forms.Button loadProfBtn;
        private System.Windows.Forms.Timer eegTimer;
        private System.Windows.Forms.Timer emotionTimer;
        private System.Windows.Forms.PictureBox signalImg;
        private System.Windows.Forms.OpenFileDialog browseForProfileDialog;
        private System.Windows.Forms.Label profileNameLbl;
    }
}

