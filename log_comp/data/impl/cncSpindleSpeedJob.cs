using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncSpindleSpeedJob : CNCDataGenericBase<double>
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
                return "spindleSpeedJob";
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
            try
            {
                Value = Convert.ToInt32(myConn.Job.GetCurrent().SpindleSpeed);
            } catch
            {
                Value = 0;
            }
            LoggerManager.THE().addLog(Key + " " + Value);

            return true;
        }
    }
}
