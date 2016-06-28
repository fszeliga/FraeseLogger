using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using System.IO;

namespace FraeseLogger
{
    public class LoggerInstance
    {
        private static LoggerInstance instance;
        private Connector myConn;
        private De.Boenigk.Utility.CNC.Info.MachInfo machInfo;
         
        private LoggerInstance() {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory;// Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            LogFileDir = appPath + "Live Log Files\\";
            try
            {
                if (!Directory.Exists(LogFileDir))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(LogFileDir);
                }
            }
            catch (IOException ioex)
            {
                loggerStatus = ioex.Message;
            }
            log_filename = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".txt";
        }

        public static LoggerInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggerInstance();
                }
                return instance;
            }
        }

        /*
         * Start LoggerInstance Class
         */
        public int logInterval { get; set; }
        public String LogFileDir { get; set; }
        public String serialNr { get; private set; }
        public String firmware { get; private set; }
        public double volt1 { get; private set; }
        public double volt2 { get; private set; }
        private String activeProg;
        private bool doorOpen;
        private bool spindleOn;
        private String cutSpeed;
        private String maxCutSpeed;
        private String vorschubEinheit;
        private String vorschub;
        private String worktime = "todo";
        private String startTime;
        private String endTIme;
        private String endschalter = "todo";
        public bool heightSensorActive { get; set; }


        public int logCount { get; set; }
        public bool logThreadRunning { get; set; }
        public String log_filename { get; set; }
        public String loggerStatus { get; set; }

        public void readFromCNC()
        {
            serialNr = myConn.SN;
            firmware = myConn.FirmwareVersion.ToString();
            volt1 = myConn.AD1Volt;
            volt2 = myConn.AD2Volt;
            activeProg = machInfo.FileName;
            doorOpen = myConn.IsHoodOpen();
            spindleOn = myConn.IsSpindleOn();
            cutSpeed = myConn.CurrentSpeed.ToString();
            maxCutSpeed = myConn.MaxSpeed.ToString();
            if (machInfo.JobInfo.SpeedUnitMMMinute) vorschubEinheit = "mm/m";
            else vorschubEinheit = "mm/s";

            vorschub = machInfo.JobInfo.JobSpeed.ToString();

            if (machInfo.JobInfo.StartJobTimeTicks > 0)
            {
                startTime = new DateTime(machInfo.JobInfo.StartJobTimeTicks).ToLongDateString() + " " + new DateTime(machInfo.JobInfo.StartJobTimeTicks).ToLongTimeString();
            }
            else
            {
                startTime = "?";
            }

            if (machInfo.JobInfo.EndJobTimeTicks > 0)
            {
                endTIme = new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongDateString() + " " + new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongTimeString();
            }
            else
            {
                endTIme = "?";
            }
        }

        public Connector Connector
        {
            get
            {
                return myConn;
            }
            set
            {
                myConn = value;
            }
        }
        public MachInfo MachInfo
        {
            get
            {
                return machInfo;
            }

            set
            {
                machInfo = value;
            }
        }

        public string ActiveProg
        {
            get
            {
                return activeProg;
            }

            set
            {
                activeProg = value;
            }
        }

        public bool DoorOpen
        {
            get
            {
                return doorOpen;
            }

            set
            {
                doorOpen = value;
            }
        }

        public bool SpindleOn
        {
            get
            {
                return spindleOn;
            }

            set
            {
                spindleOn = value;
            }
        }

        public string CutSpeed
        {
            get
            {
                return cutSpeed;
            }

            set
            {
                cutSpeed = value;
            }
        }

        public string MaxCutSpeed
        {
            get
            {
                return maxCutSpeed;
            }

            set
            {
                maxCutSpeed = value;
            }
        }

        public string Vorschub
        {
            get
            {
                return vorschub;
            }

            set
            {
                vorschub = value;
            }
        }

        public string Worktime
        {
            get
            {
                return worktime;
            }

            set
            {
                worktime = value;
            }
        }

        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public string EndTIme
        {
            get
            {
                return endTIme;
            }

            set
            {
                endTIme = value;
            }
        }

        public string Endschalter
        {
            get
            {
                return endschalter;
            }

            set
            {
                endschalter = value;
            }
        }

        public string VorschubEinheit
        {
            get
            {
                return vorschubEinheit;
            }

            set
            {
                vorschubEinheit = value;
            }
        }
    }
}
