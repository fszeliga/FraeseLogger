using De.Boenigk.SMC5D.Basics;
using imi_cnc_logger;
using imi_cnc_logger.log_comp;
using imi_cnc_logger.log_comp.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FraeseLogger
{
    public partial class LoggerDlg : Form
    {
        //private De.Boenigk.Utility.CNC.Info.MachInfo myMachInfo;
        //private Connector myConnector;
        private LoggerManager _l = LoggerManager.THE();
        private bool toggleState = false; // false means log none
        CheckBox[] _checkBoxes;

        public LoggerDlg()
        {
            InitializeComponent();
            
            //val_lblOutputFolder.Text = li.LogFileDir;
            //val_lblFilename.Text = li.log_filename;

            _checkBoxes = new CheckBox[]{
                this.cb_lblActiveProg,
                this.cb_lblDoorStatus,
                this.cb_lblSpindleStatus,
                this.cb_lblEndschalter,
                this.cb_lblStartTime,
                this.cb_lblEndTime,
                this.cb_lblWorktime,
                this.cb_lblFeedRate,
                this.cb_lblCutSpeed,
                this.cb_lblMaxCutSpeed,
                this.cb_lblHeightSensorActive,
                this.cb_lblFreilauf,
                this.cb_lblGCode,
                this.cb_lblPositions,
                this.cb_lblSpindlespeed,
                this.cb_lblSpannung,
                this.cb_lblEnergy
            };

            timer.Start();
            LoggerSettings.Instance().logInterval = Convert.ToInt32(numLogInterval.Value);

            tableData.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableData.AutoSize = true;
            tableData.AutoSizeMode = AutoSizeMode.GrowOnly;

            TableLayoutRowStyleCollection styles = tableData.RowStyles;
            foreach (RowStyle style in styles)
            {
                // Set the row height to 20 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 20;
            }

            string[] keys = LoggerManager.THE().getAllKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                Label l = createLabel(keys[i]);
                dataLabels.Add(l);
                tableData.Controls.Add(createLabel(keys[i]), 0, i);
                tableData.Controls.Add(l, 1, i);
                CheckBox c = createCheckbox(keys[i]);
                tableData.Controls.Add(c, 2, i);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoggerManager.THE().readFromCNC();
            foreach (Label l in dataLabels)
            {
                LogEvent ev = LoggerManager.THE().getLastEvent();
                l.Text = ev.getValueByKey(l.Tag.ToString());
            }

            val_lblEnergy.Text = LoggerManager.THE().energy.data2String("   ", false, true);

            while (LoggerManager.THE().logsQueued())
            {
                lb_LogOutput.Items.Add(LoggerManager.THE().popLog());
            }

            val_localIP.Text = Utils.GetLocalIPAddress();
            val_extIP.Text = Utils.GetGlobalIPAddress();
        }

        private List<Label> dataLabels = new List<Label>();
        private Label createLabel(string tag)
        {
            Label l = new Label();
            l.Text = tag;
            l.Tag = tag;
            l.AutoSize = true;
            return l;
        }

        private List<CheckBox> dataCheckboxes = new List<CheckBox>();
        private CheckBox createCheckbox(string tag)
        {
            CheckBox c = new CheckBox();
            c.Tag = tag;
            c.CheckedChanged += (s, e) => LoggerManager.THE().addLog("cb: " + (s as CheckBox).Tag.ToString() + " | " + (s as CheckBox).Checked);
            return c;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (LoggerSettings.Instance().logThreadRunning)
            {
                checkLogSelectionEnabled(true);//enable all log selection checkboxes
                //stop logging
                LoggerSettings.Instance().logThreadRunning = false;
                btnStartStopLogging.Text = "Start Logging";
            }
            else
            {
                //start logging

                checkLogSelectionEnabled(false);//disable all log selection checkboxes
                LoggerSettings.Instance().logThreadRunning= true;
                LoggerFileWriter log = new LoggerFileWriter(ckbWriteTitle.Checked);

                log.logActiveProg = this.cb_lblActiveProg.Checked;
                log.logDoorStatus = this.cb_lblDoorStatus.Checked;
                log.logSpindleStatus = this.cb_lblSpindleStatus.Checked;
                log.logEndschalter = this.cb_lblEndschalter.Checked;
                log.logStartTime = this.cb_lblStartTime.Checked;
                log.logEndTime = this.cb_lblEndTime.Checked;
                log.logWorktime = this.cb_lblWorktime.Checked;
                log.logFeedRate = this.cb_lblFeedRate.Checked;
                log.logCutSpeed = this.cb_lblCutSpeed.Checked;
                log.logMaxCutSpeed = this.cb_lblMaxCutSpeed.Checked;
                log.logHeightSensorActive = this.cb_lblHeightSensorActive.Checked;
                log.logFreilauf = this.cb_lblFreilauf.Checked;
                log.logGCode = this.cb_lblGCode.Checked;
                log.logPositions = this.cb_lblPositions.Checked;
                log.logSpindleSpeed = this.cb_lblSpindlespeed.Checked;
                log.logSpannung = this.cb_lblSpannung.Checked;
                
                Thread logThread = new Thread(new ThreadStart(log.logCNC));
                logThread.Start();
                btnStartStopLogging.Text = "Stop Logging";
            }
        }

        private void numLogInterval_ValueChanged(object sender, EventArgs e)
        {
            LoggerSettings.Instance().logInterval = Convert.ToInt32(numLogInterval.Value);
        }

        private void lblOutputFolderPicker_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LoggerSettings.Instance().logFiledir = folderBrowserDialog1.SelectedPath + "\\";
                val_lblOutputFolder.Text = LoggerSettings.Instance().logFiledir;
                btnStartStopLogging.Enabled = true;
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void btnFilename_Click(object sender, EventArgs e)
        {
            String value = LoggerSettings.Instance().logFilename;
            if (InputBox("Output Datei Name", "Änder Sie hier den Dateiname:", ref value) == DialogResult.OK)
            {
                LoggerSettings.Instance().logFilename = value;
                val_lblFilename.Text = LoggerSettings.Instance().logFilename;
            }
        }

        private void btn_toggleAll_Click(object sender, EventArgs e)
        {
            if (toggleState)
            {
                checkLogSelectionToggle(false);//AllowDrop are on, so turn them off
                toggleState = false;//just turned all off
            }
            else
            {
                checkLogSelectionToggle(true);
                toggleState = true;//just turned all back on
            }
        }

        private void checkLogSelectionToggle(bool v)
        {
            foreach (var checkBox in _checkBoxes) checkBox.Checked = v;
        }
        
        private void checkLogSelectionEnabled(bool v)
        {
            foreach (var checkBox in _checkBoxes) checkBox.Enabled = v;
        }

        //used for starting/stopping webserver
        private bool serverRunning = false;
        private void btnWebServer_Click(object sender, EventArgs e)
        {
            LoggerManager.THE().setWebServerRunning(!serverRunning);
            serverRunning = !serverRunning;
            if (serverRunning) btnServer.Text = "Running...Stop";
            else btnServer.Text = "Start WebServer";
        }

        private void LoggerDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LoggerManager.THE().stop();
            //LoggerData.Instance.stoplogger();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggerManager.THE().readFromCNC();
        }
    }
}
