using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncEnergy : CNCDataGenericBase<energenie>
    {
 
        internal override string Description
        {
            get
            {
                return "CNC Energy Usage Data";
            }
        }

        internal override string Key
        {
            get
            {
                return "energy";
            }
        }

        internal override string Name
        {
            get
            {
                return "asd";
            }
        }

        internal override string LogKey
        {
            get
            {
                return "Ewatt;Eampere;Evolt;Ewatthours";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getLoggableValue()
        {
            return Value.watt.ToString() + ";" + Value.current.ToString() + ";" + Value.voltage.ToString() + ";" + Value.energy.ToString();
        }

        public override string getValue(string[] args)
        {
            return Value.data2String(" ", false, true);
        }

        public override void initialize()
        {
            Value = new energenie(System.Net.IPAddress.Parse("192.168.178.46"));

            //Value = new energenie(System.Net.IPAddress.Parse("192.168.0.102"));
        }

        public override bool read()
        {
            return true;
        }
    }
}
