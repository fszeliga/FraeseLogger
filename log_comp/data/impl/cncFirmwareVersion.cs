using System;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncFirmwareVersion : CNCDataGenericBase<ushort>
    {
 
        internal override string Description
        {
            get
            {
                return "CNC Firmware Version";
            }
        }

        internal override string Key
        {
            get
            {
                return "firmareVersion";
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
            _constant = true;
        }

        public override bool read()
        {
            Value = myConn.FirmwareVersion;

            return true;
        }
    }
}
