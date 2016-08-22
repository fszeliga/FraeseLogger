using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp
{
    public class CNCReaderNotInitialized : Exception
    {
        public CNCReaderNotInitialized()
        {
        }

        public CNCReaderNotInitialized(string message)
        : base(message)
        {
        }

        public CNCReaderNotInitialized(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
    public class LogEventInvalidConstructorCall : Exception
    {
        public LogEventInvalidConstructorCall()
        {
        }

        public LogEventInvalidConstructorCall(string message)
        : base(message)
        {
        }

        public LogEventInvalidConstructorCall(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
