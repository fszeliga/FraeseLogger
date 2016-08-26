using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data
{
    class LoggerSettings
    {
        private static LoggerSettings i = null;

        private LoggerSettings()
        {

        }

        public static LoggerSettings Instance()
        {
            if (i == null)
                i = new LoggerSettings();
            return i;
        }
    }
}
