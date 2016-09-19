using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using imi_cnc_logger.log_comp;
using imi_cnc_logger.log_comp.data;
using imi_cnc_logger.WebServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace imi_cnc_logger
{
    public class LoggerManager
    {
        public Connector connector { get; private set; }
        public MachInfo machInfo { get; private set; }
        private CNCReader cncReader = null;
        private LoggerSettings setting = null;
        private List<LogEvent> data = new List<LogEvent>();
        private Queue<string> logs = new Queue<string>();
        private LogEvent currentLogEvent;
        private string[] possibleKeys;

        private DataTable dataTable = new DataTable("cncDataTabel");

        private Dictionary<string, bool> entriesToLog = new Dictionary<string, bool>();

        private HTTPServer webserver;
        private Thread webserver_thread = null;

        public energenie energy;
        private Thread threadEnergenie;

        private LoggerManager()
        {
        }

        /// <summary>
        /// Returns always the same instance of LoggerManager (singleton)
        /// </summary>
        /// <returns>static LoggerManger</returns>
        private static LoggerManager instance = null;

        public static LoggerManager THE()
        {
            if (instance == null)
                instance = new LoggerManager();
            return instance;
        }

        public void init(Connector c, MachInfo m)
        {
            this.cncReader = new CNCReader(c, m);
            setting = LoggerSettings.Instance();
            this.connector = c;
            this.machInfo = m;

                        
            currentLogEvent = new LogEvent(0);
            //possibleKeys = new LogEvent(0).data.Keys.ToArray();
            possibleKeys = currentLogEvent.data.Keys.ToArray();
            try
            {
                foreach (string s in possibleKeys) entriesToLog.Add(s, true);
            }
            catch (Exception e)
            {
                LoggerManager.THE().addLog(e.Message);
            }

            
        }

        public bool getLogEntry(string key)
        {
            try
            {
                return entriesToLog[key];
            }
            catch (KeyNotFoundException)
            {
                LoggerManager.THE().addLog("getLogEntry - key not found: " + key);
                return false;
            }
        }

        public void setLogEntry(string key, bool log)
        {
            try
            {
                entriesToLog[key] = log;
                LoggerManager.THE().addLog("setLogEntry - key: " + key + " - " + log);
            }
            catch (KeyNotFoundException)
            {
                LoggerManager.THE().addLog("setLogEntry - key not found: " + key);
            }
        }

        /// <summary>
        /// Read from CNC through connector etc.
        /// Throws CNCReaderNotInitialized Exception if you didnt not run init Method first!
        /// </summary>
        public void readFromCNC()
        {
            currentLogEvent.update();
            return;

            if (cncReader == null) throw new CNCReaderNotInitialized("You need to run init on LoggerManager first!");
            Tuple<bool, LogEvent> newData = cncReader.getNewData(currentLogEvent);
            lock (currentLogEvent)
            {
                currentLogEvent = newData.Item2;
            }
            //if (newData.Item1) data.Add(newData.Item2);
            //else LoggerManager.THE().pushLog("same data! not logging");
        }

        public LogEvent getCurrentLogEvent()
        {
            return currentLogEvent;
        }

        public void initDummy()
        {
            for(int i = 0; i < 1; i++)
            {
                data.Add(new LogEvent(i));
            }
        }

        public void addLog(string log)
        {
            lock (logs)
            {
                this.logs.Enqueue(log);
            }
        }

        /// <summary>
        /// Get next log as String. If parameter @true passed, will keep log in queue.
        /// </summary>
        /// <param name="peek"></param>
        /// <returns>Next log in queue\n</returns>
        public string popLog(bool peek = false)
        {
            lock (logs)
            {
                if (peek) return logs.Peek();
                else return logs.Dequeue();
            }
        }
        
        public bool logsQueued()
        {
            return logs.Count > 0;
        }

        /// <summary>
        /// Enqueue a log string. will be read and pushed to UI in seprate Thread.
        /// </summary>
        /// <param name="log"></param>
        /// <returns>Next log in queue\n</returns>
        public void pushLog(string log)
        {
            lock (logs)
            {
                logs.Enqueue(log);
            }
        }

        public LogEvent getLastEvent()
        {
            return data.Find(
                o => o.EventId==getLastEventId()
                );
        }

        private int getLastEventId()
        {
            if (data.Count == 0) return 0;
            return data.Max(o => o.EventId);
        }

        public List<LogEvent> getAllEventsAfterId(int id)
        {
            return data.FindAll(
                        delegate (LogEvent ld)
                        {
                            return ld.EventId > id;
                        }
                    );
        }

        public List<LogEvent> getAllEvents(int id)
        {
            return getAllEventsAfterId(-1);
        }

        public string getDataNameByKey(string key)
        {
            return currentLogEvent.getNameByKey(key);
        }

        public void setWebServerRunning(bool webserver_running)
        {
            //Durch den Aufruf von Thread.Sleep mit Timeout.Infinite bleibt ein Thread so lange deaktiviert (im Standbymodus),
            //bis er von einem anderen Thread unterbrochen wird, der Thread.Interrupt aufruft, 
            //oder bis er durch Thread.Abort beendet wird.
            if (webserver_running)
            {
                LoggerManager.THE().pushLog("starting webserver");
                webserver = new FraeseHttpServer("127.0.0.1", 8000);
                webserver_thread = new Thread(new ThreadStart(webserver.listen));
                webserver_thread.IsBackground = true;
                webserver_thread.Start();
            }
            else
            {
                webserver.stop();
            }
        }

        public String[] getAllKeys()
        {
            return possibleKeys;
        }

        public bool getBoolLogKey(string key)
        {
            try
            {
                return entriesToLog[key];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        internal void stop()
        {
            webserver.stop();
        }

    }
}
