using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data
{
    abstract class CNCDataGenericBase<T> : CNCDataBase
    {
        private T val;
        internal String Name { get; set; }
        internal String Description { get; set; } = "You can set description here...";
        internal Connector myConn { get; }
        internal MachInfo myInfo { get; }

        public CNCDataGenericBase(String n, String desc)
        {
            this.Name = n;
            this.Description = desc;
            myConn = LoggerManager.THE().connector;
            myInfo = LoggerManager.THE().machInfo;
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

    }
}
