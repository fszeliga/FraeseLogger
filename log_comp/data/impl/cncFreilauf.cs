using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncFreilauf : CNCDataGenericBase<bool>
    {
 
        internal override string Description
        {
            get
            {
                return "true if freilauf, false otherwise";
            }
        }

        internal override string Key
        {
            get
            {
                return "freilauf";
            }
        }

        internal override string Name
        {
            get
            {
                return "Ist CNC im freilauf";
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
            Value = false;
        }

        public override bool read()
        {
            if ((myConn.Job != null) && (myConn.Job.GetCurrent() != null))
            {
                Value = !myConn.Job.GetCurrent().Down;
            }
            else
            {
                Value = true;
            }
            return true;
        }
    }
}
