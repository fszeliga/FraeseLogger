using System;

namespace imi_cnc_logger.log_comp.data
{
    abstract class CNCDataBase
    {
        private String _name;
        private String _description;
        internal string _units = "NA";
        internal bool _constant { get; set; } = false;

        abstract internal String Name {get; }
        abstract internal String Description { get; }
        abstract internal String Key { get; }

        virtual internal String LogKey {
            get
            {
                return Key;
            }
        }

        public abstract string asString();
        public abstract bool read();
        public abstract void initialize();
        public virtual string getLoggableValue()
        {
            return getValue(null);
        }

        /// <summary>
        /// args can be null!!!! means just return all
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract string getValue(string[] args);

        public string getValueWithUnits(string[] args)
        {
            return _units == "NA" ?  getValue(args) : getValue(args) + _units;
        }
    }
}