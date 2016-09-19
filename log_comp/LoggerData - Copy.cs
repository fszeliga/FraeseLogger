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
        
        //public String activeProg { get; private set; } = "NA";
        public bool freilauf { get; private set; }
        public String cutSpeed { get; private set; }
        public String maxCutSpeed { get; private set; }
        public String vorschubEinheit { get; private set; }
        public String vorschub { get; private set; }
        public TimeSpan worktime { get; private set; }
        public String startTime { get; private set; }
        public DateTime startDateTime { get; private set; }
        public String endTime { get; private set; }
        public double spindlespeed { get; private set; }
        public bool heightSensorActive { get; private set; }
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

            energy = new energenie(System.Net.IPAddress.Parse("127.0.0.1"));
            //threadEnergenie = new Thread(new ThreadStart(energy.start));
            //threadEnergenie.Start();
        }

        public void readFromCNC()
        {
            return;
            if (myConn == null) return;
            
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
