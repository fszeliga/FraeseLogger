using imi_cnc_logger;
using imi_cnc_logger.log_comp;
using imi_cnc_logger.log_comp.data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FraeseLogger
{
    public partial class LoggerDlg : Form
    {

        private LoggerManager _l = LoggerManager.THE();
        private bool toggleState = false; // false means log none
        private List<Label> dataLabels = new List<Label>();
        private List<CheckBox> dataCheckboxes = new List<CheckBox>();

        //used for starting/stopping webserver
        private bool serverRunning = false;

        public LoggerDlg()
        {
            InitializeComponent();

            LoggerSettings.Instance().logInterval = Convert.ToInt32(numLogInterval.Value);

            tableData.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableData.AutoSize = true;
            tableData.AutoSizeMode = AutoSizeMode.GrowOnly;

            TableLayoutRowStyleCollection styles = tableData.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 20;
            }

            string[] keys = LoggerManager.THE().getAllKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                LoggerManager.THE().addLog("added key: " + keys[i]);
                Label l = createLabel(keys[i]);
                dataLabels.Add(l);
                tableData.Controls.Add(createLabel(keys[i]), 0, i);
                tableData.Controls.Add(l, 1, i);
                CheckBox c = createCheckbox(keys[i]);
                dataCheckboxes.Add(c);
                tableData.Controls.Add(c, 2, i);
            }

            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SuspendLayout();
            LoggerManager.THE().readFromCNC();

            LogEvent ev = LoggerManager.THE().getCurrentLogEvent();
            foreach (Label l in dataLabels)
            {
                l.Text = ev.getValueByKey(l.Tag.ToString());
            }

            while (LoggerManager.THE().logsQueued())
            {
                lb_LogOutput.Items.Add(LoggerManager.THE().popLog());
            }

            val_localIP.Text = Utils.GetLocalIPAddress();
            val_extIP.Text = Utils.GetGlobalIPAddress();

            //File Logger Tab
            val_lblUsedInterval.Text = LoggerSettings.Instance().logInterval.ToString();
            lblLogCount.Text = LoggerSettings.Instance().loggedEntriesCount.ToString();
            ResumeLayout();
        }

        private Label createLabel(string tag)
        {
            Label l = new Label();
            l.Text = tag;
            l.Tag = tag;
            l.AutoSize = true;
            return l;
        }

        private CheckBox createCheckbox(string key)
        {
            CheckBox c = new CheckBox();
            c.Tag = key;
            c.Checked = true;
            c.CheckedChanged += (s, e) => LoggerManager.THE().setLogEntry(key, (s as CheckBox).Checked);
            return c;
        }

        private void numLogInterval_ValueChanged(object sender, EventArgs e)
        {
            LoggerSettings.Instance().logInterval = Convert.ToInt32(numLogInterval.Value);
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
        }
       
        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LoggerSettings.Instance().logFiledir = folderBrowserDialog1.SelectedPath + "\\";
                val_lblOutputFolder.Text = LoggerSettings.Instance().logFiledir;
                btnStartStopLogging.Enabled = true;
            }
        }

        private void btnStartStopLogging_Click(object sender, EventArgs e)
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
                LoggerSettings.Instance().logThreadRunning = true;
                LoggerFileWriter log = new LoggerFileWriter(ckbWriteTitle.Checked);

                Thread logThread = new Thread(new ThreadStart(log.logCNC));
                logThread.IsBackground = true;
                logThread.Start();
                btnStartStopLogging.Text = "Stop Logging";
            }
        }

        private void checkLogSelectionEnabled(bool v)
        {
            foreach (CheckBox checkBox in dataCheckboxes) checkBox.Enabled = v;
        }
        
    }
}
