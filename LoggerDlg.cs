using De.Boenigk.SMC5D.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            timer.Start();
            LoggerInstance.Instance.logInterval = Convert.ToInt32(numLogInterval.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoggerInstance.Instance.readFromCNC();
            lblLogCount.Text = li.logCount.ToString();
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
            
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (LoggerInstance.Instance.logThreadRunning)
            {
                //stop logging
                LoggerInstance.Instance.logThreadRunning = false;
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
            LoggerInstance.Instance.logInterval = Convert.ToInt32(numLogInterval.Value);
        }
    }
}
