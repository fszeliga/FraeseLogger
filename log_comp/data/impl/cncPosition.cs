using De.Boenigk.SMC5D.Basics;
using imi_cnc_logger.log_comp.data.data_types;
using System;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncPosition : CNCDataGenericBase<position>
    { 

        internal override string Description
        {
            get
            {
                return "Yay you found position Description!!!";
            }
        }

        internal override string Key
        {
            get
            {
                return "position";
            }
        }

        internal override string Name
        {
            get
            {
                return "Position of the CNC in MM";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            if (args == null || args[0] == "all" || args[0] == "")
            {
                return "x:"+Value.X.ToString() + ", y:" + Value.Y.ToString() + ", z:" + Value.Z.ToString();
            }
            else if (args[0] == "x")
            {
                return Value.X.ToString();
            }
            else if (args[0] == "y")
            {
                return Value.Y.ToString();
            }
            else if (args[0] == "z")
            {
                return Value.Z.ToString();
            } else
            {
                return "Parameters not accepted!" + args[0];
            }
        }

        public override void initialize()
        {
            Value = new position(0,0,0);
        }

        public override bool read()
        {
            Value = new position(StepCalc.GetMMX(myConn), StepCalc.GetMMY(myConn), StepCalc.GetMMZ(myConn));
            return true;
        }
    }
}