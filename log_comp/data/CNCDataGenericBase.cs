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
        internal Connector myConn { get; }
        internal MachInfo myInfo { get; }

        public CNCDataGenericBase()
        {
            myConn = LoggerManager.THE().connector;
            myInfo = LoggerManager.THE().machInfo;
            initialize();
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
