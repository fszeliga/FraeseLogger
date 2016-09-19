using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncSpindleSpeed : CNCDataGenericBase<int>
    {
 
        internal override string Description
        {
            get
            {
                return "asd";
            }
        }

        internal override string Key
        {
            get
            {
                return "spindleSpeed";
            }
        }

        internal override string LogKey
        {
            get
            {
                return Key + " (0-255)";
            }
        }

        internal override string Name
        {
            get
            {
                return "asd";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            return Convert.ToString(Value);
        }

        public override void initialize()
        {
            Value = 0;
        }

        public override bool read()
        {
            Value = Convert.ToInt32(myConn.GlobPosition.SpindleSpeed);
            LoggerManager.THE().addLog(Key + " " + myConn.GlobPosition.SpindleSpeed);
            return true;
        }
    }
}
