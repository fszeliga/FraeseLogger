using De.Boenigk.SMC5D.Basics;
using imi_cnc_logger;
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
        private LoggerData li = LoggerData.Instance;
        private bool toggleState = false; // false means log none
        CheckBox[] _checkBoxes;

        public LoggerDlg()
        {
            InitializeComponent();
            
            val_lblOutputFolder.Text = li.LogFileDir;
            val_lblFilename.Text = li.log_filename;

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
            LoggerData.Instance.logInterval = Convert.ToInt32(numLogInterval.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoggerData.Instance.readFromCNC();
            val_lblLogCount.Text = li.logCount.ToString();
            val_lblUsedInterval.Text = li.logInterval.ToString();

            val_lblSN.Text = li.serialNr;
            val_lblFirmware.Text = li.firmware;

            //val_lblActiveProg.Text = LoggerManager.THE().getLastEvent().activeProg;

            if (li.doorOpen) val_lblDoorStatus.Text = "Auf";
            else val_lblDoorStatus.Text = "Zu";

            if (li.spindleOn) val_lblSpindleStatus.Text = "Spindel ist an";
            else val_lblSpindleStatus.Text = "Spindel ist aus";

            val_lblCutSpeed.Text = li.cutSpeed;
            val_lblMaxCutSpeed.Text = li.maxCutSpeed;
            val_lblFeedRate.Text = li.vorschub + li.vorschubEinheit;
            val_lblWorktime.Text = li.worktime.ToString();
            val_lblStartTime.Text = li.startTime;
            val_lblEndTime.Text = li.endTime;

            val_lblHeightSensorActive.Text = li.heightSensorActive.ToString();

            val_lblFreilauf.Text = li.freilauf.ToString();

            val_lblEndschalter.Text = li.endschalterX + " | " + li.endschalterY + " | " + li.endschalterZ;
            val_lblGCode.Text = li.gCodeLine + " | " + li.gCode;
            val_lblPositions.Text = li.positions.toString();
            val_lblSpindlespeed.Text = li.spindlespeed.ToString();

            val_lblSpannung.Text = li.volt1.ToString() + " | " + li.volt2.ToString();

            val_lblEnergy.Text = LoggerManager.THE().energy.data2String("   ", false, true);

            while (LoggerManager.THE().logsQueued())
            {
                lb_LogOutput.Items.Add(LoggerManager.THE().popLog());
            }

            val_localIP.Text = Utils.GetLocalIPAddress();
            val_extIP.Text = Utils.GetGlobalIPAddress();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (LoggerData.Instance.logThreadRunning)
            {
                checkLogSelectionEnabled(true);//enable all log selection checkboxes
                //stop logging
                li.logThreadRunning = false;
                btnStartStopLogging.Text = "Start Logging";
            }
            else
            {
                //start logging

                checkLogSelectionEnabled(false);//disable all log selection checkboxes
                LoggerData.Instance.logThreadRunning = true;
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

                LoggerData.Instance.logActiveProg = this.cb_lblActiveProg.Checked;
                LoggerData.Instance.logDoorStatus = this.cb_lblDoorStatus.Checked;
                LoggerData.Instance.logSpindleStatus = this.cb_lblSpindleStatus.Checked;
                LoggerData.Instance.logEndschalter = this.cb_lblEndschalter.Checked;
                LoggerData.Instance.logStartTime = this.cb_lblStartTime.Checked;
                LoggerData.Instance.logEndTime = this.cb_lblEndTime.Checked;
                LoggerData.Instance.logWorktime = this.cb_lblWorktime.Checked;
                LoggerData.Instance.logFeedRate = this.cb_lblFeedRate.Checked;
                LoggerData.Instance.logCutSpeed = this.cb_lblCutSpeed.Checked;
                LoggerData.Instance.logMaxCutSpeed = this.cb_lblMaxCutSpeed.Checked;
                LoggerData.Instance.logHeightSensorActive = this.cb_lblHeightSensorActive.Checked;
                LoggerData.Instance.logFreilauf = this.cb_lblFreilauf.Checked;
                LoggerData.Instance.logGCode = this.cb_lblGCode.Checked;
                LoggerData.Instance.logPositions = this.cb_lblPositions.Checked;
                LoggerData.Instance.logSpindleSpeed = this.cb_lblSpindlespeed.Checked;
                LoggerData.Instance.logSpannung = this.cb_lblSpannung.Checked;

                Thread logThread = new Thread(new ThreadStart(log.logCNC));
                logThread.Start();
                btnStartStopLogging.Text = "Stop Logging";
            }
        }

        private void numLogInterval_ValueChanged(object sender, EventArgs e)
        {
            li.logInterval = Convert.ToInt32(numLogInterval.Value);
        }

        private void lblOutputFolderPicker_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                li.LogFileDir = folderBrowserDialog1.SelectedPath + "\\";
                val_lblOutputFolder.Text = li.LogFileDir;
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
            String value = li.log_filename;
            if (InputBox("Output Datei Name", "Änder Sie hier den Dateiname:", ref value) == DialogResult.OK)
            {
                li.log_filename = value;
                val_lblFilename.Text = li.log_filename;
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
            LoggerManager.THE().stop();
            LoggerData.Instance.stoplogger();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggerManager.THE().readFromCNC();
        }
    }
}
