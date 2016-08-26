using De.Boenigk.SMC5D.Basics;
using imi_cnc_logger.log_comp.data.data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncEndschalter : CNCDataGenericBase<endschalter>
    {
        internal override string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal override string Key
        {
            get
            {
                return "endschalter";
            }
        }

        internal override string Name
        {
            get
            {
                return "Endschalter von der CN";
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
                return "x:" + Value.X.ToString() + ", y:" + Value.Y.ToString() + ", z:" + Value.Z.ToString();
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
            }
            else
            {
                return "Parameters not accepted: args=" + args[0];
            }
        }

        public override void initialize()
        {
            Value = new endschalter();
        }

        public override bool read()
        {
            Switch theSwitch = new Switch(myConn);

            Value = new endschalter(theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisX.ReferencePinNumber), false),
                theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisY.ReferencePinNumber), false),
                theSwitch.IsInputOn(InputConverter.GetInput(myConn.SMCSettings.AxisZ.ReferencePinNumber), false));

            return true;
        }
    }
}
