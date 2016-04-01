//-----------------------------------------------------------------------
//  This file is part of Microsoft Robotics Developer Studio Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: DriveControl.Designer.cs $ $Revision: 2 $
//-----------------------------------------------------------------------

namespace Microsoft.Robotics.Services.SimpleDashboard
{
    partial class DriveControl
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label lblActiveJoint;
            this.cbJoystick = new System.Windows.Forms.ComboBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblButtons = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStop = new System.Windows.Forms.CheckBox();
            this.chkDrive = new System.Windows.Forms.CheckBox();
            this.picJoystick = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkDirectory = new System.Windows.Forms.LinkLabel();
            this.lblNode = new System.Windows.Forms.Label();
            this.listDirectory = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.MaskedTextBox();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnConnectLRF = new System.Windows.Forms.Button();
            this.btnStartLRF = new System.Windows.Forms.Button();
            this.picLRF = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblLag = new System.Windows.Forms.Label();
            this.lblMotor = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblActiveJointValue = new System.Windows.Forms.Label();
            this.listArticulatedArmJoints = new System.Windows.Forms.ListBox();
            this.btnConnect_ArticulatedArm = new System.Windows.Forms.Button();
            this.btnJointParamsApply = new System.Windows.Forms.Button();
            this.textBoxJointAngle = new System.Windows.Forms.TextBox();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            lblActiveJoint = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoystick)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLRF)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 31);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 17);
            label1.TabIndex = 1;
            label1.Text = "Device:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(45, 62);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(21, 17);
            label5.TabIndex = 5;
            label5.Text = "X:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(45, 82);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(21, 17);
            label6.TabIndex = 6;
            label6.Text = "Y:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(45, 103);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(21, 17);
            label7.TabIndex = 7;
            label7.Text = "Z:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 124);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 17);
            label2.TabIndex = 8;
            label2.Text = "Buttons:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 62);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 17);
            label4.TabIndex = 1;
            label4.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 25);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 17);
            label3.TabIndex = 0;
            label3.Text = "Machine:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(19, 21);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(48, 17);
            label8.TabIndex = 16;
            label8.Text = "Motor:";
            label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(31, 42);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(36, 17);
            label10.TabIndex = 18;
            label10.Text = "Lag:";
            label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(128, 76);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(48, 17);
            label9.TabIndex = 18;
            label9.Text = "Angle:";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblActiveJoint
            // 
            lblActiveJoint.AutoSize = true;
            lblActiveJoint.Location = new System.Drawing.Point(128, 27);
            lblActiveJoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblActiveJoint.Name = "lblActiveJoint";
            lblActiveJoint.Size = new System.Drawing.Size(84, 17);
            lblActiveJoint.TabIndex = 24;
            lblActiveJoint.Text = "Active Joint:";
            lblActiveJoint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbJoystick
            // 
            this.cbJoystick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbJoystick.FormattingEnabled = true;
            this.cbJoystick.Location = new System.Drawing.Point(80, 27);
            this.cbJoystick.Margin = new System.Windows.Forms.Padding(4);
            this.cbJoystick.Name = "cbJoystick";
            this.cbJoystick.Size = new System.Drawing.Size(171, 24);
            this.cbJoystick.TabIndex = 0;
            this.cbJoystick.SelectedIndexChanged += new System.EventHandler(this.cbJoystick_SelectedIndexChanged);
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(80, 62);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(47, 16);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "0";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Location = new System.Drawing.Point(80, 82);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(47, 16);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "0";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            this.lblZ.Location = new System.Drawing.Point(80, 103);
            this.lblZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(47, 16);
            this.lblZ.TabIndex = 4;
            this.lblZ.Text = "0";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblButtons
            // 
            this.lblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblButtons.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButtons.Location = new System.Drawing.Point(84, 124);
            this.lblButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(168, 16);
            this.lblButtons.TabIndex = 9;
            this.lblButtons.Text = "O";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStop);
            this.groupBox1.Controls.Add(this.chkDrive);
            this.groupBox1.Controls.Add(this.picJoystick);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.lblButtons);
            this.groupBox1.Controls.Add(this.cbJoystick);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.lblX);
            this.groupBox1.Controls.Add(label7);
            this.groupBox1.Controls.Add(this.lblY);
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(this.lblZ);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(260, 186);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direct Input Device";
            // 
            // chkStop
            // 
            this.chkStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStop.Location = new System.Drawing.Point(149, 144);
            this.chkStop.Margin = new System.Windows.Forms.Padding(4);
            this.chkStop.Name = "chkStop";
            this.chkStop.Size = new System.Drawing.Size(103, 30);
            this.chkStop.TabIndex = 12;
            this.chkStop.Text = "Stop";
            this.chkStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStop.UseVisualStyleBackColor = true;
            this.chkStop.CheckedChanged += new System.EventHandler(this.chkStop_CheckedChanged);
            // 
            // chkDrive
            // 
            this.chkDrive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDrive.Location = new System.Drawing.Point(12, 144);
            this.chkDrive.Margin = new System.Windows.Forms.Padding(4);
            this.chkDrive.Name = "chkDrive";
            this.chkDrive.Size = new System.Drawing.Size(101, 30);
            this.chkDrive.TabIndex = 11;
            this.chkDrive.Text = "Drive";
            this.chkDrive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDrive.UseVisualStyleBackColor = true;
            this.chkDrive.CheckedChanged += new System.EventHandler(this.chkDrive_CheckedChanged);
            // 
            // picJoystick
            // 
            this.picJoystick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picJoystick.Location = new System.Drawing.Point(172, 60);
            this.picJoystick.Margin = new System.Windows.Forms.Padding(4);
            this.picJoystick.Name = "picJoystick";
            this.picJoystick.Size = new System.Drawing.Size(65, 60);
            this.picJoystick.TabIndex = 10;
            this.picJoystick.TabStop = false;
            this.picJoystick.MouseLeave += new System.EventHandler(this.picJoystick_MouseLeave);
            this.picJoystick.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picJoystick_MouseMove);
            this.picJoystick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picJoystick_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.linkDirectory);
            this.groupBox2.Controls.Add(this.lblNode);
            this.groupBox2.Controls.Add(this.listDirectory);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtMachine);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Location = new System.Drawing.Point(284, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(337, 356);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote Node";
            // 
            // linkDirectory
            // 
            this.linkDirectory.AutoSize = true;
            this.linkDirectory.Enabled = false;
            this.linkDirectory.LinkArea = new System.Windows.Forms.LinkArea(8, 9);
            this.linkDirectory.Location = new System.Drawing.Point(9, 92);
            this.linkDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkDirectory.Name = "linkDirectory";
            this.linkDirectory.Size = new System.Drawing.Size(110, 20);
            this.linkDirectory.TabIndex = 8;
            this.linkDirectory.TabStop = true;
            this.linkDirectory.Text = "Service Directory:";
            this.linkDirectory.UseCompatibleTextRendering = true;
            this.linkDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDirectory_LinkClicked);
            // 
            // lblNode
            // 
            this.lblNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNode.AutoEllipsis = true;
            this.lblNode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNode.Location = new System.Drawing.Point(13, 118);
            this.lblNode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(312, 18);
            this.lblNode.TabIndex = 7;
            // 
            // listDirectory
            // 
            this.listDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDirectory.FormattingEnabled = true;
            this.listDirectory.ItemHeight = 16;
            this.listDirectory.Location = new System.Drawing.Point(13, 146);
            this.listDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(315, 196);
            this.listDirectory.TabIndex = 5;
            this.listDirectory.DoubleClick += new System.EventHandler(this.listDirectory_DoubleClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(256, 52);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 28);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(85, 54);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Mask = "99999";
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(55, 22);
            this.txtPort.TabIndex = 3;
            // 
            // txtMachine
            // 
            this.txtMachine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachine.Location = new System.Drawing.Point(85, 21);
            this.txtMachine.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(243, 22);
            this.txtMachine.TabIndex = 2;
            this.txtMachine.Text = "localhost";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnDisconnect);
            this.groupBox3.Controls.Add(this.lblDelay);
            this.groupBox3.Controls.Add(this.btnConnectLRF);
            this.groupBox3.Controls.Add(this.btnStartLRF);
            this.groupBox3.Controls.Add(this.picLRF);
            this.groupBox3.Location = new System.Drawing.Point(16, 503);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(605, 154);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Laser Range Finder";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(8, 94);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 28);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblDelay
            // 
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelay.Location = new System.Drawing.Point(8, 126);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(100, 22);
            this.lblDelay.TabIndex = 3;
            this.lblDelay.Text = "0";
            // 
            // btnConnectLRF
            // 
            this.btnConnectLRF.Enabled = false;
            this.btnConnectLRF.Location = new System.Drawing.Point(8, 58);
            this.btnConnectLRF.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectLRF.Name = "btnConnectLRF";
            this.btnConnectLRF.Size = new System.Drawing.Size(100, 28);
            this.btnConnectLRF.TabIndex = 2;
            this.btnConnectLRF.Text = "Connect";
            this.btnConnectLRF.UseVisualStyleBackColor = true;
            this.btnConnectLRF.Click += new System.EventHandler(this.btnConnectLRF_Click);
            // 
            // btnStartLRF
            // 
            this.btnStartLRF.Enabled = false;
            this.btnStartLRF.Location = new System.Drawing.Point(8, 22);
            this.btnStartLRF.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartLRF.Name = "btnStartLRF";
            this.btnStartLRF.Size = new System.Drawing.Size(100, 28);
            this.btnStartLRF.TabIndex = 1;
            this.btnStartLRF.Text = "Start";
            this.btnStartLRF.UseVisualStyleBackColor = true;
            this.btnStartLRF.Click += new System.EventHandler(this.btnStartLRF_Click);
            // 
            // picLRF
            // 
            this.picLRF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLRF.Location = new System.Drawing.Point(116, 22);
            this.picLRF.Margin = new System.Windows.Forms.Padding(4);
            this.picLRF.Name = "picLRF";
            this.picLRF.Size = new System.Drawing.Size(481, 123);
            this.picLRF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLRF.TabIndex = 0;
            this.picLRF.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(label10);
            this.groupBox4.Controls.Add(this.lblLag);
            this.groupBox4.Controls.Add(label8);
            this.groupBox4.Controls.Add(this.lblMotor);
            this.groupBox4.Location = new System.Drawing.Point(16, 208);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(260, 68);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Differential Drive";
            // 
            // lblLag
            // 
            this.lblLag.Location = new System.Drawing.Point(80, 42);
            this.lblLag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLag.Name = "lblLag";
            this.lblLag.Size = new System.Drawing.Size(47, 16);
            this.lblLag.TabIndex = 17;
            this.lblLag.Text = "0";
            this.lblLag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMotor
            // 
            this.lblMotor.Location = new System.Drawing.Point(80, 21);
            this.lblMotor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(47, 16);
            this.lblMotor.TabIndex = 15;
            this.lblMotor.Text = "Off";
            this.lblMotor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnBrowse);
            this.groupBox5.Controls.Add(this.txtLogFile);
            this.groupBox5.Controls.Add(this.chkLog);
            this.groupBox5.Location = new System.Drawing.Point(16, 283);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(260, 87);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logging";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(216, 52);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(36, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(8, 53);
            this.txtLogFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(199, 22);
            this.txtLogFile.TabIndex = 1;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(8, 23);
            this.chkLog.Margin = new System.Windows.Forms.Padding(4);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(122, 21);
            this.chkLog.TabIndex = 0;
            this.chkLog.Text = "Log Messages";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Xml log file|*.log;*.xml|All files|*.*";
            this.saveFileDialog.Title = "Log File";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lblActiveJointValue);
            this.groupBox6.Controls.Add(lblActiveJoint);
            this.groupBox6.Controls.Add(this.listArticulatedArmJoints);
            this.groupBox6.Controls.Add(this.btnConnect_ArticulatedArm);
            this.groupBox6.Controls.Add(this.btnJointParamsApply);
            this.groupBox6.Controls.Add(this.textBoxJointAngle);
            this.groupBox6.Controls.Add(label9);
            this.groupBox6.Location = new System.Drawing.Point(16, 378);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(605, 118);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Articulated Arm";
            // 
            // lblActiveJointValue
            // 
            this.lblActiveJointValue.Location = new System.Drawing.Point(128, 47);
            this.lblActiveJointValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveJointValue.Name = "lblActiveJointValue";
            this.lblActiveJointValue.Size = new System.Drawing.Size(100, 22);
            this.lblActiveJointValue.TabIndex = 25;
            this.lblActiveJointValue.Text = "None";
            // 
            // listArticulatedArmJoints
            // 
            this.listArticulatedArmJoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listArticulatedArmJoints.FormattingEnabled = true;
            this.listArticulatedArmJoints.ItemHeight = 16;
            this.listArticulatedArmJoints.Location = new System.Drawing.Point(281, 25);
            this.listArticulatedArmJoints.Margin = new System.Windows.Forms.Padding(4);
            this.listArticulatedArmJoints.Name = "listArticulatedArmJoints";
            this.listArticulatedArmJoints.Size = new System.Drawing.Size(315, 84);
            this.listArticulatedArmJoints.TabIndex = 23;
            this.listArticulatedArmJoints.DoubleClick += new System.EventHandler(this.listArticulatedArmJointList_DoubleClick);
            // 
            // btnConnect_ArticulatedArm
            // 
            this.btnConnect_ArticulatedArm.Enabled = false;
            this.btnConnect_ArticulatedArm.Location = new System.Drawing.Point(8, 25);
            this.btnConnect_ArticulatedArm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect_ArticulatedArm.Name = "btnConnect_ArticulatedArm";
            this.btnConnect_ArticulatedArm.Size = new System.Drawing.Size(100, 28);
            this.btnConnect_ArticulatedArm.TabIndex = 22;
            this.btnConnect_ArticulatedArm.Text = "Connect";
            this.btnConnect_ArticulatedArm.UseVisualStyleBackColor = true;
            this.btnConnect_ArticulatedArm.Click += new System.EventHandler(this.btnConnect_ArticulatedArm_Click);
            // 
            // btnJointParamsApply
            // 
            this.btnJointParamsApply.Location = new System.Drawing.Point(8, 57);
            this.btnJointParamsApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnJointParamsApply.Name = "btnJointParamsApply";
            this.btnJointParamsApply.Size = new System.Drawing.Size(100, 53);
            this.btnJointParamsApply.TabIndex = 21;
            this.btnJointParamsApply.Text = "Apply Changes";
            this.btnJointParamsApply.UseVisualStyleBackColor = true;
            this.btnJointParamsApply.Click += new System.EventHandler(this.btnJointParamsApply_Click);
            // 
            // textBoxJointAngle
            // 
            this.textBoxJointAngle.Location = new System.Drawing.Point(185, 73);
            this.textBoxJointAngle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxJointAngle.Name = "textBoxJointAngle";
            this.textBoxJointAngle.Size = new System.Drawing.Size(75, 22);
            this.textBoxJointAngle.TabIndex = 20;
            // 
            // startTimer
            // 
            this.startTimer.Enabled = true;
            this.startTimer.Interval = 250;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // DriveControl
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 672);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(642, 703);
            this.Name = "DriveControl";
            this.Opacity = 0D;
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DriveControl_FormClosed);
            this.Load += new System.EventHandler(this.DriveControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoystick)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLRF)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbJoystick;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listDirectory;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.MaskedTextBox txtPort;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.PictureBox picJoystick;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConnectLRF;
        private System.Windows.Forms.Button btnStartLRF;
        private System.Windows.Forms.PictureBox picLRF;
        private System.Windows.Forms.CheckBox chkStop;
        private System.Windows.Forms.CheckBox chkDrive;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.Label lblLag;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.LinkLabel linkDirectory;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxJointAngle;
        private System.Windows.Forms.Button btnJointParamsApply;
        private System.Windows.Forms.Button btnConnect_ArticulatedArm;
        private System.Windows.Forms.ListBox listArticulatedArmJoints;
        private System.Windows.Forms.Label lblActiveJointValue;
        private System.Windows.Forms.Timer startTimer;
    }
}