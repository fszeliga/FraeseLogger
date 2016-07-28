namespace FraeseLogger
{
    partial class LoggerDlg
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
            this.btnStartStopLogging = new System.Windows.Forms.Button();
            this.numLogInterval = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSN = new System.Windows.Forms.Label();
            this.val_lblSN = new System.Windows.Forms.Label();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.lblActiveProg = new System.Windows.Forms.Label();
            this.lblDoorStatus = new System.Windows.Forms.Label();
            this.lblSpindleStatus = new System.Windows.Forms.Label();
            this.lblEndschalter = new System.Windows.Forms.Label();
            this.lblWorktime = new System.Windows.Forms.Label();
            this.val_lblActiveProg = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblFeedRate = new System.Windows.Forms.Label();
            this.lblMaxCutSpeed = new System.Windows.Forms.Label();
            this.lblCutSpeed = new System.Windows.Forms.Label();
            this.val_lblEndTime = new System.Windows.Forms.Label();
            this.val_lblStartTime = new System.Windows.Forms.Label();
            this.val_lblWorktime = new System.Windows.Forms.Label();
            this.val_lblFeedRate = new System.Windows.Forms.Label();
            this.val_lblDoorStatus = new System.Windows.Forms.Label();
            this.val_lblSpindleStatus = new System.Windows.Forms.Label();
            this.val_lblCutSpeed = new System.Windows.Forms.Label();
            this.val_lblEndschalter = new System.Windows.Forms.Label();
            this.val_lblMaxCutSpeed = new System.Windows.Forms.Label();
            this.val_lblFirmware = new System.Windows.Forms.Label();
            this.lblHeightSensorActive = new System.Windows.Forms.Label();
            this.val_lblHeightSensorActive = new System.Windows.Forms.Label();
            this.lblFreilauf = new System.Windows.Forms.Label();
            this.val_lblFreilauf = new System.Windows.Forms.Label();
            this.lblGCode = new System.Windows.Forms.Label();
            this.val_lblGCode = new System.Windows.Forms.Label();
            this.lblPositions = new System.Windows.Forms.Label();
            this.val_lblPositions = new System.Windows.Forms.Label();
            this.lblSpindlespeed = new System.Windows.Forms.Label();
            this.val_lblSpindlespeed = new System.Windows.Forms.Label();
            this.cb_lblActiveProg = new System.Windows.Forms.CheckBox();
            this.cb_lblDoorStatus = new System.Windows.Forms.CheckBox();
            this.cb_lblSpindleStatus = new System.Windows.Forms.CheckBox();
            this.cb_lblEndschalter = new System.Windows.Forms.CheckBox();
            this.cb_lblStartTime = new System.Windows.Forms.CheckBox();
            this.cb_lblEndTime = new System.Windows.Forms.CheckBox();
            this.cb_lblWorktime = new System.Windows.Forms.CheckBox();
            this.cb_lblFeedRate = new System.Windows.Forms.CheckBox();
            this.cb_lblCutSpeed = new System.Windows.Forms.CheckBox();
            this.cb_lblMaxCutSpeed = new System.Windows.Forms.CheckBox();
            this.cb_lblHeightSensorActive = new System.Windows.Forms.CheckBox();
            this.cb_lblFreilauf = new System.Windows.Forms.CheckBox();
            this.cb_lblGCode = new System.Windows.Forms.CheckBox();
            this.cb_lblPositions = new System.Windows.Forms.CheckBox();
            this.cb_lblSpindlespeed = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblLogCount = new System.Windows.Forms.Label();
            this.ckbWriteTitle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.val_lblLogCount = new System.Windows.Forms.Label();
            this.lblUsedInterval = new System.Windows.Forms.Label();
            this.val_lblUsedInterval = new System.Windows.Forms.Label();
            this.btnFilename = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.val_lblOutputFolder = new System.Windows.Forms.Label();
            this.val_lblFilename = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_toggleAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSpannung = new System.Windows.Forms.Label();
            this.val_lblSpannung = new System.Windows.Forms.Label();
            this.cb_lblSpannung = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLogInterval)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStopLogging
            // 
            this.btnStartStopLogging.Enabled = false;
            this.btnStartStopLogging.Location = new System.Drawing.Point(0, 70);
            this.btnStartStopLogging.Name = "btnStartStopLogging";
            this.btnStartStopLogging.Size = new System.Drawing.Size(129, 23);
            this.btnStartStopLogging.TabIndex = 0;
            this.btnStartStopLogging.Text = "Start";
            this.btnStartStopLogging.UseVisualStyleBackColor = true;
            this.btnStartStopLogging.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numLogInterval
            // 
            this.numLogInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLogInterval.Location = new System.Drawing.Point(482, 70);
            this.numLogInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLogInterval.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numLogInterval.Name = "numLogInterval";
            this.numLogInterval.Size = new System.Drawing.Size(66, 20);
            this.numLogInterval.TabIndex = 1;
            this.numLogInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLogInterval.ValueChanged += new System.EventHandler(this.numLogInterval_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.67626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.32374F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.lblSN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.val_lblSN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFirmware, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblActiveProg, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDoorStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSpindleStatus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEndschalter, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblWorktime, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.val_lblActiveProg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEndTime, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblStartTime, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblFeedRate, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblMaxCutSpeed, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblCutSpeed, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.val_lblEndTime, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.val_lblStartTime, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.val_lblWorktime, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.val_lblFeedRate, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.val_lblDoorStatus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.val_lblSpindleStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.val_lblCutSpeed, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.val_lblEndschalter, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.val_lblMaxCutSpeed, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.val_lblFirmware, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHeightSensorActive, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.val_lblHeightSensorActive, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblFreilauf, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.val_lblFreilauf, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblGCode, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.val_lblGCode, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.lblPositions, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.val_lblPositions, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.lblSpindlespeed, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.val_lblSpindlespeed, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblActiveProg, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblDoorStatus, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblSpindleStatus, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblEndschalter, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblStartTime, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblEndTime, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblWorktime, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblFeedRate, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblCutSpeed, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblMaxCutSpeed, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblHeightSensorActive, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblFreilauf, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblGCode, 2, 14);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblPositions, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblSpindlespeed, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.lblSpannung, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.val_lblSpannung, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.cb_lblSpannung, 2, 17);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 461);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.Location = new System.Drawing.Point(3, 0);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(51, 13);
            this.lblSN.TabIndex = 0;
            this.lblSN.Text = "Fräse SN";
            // 
            // val_lblSN
            // 
            this.val_lblSN.AutoSize = true;
            this.val_lblSN.Location = new System.Drawing.Point(161, 0);
            this.val_lblSN.Name = "val_lblSN";
            this.val_lblSN.Size = new System.Drawing.Size(34, 13);
            this.val_lblSN.TabIndex = 11;
            this.val_lblSN.Text = "UNIN";
            // 
            // lblFirmware
            // 
            this.lblFirmware.AutoSize = true;
            this.lblFirmware.Location = new System.Drawing.Point(3, 25);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(90, 13);
            this.lblFirmware.TabIndex = 22;
            this.lblFirmware.Text = "Firmware Version:";
            // 
            // lblActiveProg
            // 
            this.lblActiveProg.AutoSize = true;
            this.lblActiveProg.Location = new System.Drawing.Point(3, 50);
            this.lblActiveProg.Name = "lblActiveProg";
            this.lblActiveProg.Size = new System.Drawing.Size(102, 13);
            this.lblActiveProg.TabIndex = 1;
            this.lblActiveProg.Text = "Aktives NC-Program";
            // 
            // lblDoorStatus
            // 
            this.lblDoorStatus.AutoSize = true;
            this.lblDoorStatus.Location = new System.Drawing.Point(3, 75);
            this.lblDoorStatus.Name = "lblDoorStatus";
            this.lblDoorStatus.Size = new System.Drawing.Size(56, 13);
            this.lblDoorStatus.TabIndex = 2;
            this.lblDoorStatus.Text = "Tür Status";
            // 
            // lblSpindleStatus
            // 
            this.lblSpindleStatus.AutoSize = true;
            this.lblSpindleStatus.Location = new System.Drawing.Point(3, 100);
            this.lblSpindleStatus.Name = "lblSpindleStatus";
            this.lblSpindleStatus.Size = new System.Drawing.Size(42, 13);
            this.lblSpindleStatus.TabIndex = 3;
            this.lblSpindleStatus.Text = "Spindel";
            // 
            // lblEndschalter
            // 
            this.lblEndschalter.AutoSize = true;
            this.lblEndschalter.Location = new System.Drawing.Point(3, 125);
            this.lblEndschalter.Name = "lblEndschalter";
            this.lblEndschalter.Size = new System.Drawing.Size(103, 13);
            this.lblEndschalter.TabIndex = 9;
            this.lblEndschalter.Text = "Endschalter X | Y | Z";
            // 
            // lblWorktime
            // 
            this.lblWorktime.AutoSize = true;
            this.lblWorktime.Location = new System.Drawing.Point(3, 200);
            this.lblWorktime.Name = "lblWorktime";
            this.lblWorktime.Size = new System.Drawing.Size(88, 13);
            this.lblWorktime.TabIndex = 6;
            this.lblWorktime.Text = "Bearbeitungszeit ";
            // 
            // val_lblActiveProg
            // 
            this.val_lblActiveProg.AutoSize = true;
            this.val_lblActiveProg.Location = new System.Drawing.Point(161, 50);
            this.val_lblActiveProg.Name = "val_lblActiveProg";
            this.val_lblActiveProg.Size = new System.Drawing.Size(34, 13);
            this.val_lblActiveProg.TabIndex = 12;
            this.val_lblActiveProg.Text = "UNIN";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(3, 175);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(53, 13);
            this.lblEndTime.TabIndex = 8;
            this.lblEndTime.Text = "Ende Zeit";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(3, 150);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(50, 13);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Text = "Start Zeit";
            // 
            // lblFeedRate
            // 
            this.lblFeedRate.AutoSize = true;
            this.lblFeedRate.Location = new System.Drawing.Point(3, 225);
            this.lblFeedRate.Name = "lblFeedRate";
            this.lblFeedRate.Size = new System.Drawing.Size(52, 13);
            this.lblFeedRate.TabIndex = 5;
            this.lblFeedRate.Text = "Vorschub";
            // 
            // lblMaxCutSpeed
            // 
            this.lblMaxCutSpeed.AutoSize = true;
            this.lblMaxCutSpeed.Location = new System.Drawing.Point(3, 275);
            this.lblMaxCutSpeed.Name = "lblMaxCutSpeed";
            this.lblMaxCutSpeed.Size = new System.Drawing.Size(144, 13);
            this.lblMaxCutSpeed.TabIndex = 10;
            this.lblMaxCutSpeed.Text = "max. Schnittgeschwindigkeit ";
            // 
            // lblCutSpeed
            // 
            this.lblCutSpeed.AutoSize = true;
            this.lblCutSpeed.Location = new System.Drawing.Point(3, 250);
            this.lblCutSpeed.Name = "lblCutSpeed";
            this.lblCutSpeed.Size = new System.Drawing.Size(116, 13);
            this.lblCutSpeed.TabIndex = 4;
            this.lblCutSpeed.Text = "Schnittgeschwindigkeit";
            // 
            // val_lblEndTime
            // 
            this.val_lblEndTime.AutoSize = true;
            this.val_lblEndTime.Location = new System.Drawing.Point(161, 175);
            this.val_lblEndTime.Name = "val_lblEndTime";
            this.val_lblEndTime.Size = new System.Drawing.Size(34, 13);
            this.val_lblEndTime.TabIndex = 19;
            this.val_lblEndTime.Text = "UNIN";
            // 
            // val_lblStartTime
            // 
            this.val_lblStartTime.AutoSize = true;
            this.val_lblStartTime.Location = new System.Drawing.Point(161, 150);
            this.val_lblStartTime.Name = "val_lblStartTime";
            this.val_lblStartTime.Size = new System.Drawing.Size(34, 13);
            this.val_lblStartTime.TabIndex = 18;
            this.val_lblStartTime.Text = "UNIN";
            // 
            // val_lblWorktime
            // 
            this.val_lblWorktime.AutoSize = true;
            this.val_lblWorktime.Location = new System.Drawing.Point(161, 200);
            this.val_lblWorktime.Name = "val_lblWorktime";
            this.val_lblWorktime.Size = new System.Drawing.Size(34, 13);
            this.val_lblWorktime.TabIndex = 17;
            this.val_lblWorktime.Text = "UNIN";
            // 
            // val_lblFeedRate
            // 
            this.val_lblFeedRate.AutoSize = true;
            this.val_lblFeedRate.Location = new System.Drawing.Point(161, 225);
            this.val_lblFeedRate.Name = "val_lblFeedRate";
            this.val_lblFeedRate.Size = new System.Drawing.Size(34, 13);
            this.val_lblFeedRate.TabIndex = 16;
            this.val_lblFeedRate.Text = "UNIN";
            // 
            // val_lblDoorStatus
            // 
            this.val_lblDoorStatus.AutoSize = true;
            this.val_lblDoorStatus.Location = new System.Drawing.Point(161, 75);
            this.val_lblDoorStatus.Name = "val_lblDoorStatus";
            this.val_lblDoorStatus.Size = new System.Drawing.Size(34, 13);
            this.val_lblDoorStatus.TabIndex = 13;
            this.val_lblDoorStatus.Text = "UNIN";
            // 
            // val_lblSpindleStatus
            // 
            this.val_lblSpindleStatus.AutoSize = true;
            this.val_lblSpindleStatus.Location = new System.Drawing.Point(161, 100);
            this.val_lblSpindleStatus.Name = "val_lblSpindleStatus";
            this.val_lblSpindleStatus.Size = new System.Drawing.Size(34, 13);
            this.val_lblSpindleStatus.TabIndex = 14;
            this.val_lblSpindleStatus.Text = "UNIN";
            // 
            // val_lblCutSpeed
            // 
            this.val_lblCutSpeed.AutoSize = true;
            this.val_lblCutSpeed.Location = new System.Drawing.Point(161, 250);
            this.val_lblCutSpeed.Name = "val_lblCutSpeed";
            this.val_lblCutSpeed.Size = new System.Drawing.Size(34, 13);
            this.val_lblCutSpeed.TabIndex = 15;
            this.val_lblCutSpeed.Text = "UNIN";
            // 
            // val_lblEndschalter
            // 
            this.val_lblEndschalter.AutoSize = true;
            this.val_lblEndschalter.Location = new System.Drawing.Point(161, 125);
            this.val_lblEndschalter.Name = "val_lblEndschalter";
            this.val_lblEndschalter.Size = new System.Drawing.Size(34, 13);
            this.val_lblEndschalter.TabIndex = 20;
            this.val_lblEndschalter.Text = "UNIN";
            // 
            // val_lblMaxCutSpeed
            // 
            this.val_lblMaxCutSpeed.AutoSize = true;
            this.val_lblMaxCutSpeed.Location = new System.Drawing.Point(161, 275);
            this.val_lblMaxCutSpeed.Name = "val_lblMaxCutSpeed";
            this.val_lblMaxCutSpeed.Size = new System.Drawing.Size(34, 13);
            this.val_lblMaxCutSpeed.TabIndex = 21;
            this.val_lblMaxCutSpeed.Text = "UNIN";
            // 
            // val_lblFirmware
            // 
            this.val_lblFirmware.AutoSize = true;
            this.val_lblFirmware.Location = new System.Drawing.Point(161, 25);
            this.val_lblFirmware.Name = "val_lblFirmware";
            this.val_lblFirmware.Size = new System.Drawing.Size(34, 13);
            this.val_lblFirmware.TabIndex = 23;
            this.val_lblFirmware.Text = "UNIN";
            // 
            // lblHeightSensorActive
            // 
            this.lblHeightSensorActive.AutoSize = true;
            this.lblHeightSensorActive.Location = new System.Drawing.Point(3, 300);
            this.lblHeightSensorActive.Name = "lblHeightSensorActive";
            this.lblHeightSensorActive.Size = new System.Drawing.Size(146, 13);
            this.lblHeightSensorActive.TabIndex = 24;
            this.lblHeightSensorActive.Text = "Werkzeuglängensensor Aktiv";
            // 
            // val_lblHeightSensorActive
            // 
            this.val_lblHeightSensorActive.AutoSize = true;
            this.val_lblHeightSensorActive.Location = new System.Drawing.Point(161, 300);
            this.val_lblHeightSensorActive.Name = "val_lblHeightSensorActive";
            this.val_lblHeightSensorActive.Size = new System.Drawing.Size(34, 13);
            this.val_lblHeightSensorActive.TabIndex = 25;
            this.val_lblHeightSensorActive.Text = "UNIN";
            // 
            // lblFreilauf
            // 
            this.lblFreilauf.AutoSize = true;
            this.lblFreilauf.Location = new System.Drawing.Point(3, 327);
            this.lblFreilauf.Name = "lblFreilauf";
            this.lblFreilauf.Size = new System.Drawing.Size(41, 13);
            this.lblFreilauf.TabIndex = 26;
            this.lblFreilauf.Text = "Freilauf";
            // 
            // val_lblFreilauf
            // 
            this.val_lblFreilauf.AutoSize = true;
            this.val_lblFreilauf.Location = new System.Drawing.Point(161, 327);
            this.val_lblFreilauf.Name = "val_lblFreilauf";
            this.val_lblFreilauf.Size = new System.Drawing.Size(34, 13);
            this.val_lblFreilauf.TabIndex = 27;
            this.val_lblFreilauf.Text = "UNIN";
            // 
            // lblGCode
            // 
            this.lblGCode.AutoSize = true;
            this.lblGCode.Location = new System.Drawing.Point(3, 355);
            this.lblGCode.Name = "lblGCode";
            this.lblGCode.Size = new System.Drawing.Size(104, 13);
            this.lblGCode.TabIndex = 28;
            this.lblGCode.Text = "GCode Line | GCode";
            // 
            // val_lblGCode
            // 
            this.val_lblGCode.AutoSize = true;
            this.val_lblGCode.Location = new System.Drawing.Point(161, 355);
            this.val_lblGCode.Name = "val_lblGCode";
            this.val_lblGCode.Size = new System.Drawing.Size(34, 13);
            this.val_lblGCode.TabIndex = 29;
            this.val_lblGCode.Text = "UNIN";
            // 
            // lblPositions
            // 
            this.lblPositions.AutoSize = true;
            this.lblPositions.Location = new System.Drawing.Point(3, 382);
            this.lblPositions.Name = "lblPositions";
            this.lblPositions.Size = new System.Drawing.Size(89, 13);
            this.lblPositions.TabIndex = 30;
            this.lblPositions.Text = "Positions X | Y | Z";
            // 
            // val_lblPositions
            // 
            this.val_lblPositions.AutoSize = true;
            this.val_lblPositions.Location = new System.Drawing.Point(161, 382);
            this.val_lblPositions.Name = "val_lblPositions";
            this.val_lblPositions.Size = new System.Drawing.Size(34, 13);
            this.val_lblPositions.TabIndex = 31;
            this.val_lblPositions.Text = "UNIN";
            // 
            // lblSpindlespeed
            // 
            this.lblSpindlespeed.AutoSize = true;
            this.lblSpindlespeed.Location = new System.Drawing.Point(3, 409);
            this.lblSpindlespeed.Name = "lblSpindlespeed";
            this.lblSpindlespeed.Size = new System.Drawing.Size(87, 13);
            this.lblSpindlespeed.TabIndex = 32;
            this.lblSpindlespeed.Text = "Spindel Drehzahl";
            // 
            // val_lblSpindlespeed
            // 
            this.val_lblSpindlespeed.AutoSize = true;
            this.val_lblSpindlespeed.Location = new System.Drawing.Point(161, 409);
            this.val_lblSpindlespeed.Name = "val_lblSpindlespeed";
            this.val_lblSpindlespeed.Size = new System.Drawing.Size(34, 13);
            this.val_lblSpindlespeed.TabIndex = 33;
            this.val_lblSpindlespeed.Text = "UNIN";
            // 
            // cb_lblActiveProg
            // 
            this.cb_lblActiveProg.AutoSize = true;
            this.cb_lblActiveProg.Location = new System.Drawing.Point(536, 53);
            this.cb_lblActiveProg.Name = "cb_lblActiveProg";
            this.cb_lblActiveProg.Size = new System.Drawing.Size(17, 17);
            this.cb_lblActiveProg.TabIndex = 34;
            this.cb_lblActiveProg.Text = "checkBox1";
            this.cb_lblActiveProg.UseVisualStyleBackColor = true;
            // 
            // cb_lblDoorStatus
            // 
            this.cb_lblDoorStatus.AutoSize = true;
            this.cb_lblDoorStatus.Location = new System.Drawing.Point(536, 78);
            this.cb_lblDoorStatus.Name = "cb_lblDoorStatus";
            this.cb_lblDoorStatus.Size = new System.Drawing.Size(17, 17);
            this.cb_lblDoorStatus.TabIndex = 35;
            this.cb_lblDoorStatus.Text = "checkBox1";
            this.cb_lblDoorStatus.UseVisualStyleBackColor = true;
            // 
            // cb_lblSpindleStatus
            // 
            this.cb_lblSpindleStatus.AutoSize = true;
            this.cb_lblSpindleStatus.Location = new System.Drawing.Point(536, 103);
            this.cb_lblSpindleStatus.Name = "cb_lblSpindleStatus";
            this.cb_lblSpindleStatus.Size = new System.Drawing.Size(17, 17);
            this.cb_lblSpindleStatus.TabIndex = 36;
            this.cb_lblSpindleStatus.Text = "checkBox1";
            this.cb_lblSpindleStatus.UseVisualStyleBackColor = true;
            // 
            // cb_lblEndschalter
            // 
            this.cb_lblEndschalter.AutoSize = true;
            this.cb_lblEndschalter.Location = new System.Drawing.Point(536, 128);
            this.cb_lblEndschalter.Name = "cb_lblEndschalter";
            this.cb_lblEndschalter.Size = new System.Drawing.Size(17, 17);
            this.cb_lblEndschalter.TabIndex = 37;
            this.cb_lblEndschalter.Text = "checkBox1";
            this.cb_lblEndschalter.UseVisualStyleBackColor = true;
            // 
            // cb_lblStartTime
            // 
            this.cb_lblStartTime.AutoSize = true;
            this.cb_lblStartTime.Location = new System.Drawing.Point(536, 153);
            this.cb_lblStartTime.Name = "cb_lblStartTime";
            this.cb_lblStartTime.Size = new System.Drawing.Size(17, 17);
            this.cb_lblStartTime.TabIndex = 38;
            this.cb_lblStartTime.Text = "checkBox1";
            this.cb_lblStartTime.UseVisualStyleBackColor = true;
            // 
            // cb_lblEndTime
            // 
            this.cb_lblEndTime.AutoSize = true;
            this.cb_lblEndTime.Location = new System.Drawing.Point(536, 178);
            this.cb_lblEndTime.Name = "cb_lblEndTime";
            this.cb_lblEndTime.Size = new System.Drawing.Size(17, 17);
            this.cb_lblEndTime.TabIndex = 39;
            this.cb_lblEndTime.Text = "checkBox1";
            this.cb_lblEndTime.UseVisualStyleBackColor = true;
            // 
            // cb_lblWorktime
            // 
            this.cb_lblWorktime.AutoSize = true;
            this.cb_lblWorktime.Location = new System.Drawing.Point(536, 203);
            this.cb_lblWorktime.Name = "cb_lblWorktime";
            this.cb_lblWorktime.Size = new System.Drawing.Size(17, 17);
            this.cb_lblWorktime.TabIndex = 40;
            this.cb_lblWorktime.Text = "checkBox1";
            this.cb_lblWorktime.UseVisualStyleBackColor = true;
            // 
            // cb_lblFeedRate
            // 
            this.cb_lblFeedRate.AutoSize = true;
            this.cb_lblFeedRate.Location = new System.Drawing.Point(536, 228);
            this.cb_lblFeedRate.Name = "cb_lblFeedRate";
            this.cb_lblFeedRate.Size = new System.Drawing.Size(17, 17);
            this.cb_lblFeedRate.TabIndex = 41;
            this.cb_lblFeedRate.Text = "checkBox1";
            this.cb_lblFeedRate.UseVisualStyleBackColor = true;
            // 
            // cb_lblCutSpeed
            // 
            this.cb_lblCutSpeed.AutoSize = true;
            this.cb_lblCutSpeed.Location = new System.Drawing.Point(536, 253);
            this.cb_lblCutSpeed.Name = "cb_lblCutSpeed";
            this.cb_lblCutSpeed.Size = new System.Drawing.Size(17, 17);
            this.cb_lblCutSpeed.TabIndex = 42;
            this.cb_lblCutSpeed.Text = "checkBox1";
            this.cb_lblCutSpeed.UseVisualStyleBackColor = true;
            // 
            // cb_lblMaxCutSpeed
            // 
            this.cb_lblMaxCutSpeed.AutoSize = true;
            this.cb_lblMaxCutSpeed.Location = new System.Drawing.Point(536, 278);
            this.cb_lblMaxCutSpeed.Name = "cb_lblMaxCutSpeed";
            this.cb_lblMaxCutSpeed.Size = new System.Drawing.Size(17, 17);
            this.cb_lblMaxCutSpeed.TabIndex = 43;
            this.cb_lblMaxCutSpeed.Text = "checkBox1";
            this.cb_lblMaxCutSpeed.UseVisualStyleBackColor = true;
            // 
            // cb_lblHeightSensorActive
            // 
            this.cb_lblHeightSensorActive.AutoSize = true;
            this.cb_lblHeightSensorActive.Location = new System.Drawing.Point(536, 303);
            this.cb_lblHeightSensorActive.Name = "cb_lblHeightSensorActive";
            this.cb_lblHeightSensorActive.Size = new System.Drawing.Size(17, 17);
            this.cb_lblHeightSensorActive.TabIndex = 44;
            this.cb_lblHeightSensorActive.Text = "checkBox1";
            this.cb_lblHeightSensorActive.UseVisualStyleBackColor = true;
            // 
            // cb_lblFreilauf
            // 
            this.cb_lblFreilauf.AutoSize = true;
            this.cb_lblFreilauf.Location = new System.Drawing.Point(536, 330);
            this.cb_lblFreilauf.Name = "cb_lblFreilauf";
            this.cb_lblFreilauf.Size = new System.Drawing.Size(17, 17);
            this.cb_lblFreilauf.TabIndex = 45;
            this.cb_lblFreilauf.Text = "checkBox1";
            this.cb_lblFreilauf.UseVisualStyleBackColor = true;
            // 
            // cb_lblGCode
            // 
            this.cb_lblGCode.AutoSize = true;
            this.cb_lblGCode.Location = new System.Drawing.Point(536, 358);
            this.cb_lblGCode.Name = "cb_lblGCode";
            this.cb_lblGCode.Size = new System.Drawing.Size(17, 17);
            this.cb_lblGCode.TabIndex = 46;
            this.cb_lblGCode.Text = "checkBox1";
            this.cb_lblGCode.UseVisualStyleBackColor = true;
            // 
            // cb_lblPositions
            // 
            this.cb_lblPositions.AutoSize = true;
            this.cb_lblPositions.Location = new System.Drawing.Point(536, 385);
            this.cb_lblPositions.Name = "cb_lblPositions";
            this.cb_lblPositions.Size = new System.Drawing.Size(17, 17);
            this.cb_lblPositions.TabIndex = 47;
            this.cb_lblPositions.Text = "checkBox1";
            this.cb_lblPositions.UseVisualStyleBackColor = true;
            // 
            // cb_lblSpindlespeed
            // 
            this.cb_lblSpindlespeed.AutoSize = true;
            this.cb_lblSpindlespeed.Location = new System.Drawing.Point(536, 412);
            this.cb_lblSpindlespeed.Name = "cb_lblSpindlespeed";
            this.cb_lblSpindlespeed.Size = new System.Drawing.Size(17, 17);
            this.cb_lblSpindlespeed.TabIndex = 48;
            this.cb_lblSpindlespeed.Text = "checkBox1";
            this.cb_lblSpindlespeed.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblLogCount
            // 
            this.lblLogCount.AutoSize = true;
            this.lblLogCount.Location = new System.Drawing.Point(425, 23);
            this.lblLogCount.Name = "lblLogCount";
            this.lblLogCount.Size = new System.Drawing.Size(81, 13);
            this.lblLogCount.TabIndex = 3;
            this.lblLogCount.Text = "Logged Entries:";
            // 
            // ckbWriteTitle
            // 
            this.ckbWriteTitle.AutoSize = true;
            this.ckbWriteTitle.Location = new System.Drawing.Point(135, 74);
            this.ckbWriteTitle.Name = "ckbWriteTitle";
            this.ckbWriteTitle.Size = new System.Drawing.Size(128, 17);
            this.ckbWriteTitle.TabIndex = 5;
            this.ckbWriteTitle.Text = "Überschrift Schreiben";
            this.ckbWriteTitle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log Intervall in ms";
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(0, 14);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(59, 23);
            this.btnOutputFolder.TabIndex = 8;
            this.btnOutputFolder.Text = "Ändern";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.lblOutputFolderPicker_Click);
            // 
            // val_lblLogCount
            // 
            this.val_lblLogCount.AutoSize = true;
            this.val_lblLogCount.Location = new System.Drawing.Point(514, 24);
            this.val_lblLogCount.Name = "val_lblLogCount";
            this.val_lblLogCount.Size = new System.Drawing.Size(34, 13);
            this.val_lblLogCount.TabIndex = 9;
            this.val_lblLogCount.Text = "UNIN";
            // 
            // lblUsedInterval
            // 
            this.lblUsedInterval.AutoSize = true;
            this.lblUsedInterval.Location = new System.Drawing.Point(416, 44);
            this.lblUsedInterval.Name = "lblUsedInterval";
            this.lblUsedInterval.Size = new System.Drawing.Size(90, 13);
            this.lblUsedInterval.TabIndex = 10;
            this.lblUsedInterval.Text = "Log Intervall (ms):";
            // 
            // val_lblUsedInterval
            // 
            this.val_lblUsedInterval.AutoSize = true;
            this.val_lblUsedInterval.Location = new System.Drawing.Point(514, 45);
            this.val_lblUsedInterval.Name = "val_lblUsedInterval";
            this.val_lblUsedInterval.Size = new System.Drawing.Size(34, 13);
            this.val_lblUsedInterval.TabIndex = 11;
            this.val_lblUsedInterval.Text = "UNIN";
            // 
            // btnFilename
            // 
            this.btnFilename.Location = new System.Drawing.Point(0, 43);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(59, 23);
            this.btnFilename.TabIndex = 12;
            this.btnFilename.Text = "Ändern";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(61, 49);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(66, 13);
            this.lblFilename.TabIndex = 13;
            this.lblFilename.Text = "Datei Name:";
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(61, 19);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(77, 13);
            this.lblOutputFolder.TabIndex = 14;
            this.lblOutputFolder.Text = "Output Ordner:";
            // 
            // val_lblOutputFolder
            // 
            this.val_lblOutputFolder.AutoSize = true;
            this.val_lblOutputFolder.Location = new System.Drawing.Point(135, 19);
            this.val_lblOutputFolder.Name = "val_lblOutputFolder";
            this.val_lblOutputFolder.Size = new System.Drawing.Size(35, 13);
            this.val_lblOutputFolder.TabIndex = 15;
            this.val_lblOutputFolder.Text = "label2";
            // 
            // val_lblFilename
            // 
            this.val_lblFilename.AutoSize = true;
            this.val_lblFilename.Location = new System.Drawing.Point(134, 49);
            this.val_lblFilename.Name = "val_lblFilename";
            this.val_lblFilename.Size = new System.Drawing.Size(35, 13);
            this.val_lblFilename.TabIndex = 16;
            this.val_lblFilename.Text = "label2";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 96);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(34, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "UNIN";
            // 
            // btn_toggleAll
            // 
            this.btn_toggleAll.Location = new System.Drawing.Point(442, 498);
            this.btn_toggleAll.Name = "btn_toggleAll";
            this.btn_toggleAll.Size = new System.Drawing.Size(126, 23);
            this.btn_toggleAll.TabIndex = 17;
            this.btn_toggleAll.Text = "Select/Deselect All";
            this.btn_toggleAll.UseVisualStyleBackColor = true;
            this.btn_toggleAll.Click += new System.EventHandler(this.btn_toggleAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Log?";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ckbWriteTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numLogInterval);
            this.panel1.Controls.Add(this.val_lblFilename);
            this.panel1.Controls.Add(this.lblLogCount);
            this.panel1.Controls.Add(this.val_lblOutputFolder);
            this.panel1.Controls.Add(this.val_lblLogCount);
            this.panel1.Controls.Add(this.lblOutputFolder);
            this.panel1.Controls.Add(this.lblUsedInterval);
            this.panel1.Controls.Add(this.lblFilename);
            this.panel1.Controls.Add(this.val_lblUsedInterval);
            this.panel1.Controls.Add(this.btnFilename);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btnOutputFolder);
            this.panel1.Controls.Add(this.btnStartStopLogging);
            this.panel1.Location = new System.Drawing.Point(12, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 109);
            this.panel1.TabIndex = 19;
            // 
            // lblSpannung
            // 
            this.lblSpannung.AutoSize = true;
            this.lblSpannung.Location = new System.Drawing.Point(3, 435);
            this.lblSpannung.Name = "lblSpannung";
            this.lblSpannung.Size = new System.Drawing.Size(113, 13);
            this.lblSpannung.TabIndex = 49;
            this.lblSpannung.Text = "Spannung Eingang 1&2";
            // 
            // val_lblSpannung
            // 
            this.val_lblSpannung.AutoSize = true;
            this.val_lblSpannung.Location = new System.Drawing.Point(161, 435);
            this.val_lblSpannung.Name = "val_lblSpannung";
            this.val_lblSpannung.Size = new System.Drawing.Size(35, 13);
            this.val_lblSpannung.TabIndex = 50;
            this.val_lblSpannung.Text = "label3";
            // 
            // cb_lblSpannung
            // 
            this.cb_lblSpannung.AutoSize = true;
            this.cb_lblSpannung.Location = new System.Drawing.Point(536, 438);
            this.cb_lblSpannung.Name = "cb_lblSpannung";
            this.cb_lblSpannung.Size = new System.Drawing.Size(17, 17);
            this.cb_lblSpannung.TabIndex = 51;
            this.cb_lblSpannung.Text = "checkBox1";
            this.cb_lblSpannung.UseVisualStyleBackColor = true;
            // 
            // LoggerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_toggleAll);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoggerDlg";
            this.Text = "Fräse Logger";
            ((System.ComponentModel.ISupportInitialize)(this.numLogInterval)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStopLogging;
        private System.Windows.Forms.NumericUpDown numLogInterval;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.Label lblActiveProg;
        private System.Windows.Forms.Label lblDoorStatus;
        private System.Windows.Forms.Label lblSpindleStatus;
        private System.Windows.Forms.Label lblCutSpeed;
        private System.Windows.Forms.Label lblFeedRate;
        private System.Windows.Forms.Label lblWorktime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblEndschalter;
        private System.Windows.Forms.Label lblMaxCutSpeed;
        private System.Windows.Forms.Label val_lblSN;
        private System.Windows.Forms.Label val_lblActiveProg;
        private System.Windows.Forms.Label val_lblDoorStatus;
        private System.Windows.Forms.Label val_lblSpindleStatus;
        private System.Windows.Forms.Label val_lblCutSpeed;
        private System.Windows.Forms.Label val_lblFeedRate;
        private System.Windows.Forms.Label val_lblWorktime;
        private System.Windows.Forms.Label val_lblStartTime;
        private System.Windows.Forms.Label val_lblEndTime;
        private System.Windows.Forms.Label val_lblEndschalter;
        private System.Windows.Forms.Label val_lblMaxCutSpeed;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Label val_lblFirmware;
        private System.Windows.Forms.Label lblLogCount;
        private System.Windows.Forms.CheckBox ckbWriteTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.Label val_lblLogCount;
        private System.Windows.Forms.Label lblUsedInterval;
        private System.Windows.Forms.Label val_lblUsedInterval;
        private System.Windows.Forms.Button btnFilename;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Label val_lblOutputFolder;
        private System.Windows.Forms.Label val_lblFilename;
        private System.Windows.Forms.Label lblHeightSensorActive;
        private System.Windows.Forms.Label val_lblHeightSensorActive;
        private System.Windows.Forms.Label lblFreilauf;
        private System.Windows.Forms.Label val_lblFreilauf;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGCode;
        private System.Windows.Forms.Label val_lblGCode;
        private System.Windows.Forms.Label lblPositions;
        private System.Windows.Forms.Label val_lblPositions;
        private System.Windows.Forms.Label lblSpindlespeed;
        private System.Windows.Forms.Label val_lblSpindlespeed;
        private System.Windows.Forms.CheckBox cb_lblActiveProg;
        private System.Windows.Forms.CheckBox cb_lblDoorStatus;
        private System.Windows.Forms.CheckBox cb_lblSpindleStatus;
        private System.Windows.Forms.CheckBox cb_lblEndschalter;
        private System.Windows.Forms.CheckBox cb_lblStartTime;
        private System.Windows.Forms.CheckBox cb_lblEndTime;
        private System.Windows.Forms.CheckBox cb_lblWorktime;
        private System.Windows.Forms.CheckBox cb_lblFeedRate;
        private System.Windows.Forms.CheckBox cb_lblCutSpeed;
        private System.Windows.Forms.CheckBox cb_lblMaxCutSpeed;
        private System.Windows.Forms.CheckBox cb_lblHeightSensorActive;
        private System.Windows.Forms.CheckBox cb_lblFreilauf;
        private System.Windows.Forms.CheckBox cb_lblGCode;
        private System.Windows.Forms.CheckBox cb_lblPositions;
        private System.Windows.Forms.CheckBox cb_lblSpindlespeed;
        private System.Windows.Forms.Button btn_toggleAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSpannung;
        private System.Windows.Forms.Label val_lblSpannung;
        private System.Windows.Forms.CheckBox cb_lblSpannung;
    }
}