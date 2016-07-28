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
        private MachInfo machInfo;

        private LoggerInstance()
        {
            //string appPath = AppDomain.CurrentDomain.BaseDirectory;
            LogFileDir = "Wähle einen Output Ordner!";//= appPath + "Live Log Files\\";
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
        public struct globPos
        {
            private int xVal, yVal, zVal;
            public int X
            {
                get
                {
                    return xVal;
                }
                set
                {
                    xVal = value;
                }
            }
            public int Y
            {
                get
                {
                    return yVal;
                }
                set
                {
                    if (value < 100)
                        yVal = value;
                }
            }
            public int Z
            {
                get
                {
                    return zVal;
                }
                set
                {
                    zVal = value;
                }
            }
            public globPos(int x1, int y1, int z1)
            {
                xVal = x1;
                yVal = y1;
                zVal = z1;
            }

            public string toString()
            {
                return X + " | " + Y + " | " + Z;
            }
        }

        public String gCode { get; private set; }
        public int gCodeLine { get; private set; }
        public double volt1 { get; private set; }
        public double volt2 { get; private set; }
        public String activeProg { get; private set; }
        public bool doorOpen { get; private set; }
        public bool spindleOn { get; private set; }
        public bool freilauf { get; private set; }
        public String cutSpeed { get; private set; }
        public String maxCutSpeed { get; private set; }
        public String vorschubEinheit { get; private set; }
        public String vorschub { get; private set; }
        public TimeSpan worktime { get; private set; }
        public String startTime { get; private set; }
        public DateTime startDateTime { get; private set; }
        public String endTIme { get; private set; }
        public bool endschalterX { get; private set; }
        public bool endschalterY { get; private set; }
        public bool endschalterZ { get; private set; }
        public double spidlespeed { get; private set; }
        public bool heightSensorActive { get; private set; }
        public globPos positions = new globPos();
        public int logInterval { get; set; }
        public String LogFileDir { get; set; }
        public String serialNr { get; private set; }
        public String firmware { get; private set; }
        public int logCount { get; set; }
        public bool logThreadRunning { get; set; }
        public String log_filename { get; set; }
        public String loggerStatus { get; private set; }
        public String statusMSG { get; private set; }

        public void readFromCNC()
        {
            statusMSG = "";
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

            if (myConn.Job != null)
            {
                freilauf = !myConn.Job.GetCurrent().Down;
                spidlespeed = myConn.Job.GetCurrent().SpindleSpeed;
            }
            else
            {
                freilauf = true;
                spidlespeed = 0;
            }

            vorschub = machInfo.JobInfo.JobSpeed.ToString();

            if (myConn.SMCSettings.HeightSensor.MeasureToolPin == Input.Default)
            {
                heightSensorActive = false;
            }
            else
            {
                heightSensorActive = true;
            }

            if (machInfo.JobInfo.StartJobTimeTicks > 0)
            {
                startDateTime = new DateTime(machInfo.JobInfo.StartJobTimeTicks); //save DateTime object for calculations
                worktime = DateTime.Now.Subtract(startDateTime);
                startTime = startDateTime.ToLongDateString() + " " + startDateTime.ToLongTimeString(); // human readable start time
            }
            else
            {
                startTime = "?";
                worktime = new TimeSpan(0);
            }

            if (machInfo.JobInfo.EndJobTimeTicks > 0)
            {
                endTIme = new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongDateString() + " " + new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongTimeString();
            }
            else
            {
                endTIme = "?";
            }

            Switch theSwitch = new Switch(myConn);
            endschalterX = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisX.ReferencePinNumber), false);
            endschalterY = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisY.ReferencePinNumber), false);
            endschalterZ = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisZ.ReferencePinNumber), false);

            gCode = machInfo.JobInfo.GCode;
            gCodeLine = machInfo.JobInfo.GCodeLine;

            positions.X = myConn.GlobPosition.X;
            positions.Y = myConn.GlobPosition.Y;
            positions.Z = myConn.GlobPosition.Z;

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
    }
}
