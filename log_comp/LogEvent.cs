using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp
{
    public class LogEvent : IEquatable<LogEvent>
    {
        public readonly int EventId;
        
        private LogEvent()
        {
            throw new LogEventInvalidConstructorCall("You can't call this :P need to call with id param!");
        }

        public LogEvent(int eventID)
        {
            this.EventId = eventID;
        }

        public String activeProg { get; internal set; } = "none";
        public String startTime { get; internal set; } = "";
        public CNCPosition cncPos { get; internal set; } = new CNCPosition();

        public bool Equals(LogEvent other)
        {
            LoggerManager.THE().pushLog("compare: " + this.activeProg+" with "+other.activeProg);
            if (other.activeProg != this.activeProg) return false;
            if (other.startTime != this.startTime) return false;
            if (!other.cncPos.Equals(this.cncPos)) return false;
            return true;
        }


    }
}
