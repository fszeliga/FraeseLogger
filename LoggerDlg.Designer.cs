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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableData = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lb_LogOutput = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnServer = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.val_localIP = new System.Windows.Forms.Label();
            this.val_extIP = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartStopLogging = new System.Windows.Forms.Button();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.btnFilename = new System.Windows.Forms.Button();
            this.val_lblUsedInterval = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblUsedInterval = new System.Windows.Forms.Label();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.val_lblLogCount = new System.Windows.Forms.Label();
            this.val_lblOutputFolder = new System.Windows.Forms.Label();
            this.lblLogCount = new System.Windows.Forms.Label();
            this.val_lblFilename = new System.Windows.Forms.Label();
            this.numLogInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbWriteTitle = new System.Windows.Forms.CheckBox();
            this.tabData = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogInterval)).BeginInit();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 613);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(654, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel.Text = "NA";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableData);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(622, 571);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "CNC Data";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableData
            // 
            this.tableData.ColumnCount = 3;
            this.tableData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tableData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42105F));
            this.tableData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableData.Location = new System.Drawing.Point(6, 6);
            this.tableData.Name = "tableData";
            this.tableData.RowCount = 1;
            this.tableData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableData.Size = new System.Drawing.Size(610, 23);
            this.tableData.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.lb_LogOutput);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(622, 571);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lb_LogOutput
            // 
            this.lb_LogOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_LogOutput.FormattingEnabled = true;
            this.lb_LogOutput.Location = new System.Drawing.Point(3, 6);
            this.lb_LogOutput.Name = "lb_LogOutput";
            this.lb_LogOutput.ScrollAlwaysVisible = true;
            this.lb_LogOutput.Size = new System.Drawing.Size(613, 433);
            this.lb_LogOutput.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(541, 542);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.val_extIP);
            this.tabPage3.Controls.Add(this.val_localIP);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.btnServer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(622, 571);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WebServer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnServer
            // 
            this.btnServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServer.Location = new System.Drawing.Point(3, 183);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(129, 23);
            this.btnServer.TabIndex = 18;
            this.btnServer.Text = "Start Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnWebServer_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Custom IP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 30);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Custom Port";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Local IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Global IP:";
            // 
            // val_localIP
            // 
            this.val_localIP.AutoSize = true;
            this.val_localIP.Location = new System.Drawing.Point(84, 51);
            this.val_localIP.Name = "val_localIP";
            this.val_localIP.Size = new System.Drawing.Size(35, 13);
            this.val_localIP.TabIndex = 23;
            this.val_localIP.Text = "label4";
            // 
            // val_extIP
            // 
            this.val_extIP.AutoSize = true;
            this.val_extIP.Location = new System.Drawing.Point(87, 72);
            this.val_extIP.Name = "val_extIP";
            this.val_extIP.Size = new System.Drawing.Size(35, 13);
            this.val_extIP.TabIndex = 24;
            this.val_extIP.Text = "label4";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(622, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Logger";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.panel1.Controls.Add(this.btnOutputFolder);
            this.panel1.Controls.Add(this.btnStartStopLogging);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 567);
            this.panel1.TabIndex = 20;
            // 
            // btnStartStopLogging
            // 
            this.btnStartStopLogging.Enabled = false;
            this.btnStartStopLogging.Location = new System.Drawing.Point(6, 86);
            this.btnStartStopLogging.Name = "btnStartStopLogging";
            this.btnStartStopLogging.Size = new System.Drawing.Size(129, 23);
            this.btnStartStopLogging.TabIndex = 0;
            this.btnStartStopLogging.Text = "Start";
            this.btnStartStopLogging.UseVisualStyleBackColor = true;
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(6, 4);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(59, 23);
            this.btnOutputFolder.TabIndex = 8;
            this.btnOutputFolder.Text = "Ändern";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            // 
            // btnFilename
            // 
            this.btnFilename.Location = new System.Drawing.Point(6, 33);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(59, 23);
            this.btnFilename.TabIndex = 12;
            this.btnFilename.Text = "Ändern";
            this.btnFilename.UseVisualStyleBackColor = true;
            // 
            // val_lblUsedInterval
            // 
            this.val_lblUsedInterval.AutoSize = true;
            this.val_lblUsedInterval.Location = new System.Drawing.Point(112, 153);
            this.val_lblUsedInterval.Name = "val_lblUsedInterval";
            this.val_lblUsedInterval.Size = new System.Drawing.Size(34, 13);
            this.val_lblUsedInterval.TabIndex = 11;
            this.val_lblUsedInterval.Text = "UNIN";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(67, 39);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(66, 13);
            this.lblFilename.TabIndex = 13;
            this.lblFilename.Text = "Datei Name:";
            // 
            // lblUsedInterval
            // 
            this.lblUsedInterval.AutoSize = true;
            this.lblUsedInterval.Location = new System.Drawing.Point(3, 153);
            this.lblUsedInterval.Name = "lblUsedInterval";
            this.lblUsedInterval.Size = new System.Drawing.Size(90, 13);
            this.lblUsedInterval.TabIndex = 10;
            this.lblUsedInterval.Text = "Log Intervall (ms):";
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(67, 9);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(77, 13);
            this.lblOutputFolder.TabIndex = 14;
            this.lblOutputFolder.Text = "Output Ordner:";
            // 
            // val_lblLogCount
            // 
            this.val_lblLogCount.AutoSize = true;
            this.val_lblLogCount.Location = new System.Drawing.Point(112, 135);
            this.val_lblLogCount.Name = "val_lblLogCount";
            this.val_lblLogCount.Size = new System.Drawing.Size(34, 13);
            this.val_lblLogCount.TabIndex = 9;
            this.val_lblLogCount.Text = "UNIN";
            // 
            // val_lblOutputFolder
            // 
            this.val_lblOutputFolder.AutoSize = true;
            this.val_lblOutputFolder.Location = new System.Drawing.Point(141, 9);
            this.val_lblOutputFolder.Name = "val_lblOutputFolder";
            this.val_lblOutputFolder.Size = new System.Drawing.Size(35, 13);
            this.val_lblOutputFolder.TabIndex = 15;
            this.val_lblOutputFolder.Text = "label2";
            // 
            // lblLogCount
            // 
            this.lblLogCount.AutoSize = true;
            this.lblLogCount.Location = new System.Drawing.Point(3, 135);
            this.lblLogCount.Name = "lblLogCount";
            this.lblLogCount.Size = new System.Drawing.Size(81, 13);
            this.lblLogCount.TabIndex = 3;
            this.lblLogCount.Text = "Logged Entries:";
            // 
            // val_lblFilename
            // 
            this.val_lblFilename.AutoSize = true;
            this.val_lblFilename.Location = new System.Drawing.Point(140, 39);
            this.val_lblFilename.Name = "val_lblFilename";
            this.val_lblFilename.Size = new System.Drawing.Size(35, 13);
            this.val_lblFilename.TabIndex = 16;
            this.val_lblFilename.Text = "label2";
            // 
            // numLogInterval
            // 
            this.numLogInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLogInterval.Location = new System.Drawing.Point(115, 172);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log Intervall in ms";
            // 
            // ckbWriteTitle
            // 
            this.ckbWriteTitle.AutoSize = true;
            this.ckbWriteTitle.Location = new System.Drawing.Point(6, 63);
            this.ckbWriteTitle.Name = "ckbWriteTitle";
            this.ckbWriteTitle.Size = new System.Drawing.Size(128, 17);
            this.ckbWriteTitle.TabIndex = 5;
            this.ckbWriteTitle.Text = "Überschrift Schreiben";
            this.ckbWriteTitle.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabData.Controls.Add(this.tabPage1);
            this.tabData.Controls.Add(this.tabPage3);
            this.tabData.Controls.Add(this.tabPage4);
            this.tabData.Controls.Add(this.tabPage5);
            this.tabData.Location = new System.Drawing.Point(12, 12);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Drawing.Point(0, 0);
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(630, 597);
            this.tabData.TabIndex = 23;
            // 
            // LoggerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 635);
            this.Controls.Add(this.tabData);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(670, 620);
            this.Name = "LoggerDlg";
            this.Text = "Fräse Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoggerDlg_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogInterval)).EndInit();
            this.tabData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableData;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb_LogOutput;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label val_extIP;
        private System.Windows.Forms.Label val_localIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbWriteTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numLogInterval;
        private System.Windows.Forms.Label val_lblFilename;
        private System.Windows.Forms.Label lblLogCount;
        private System.Windows.Forms.Label val_lblOutputFolder;
        private System.Windows.Forms.Label val_lblLogCount;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Label lblUsedInterval;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label val_lblUsedInterval;
        private System.Windows.Forms.Button btnFilename;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.Button btnStartStopLogging;
        private System.Windows.Forms.TabControl tabData;
    }
}