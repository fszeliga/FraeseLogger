using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncFeedRate : CNCDataGenericBase<double>
    {
 
        internal override string Description
        {
            get
            {
                return "CNC Feed Rate (vorschub) mm/m";
            }
        }

        internal override string Key
        {
            get
            {
                return "feedRate";
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
            return Value.ToString();
        }

        public override void initialize()
        {
            Value = 0;

            if (myInfo.JobInfo.SpeedUnitMMMinute) _units = "mm/m";
            else _units = "mm/s";
        }

        public override bool read()
        {
            if (myInfo.JobInfo != null) Value = myInfo.JobInfo.JobSpeed;
            else Value = 0;

            return true;
        }
    }
}
