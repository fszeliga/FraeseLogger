using System;

namespace imi_cnc_logger.log_comp.data
{
    abstract class CNCDataBase
    {
        private String _name;
        private String _description;
        abstract internal String Name {get; }
        abstract internal String Description { get; }
        abstract internal String Key { get; }
        public abstract string asString();
        public abstract bool read();
        public abstract void initialize();

        /// <summary>
        /// args can be null!!!! means just return all
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract string getValue(string[] args);
    }
}