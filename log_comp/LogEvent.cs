using imi_cnc_logger.log_comp.data;
using imi_cnc_logger.log_comp.data.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            EventId = eventID;



            string @namespace = "imi_cnc_logger.log_comp.data.impl";
            var theList = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == @namespace).ToList();

            foreach (Type d in theList)
            {
                CNCDataBase obj = (CNCDataBase)Activator.CreateInstance(d);
                data.Add(obj.Key, obj);
            }

        }

        public void update()
        {
            foreach (CNCDataBase d in data.Values) d.read();
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
                return "keynotfound";
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

        internal string getNameByKey(string key)
        {
            return data[key].Name;
        }

        internal string getLoggableValue(string k)
        {
            return data[k].getLoggableValue();
        }

        internal string getLoggableName(string k)
        {
            return data[k].LogKey;
        }
    }
}
