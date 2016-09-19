using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data
{
    class LoggerSettings
    {
        public int logInterval = 1000; //in ms
        public string logFiledir = ""; //in ms
        public string logFilename = ""; //in ms
        public bool logThreadRunning = false;

        private static LoggerSettings i = null;
        internal int loggedEntriesCount;

        private LoggerSettings()
        {
            logFilename = "cncLog.txt";
        }

        public static LoggerSettings Instance()
        {
            if (i == null)
                i = new LoggerSettings();
            return i;
        }
    }
}
