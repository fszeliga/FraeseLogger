using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using System.IO;
using System.Threading;

namespace FraeseLogger
{
    public class LoggerInstance
    {
        private static LoggerInstance instance;
        private Connector myConn;
        private MachInfo machInfo;

        private HttpServer httpServer = new MyHttpServer("127.0.0.1", 5454);
        Thread thread = null;

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
            private double xVal, yVal, zVal;
            public double X
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
            public double Y
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
            public double Z
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
            public globPos(double x1, double y1, double z1)
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
        public double spindlespeed { get; private set; }
        public bool heightSensorActive { get; private set; }
        public globPos positions = new globPos();
        public int logInterval { get; set; }
        public String LogFileDir { get; set; }
        public String serialNr { get; private set; }
        public String firmware { get; private set; }
        public int logCount { get; set; }
        public bool logThreadRunning { get; set; }
        public String log_filename { get; set; }
        public String statusMSG { get; set; }

        public void init()
        {
            statusMSG = "";
            serialNr = "";
            firmware = "";
            volt1 = 0.0;
            volt2 = 0.0;
            activeProg = "";
            doorOpen = false;
            spindleOn = false;
            cutSpeed = "";
            maxCutSpeed = "";
            vorschubEinheit = "";
            freilauf = false;
            spindlespeed = 0.0;
            vorschub = "";
            heightSensorActive = false;
            startDateTime = DateTime.Now; //save DateTime object for calculations
            startTime = "?";
            worktime = new TimeSpan(0);
            endTIme = "?";
            endschalterX = false;
            endschalterY = false;
            endschalterZ = false;
            gCode = "";
            gCodeLine = 0;
            positions.X = 0;
            positions.Y = 0;
            positions.Z = 0;
        }

        public void readFromCNC()
        {
            if (myConn == null) return;
            serialNr = myConn.SN;
            firmware = myConn.FirmwareVersion.ToString();

            if (logActiveProg)
            {
                activeProg = machInfo.FileName;
            }
            if (logDoorStatus)
            {
                doorOpen = myConn.IsHoodOpen();
            }
            if (logSpindleStatus)
            {
                spindleOn = myConn.IsSpindleOn();
            }
            if (logEndschalter)
            {
                Switch theSwitch = new Switch(myConn);
                endschalterX = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisX.ReferencePinNumber), false);
                endschalterY = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisY.ReferencePinNumber), false);
                endschalterZ = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisZ.ReferencePinNumber), false);
            }
            if (logStartTime)
            {
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
            }
            if (logEndTime)
            {
                if (machInfo.JobInfo.EndJobTimeTicks > 0)
                {
                    endTIme = new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongDateString() + " " + new DateTime(machInfo.JobInfo.EndJobTimeTicks).ToLongTimeString();
                }
                else
                {
                    endTIme = "?";
                }
            }
            if (logFeedRate)
            {
                if (machInfo.JobInfo != null) vorschub = machInfo.JobInfo.JobSpeed.ToString();
                else vorschub = "?";
                if (machInfo.JobInfo.SpeedUnitMMMinute) vorschubEinheit = "mm/m";
                else vorschubEinheit = "mm/s";
            }
            if (logCutSpeed)
            {
                cutSpeed = myConn.CurrentSpeed.ToString();
            }
            if (logMaxCutSpeed)
            {
                maxCutSpeed = myConn.MaxSpeed.ToString();
            }
            if (logHeightSensorActive)
            {
                if (myConn.SMCSettings.HeightSensor.MeasureToolPin == Input.Default)
                {
                    heightSensorActive = false;
                }
                else
                {
                    heightSensorActive = true;
                }
            }
            if (logFreilauf)
            {
                if (myConn.Job != null)
                {
                    //freilauf = !myConn.Job.GetCurrent().Down;
                }
                else
                {
                    //freilauf = true;
                }
            }
            if (logGCode)
            {
                gCode = machInfo.JobInfo.GCode;
                gCodeLine = machInfo.JobInfo.GCodeLine;
            }
            if (logPositions)
            {
                positions.X = StepCalc.GetMMX(myConn);
                positions.Y = StepCalc.GetMMY(myConn);
                positions.Z = StepCalc.GetMMZ(myConn);
            }
            if (logSpindleSpeed)
            {
                //spindlespeed = 0.0;
                try
                {
                    if (myConn.Job != null)
                    {
                    spindlespeed = myConn.Job.GetCurrent().SpindleSpeed;
                    }
                    else
                    {
                        spindlespeed = 0;
                    }
                }
                catch (Exception e)
                {
                    statusMSG = e.Message;
                    spindlespeed = 0;
                }

            }
            if (logSpannung)
            {
                volt1 = myConn.AD1Volt;
                volt2 = myConn.AD2Volt;
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

        public bool logActiveProg { get; internal set; }
        public bool logDoorStatus { get; internal set; }
        public bool logSpindleStatus { get; internal set; }
        public bool logEndschalter { get; internal set; }
        public bool logStartTime { get; internal set; }
        public bool logEndTime { get; internal set; }
        public bool logWorktime { get; internal set; }
        public bool logFeedRate { get; internal set; }
        public bool logCutSpeed { get; internal set; }
        public bool logMaxCutSpeed { get; internal set; }
        public bool logHeightSensorActive { get; internal set; }

        internal void setHTTPServer(bool serverRunning)
        {
            if(thread == null)
            {
                thread = new Thread(new ThreadStart(httpServer.listen));
                thread.Start();
                return;
            }
            
            if (serverRunning)
            {
                thread.Resume();
            }
            else
            {
                thread.Suspend();
            }
        }

        public bool logFreilauf { get; internal set; }
        public bool logGCode { get; internal set; }
        public bool logPositions { get; internal set; }
        public bool logSpindleSpeed { get; internal set; }
        public bool logSpannung { get; internal set; }
    }
}
