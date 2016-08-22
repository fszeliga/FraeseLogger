using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data
{
    abstract class CNCDataBase<T> : CNCDataInterface<T>
    {
        private T val;
        private String name { get; set; }
        private String description { get; set; } = "You can set description here...";

        public CNCDataBase(String n, String desc)
        {
            this.name = n;
            this.description = desc;
        }

        public T Value
        {
            get
            {
                return val;
            }

            set
            {
                val = value;
            }
        }
        
        public abstract string asString();

        public abstract void read();
    }
}
