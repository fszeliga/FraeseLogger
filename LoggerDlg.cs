using De.Boenigk.SMC5D.Basics;
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
        private LoggerInstance li = LoggerInstance.Instance;

        public LoggerDlg()
        {
            InitializeComponent();

            val_lblOutputFolder.Text = li.LogFileDir;
            val_lblFilename.Text = li.log_filename;

            timer.Start();
            LoggerInstance.Instance.logInterval = Convert.ToInt32(numLogInterval.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoggerInstance.Instance.readFromCNC();
            val_lblLogCount.Text = li.logCount.ToString();
            val_lblUsedInterval.Text = li.logInterval.ToString();

            val_lblSN.Text = li.serialNr;
            val_lblFirmware.Text = li.firmware;

            val_lblActiveProg.Text = li.ActiveProg;

            if (li.DoorOpen) val_lblDoorStatus.Text = "Auf";
            else val_lblDoorStatus.Text = "Zu";

            if (li.SpindleOn) val_lblSpindleStatus.Text = "Spindel ist an";
            else val_lblSpindleStatus.Text = "Spindel ist aus";

            val_lblCutSpeed.Text = li.CutSpeed;
            val_lblMaxCutSpeed.Text = li.MaxCutSpeed;
            val_lblFeedRate.Text = li.Vorschub + li.VorschubEinheit;

            val_lblStartTime.Text = li.StartTime;
            val_lblEndTime.Text = li.EndTIme;

            lblStatus.Text = li.loggerStatus;
                       
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (LoggerInstance.Instance.logThreadRunning)
            {
                //stop logging
                li.logThreadRunning = false;
                btnStartStopLogging.Text = "Start Logging";
            }
            else
            {                
                //start logging
                LoggerInstance.Instance.logThreadRunning = true;
                LoggerFileWriter log = new LoggerFileWriter(ckbWriteTitle.Checked);
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
                li.LogFileDir = folderBrowserDialog1.SelectedPath;
                val_lblOutputFolder.Text = li.LogFileDir;
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
    }
}
