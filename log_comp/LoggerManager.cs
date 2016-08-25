using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using imi_cnc_logger.log_comp;
using imi_cnc_logger.WebServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace imi_cnc_logger
{
    public class LoggerManager
    {
        public Connector connector { get; private set; }
        public MachInfo machInfo { get; private set; }
        private CNCReader cncReader = null;
        private List<LogEvent> data = new List<LogEvent>();
        private Queue<String> logs = new Queue<String>();

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
            this.connector = c;
            this.machInfo = m;

            energy = new energenie(System.Net.IPAddress.Parse("192.168.0.102"));
            threadEnergenie = new Thread(new ThreadStart(energy.readEnergenie));
            //threadEnergenie.Start();
        }

        /// <summary>
        /// Read from CNC through connector etc.
        /// Throws CNCReaderNotInitialized Exception if you didnt not run init Method first!
        /// </summary>
        public void readFromCNC()
        {
            if (cncReader == null) throw new CNCReaderNotInitialized("You need to run init on LoggerManager first!");
            Tuple<bool, LogEvent> newData = cncReader.getNewData(getLastEvent());
            if (newData.Item1) data.Add(newData.Item2);
            else LoggerManager.THE().pushLog("same data! not logging");
        }

        public void initDummy()
        {
            for(int i = 0; i < 1; i++)
            {
                data.Add(new LogEvent(i));
            }
        }

        public void addLog(String log)
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
        public String popLog(bool peek = false)
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
        public void pushLog(String log)
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

        internal void stop()
        {
            webserver.stop();
        }
    }
}
