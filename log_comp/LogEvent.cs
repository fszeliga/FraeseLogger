using imi_cnc_logger.log_comp.data;
using imi_cnc_logger.log_comp.data.base_impl;
using System;
using System.Collections.Generic;

namespace imi_cnc_logger.log_comp
{
    public class LogEvent : IEquatable<LogEvent>
    {
        public readonly int EventId;
        internal Dictionary<string, CNCDataBase> data = new Dictionary<string, CNCDataBase>();
        
        private LogEvent()
        {
            throw new LogEventInvalidConstructorCall("You can't call this :P need to call with id param!");
        }

        public LogEvent(int eventID)
        {
            this.EventId = eventID;

            data.Add("position", new cncPosition("", ""));
        }

        public string getValueByKey(string key, string[] args = null)
        {
            try
            {
                return data[key].getValue(args);
            }
            catch (KeyNotFoundException)
            {
                LoggerManager.THE().addLog("Key not found: " + key);
                return "Key Not Found!";
            }
        }
        
        public bool Equals(LogEvent other)
        {
            //LoggerManager.THE().pushLog("compare: " + this.activeProg+" with "+other.activeProg);
            //if (other.activeProg != this.activeProg) return false;
            //if (other.startTime != this.startTime) return false;
            //if (!other.cncPos.Equals(this.cncPos)) return false;
            //return true;
            return false; 
        }


    }
}
