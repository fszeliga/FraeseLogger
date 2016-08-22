using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using System.IO;
using System.Threading;
using imi_cnc_logger.WebServer;

namespace imi_cnc_logger
{
    public class LoggerData
    {
        private static LoggerData instance;
        private Connector myConn;
        private MachInfo myMachInfo;


        public energenie energy { get; private set; } = null;

        private LoggerData()
        {
        }

        public static LoggerData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggerData();
                }
                return instance;
            }
        }
        
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
        //public String activeProg { get; private set; } = "NA";
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
        public String endTime { get; private set; }
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

        public void init(Connector con, MachInfo mi)
        {
            myConn = con;
            myMachInfo = mi;

            LogFileDir = "Wähle einen Output Ordner!";
            log_filename = DateTime.Now.ToString("yyyy-dd-M-HH:mm:ss") + ".txt";

            serialNr = "";
            firmware = "";
            volt1 = 0.0;
            volt2 = 0.0;
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
            endTime = "?";
            endschalterX = false;
            endschalterY = false;
            endschalterZ = false;
            gCode = "";
            gCodeLine = 0;
            positions.X = 0;
            positions.Y = 0;
            positions.Z = 0;

            energy = new energenie(System.Net.IPAddress.Parse("127.0.0.1"));
            //threadEnergenie = new Thread(new ThreadStart(energy.start));
            //threadEnergenie.Start();
        }

        public void readFromCNC()
        {
            return;
            if (myConn == null) return;
            serialNr = myConn.SN;
            firmware = myConn.FirmwareVersion.ToString();
            
            //activeProg = myMachInfo.FileName;
            doorOpen = myConn.IsHoodOpen();
            spindleOn = myConn.IsSpindleOn();
            Switch theSwitch = new Switch(myConn);
            endschalterX = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisX.ReferencePinNumber), false);
            endschalterY = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisY.ReferencePinNumber), false);
            endschalterZ = theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisZ.ReferencePinNumber), false);
            if (myMachInfo.JobInfo.StartJobTimeTicks > 0)
            {
                startDateTime = new DateTime(myMachInfo.JobInfo.StartJobTimeTicks); //save DateTime object for calculations
                worktime = DateTime.Now.Subtract(startDateTime);
                startTime = startDateTime.ToLongDateString() + " " + startDateTime.ToLongTimeString(); // human readable start time
            }
            else
            {
                startTime = "?";
                worktime = new TimeSpan(0);
            }
            if (myMachInfo.JobInfo.EndJobTimeTicks > 0)
            {
                endTime = new DateTime(myMachInfo.JobInfo.EndJobTimeTicks).ToLongDateString() + " " + new DateTime(myMachInfo.JobInfo.EndJobTimeTicks).ToLongTimeString();
            }
            else
            {
                endTime = "?";
            }
            if (myMachInfo.JobInfo != null) vorschub = myMachInfo.JobInfo.JobSpeed.ToString();
            else vorschub = "?";
            if (myMachInfo.JobInfo.SpeedUnitMMMinute) vorschubEinheit = "mm/m";
            else vorschubEinheit = "mm/s";
            
            cutSpeed = myConn.CurrentSpeed.ToString();
            maxCutSpeed = myConn.MaxSpeed.ToString();
            if (myConn.SMCSettings.HeightSensor.MeasureToolPin == Input.Default)
            {
                heightSensorActive = false;
            }
            else
            {
                heightSensorActive = true;
            }
            
            if ((myConn.Job != null) && (myConn.Job.GetCurrent() != null))
            {
                freilauf = !myConn.Job.GetCurrent().Down;
            }
            else
            {
                freilauf = true;
            }
            
            gCode = myMachInfo.JobInfo.GCode;
            gCodeLine = myMachInfo.JobInfo.GCodeLine;

            positions.X = StepCalc.GetMMX(myConn);
            positions.Y = StepCalc.GetMMY(myConn);
            positions.Z = StepCalc.GetMMZ(myConn);
            try
            {
                if ((myConn.Job != null) && (myConn.Job.GetCurrent() != null))
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
                LoggerManger.THE().pushLog(e.Message);
                spindlespeed = 0;
            }
            volt1 = myConn.AD1Volt;
            volt2 = myConn.AD2Volt;
        

            
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


        public bool logFreilauf { get; internal set; }
        public bool logGCode { get; internal set; }
        public bool logPositions { get; internal set; }
        public bool logSpindleSpeed { get; internal set; }
        public bool logSpannung { get; internal set; }

        public void stoplogger()
        {

            //energy.stop();
            //threadHTTP.Abort();
        }
    }
}
