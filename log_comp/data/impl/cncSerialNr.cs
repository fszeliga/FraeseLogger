using System;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncSerialNr : CNCDataGenericBase<string>
    {
 
        internal override string Description
        {
            get
            {
                return "CNC Serial Number";
            }
        }

        internal override string Key
        {
            get
            {
                return "serialNr";
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
            Value = "?";
            _constant = true;
        }

        public override bool read()
        {
            Value = myConn.SN;

            return true;
        }
    }
}
