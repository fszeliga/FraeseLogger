using De.Boenigk.SMC5D.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncHeightSensor: CNCDataGenericBase<bool>
    {
 
        internal override string Description
        {
            get
            {
                return "true if height sensor active, false otherwise";
            }
        }

        internal override string Key
        {
            get
            {
                return "heightSensor";
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
            Value = false;
        }

        public override bool read()
        {
            if (myConn.SMCSettings.HeightSensor.MeasureToolPin == Input.Default)
            {
                Value = false;
            }
            else
            {
                Value = true;
            }
            return true;
        }
    }
}
