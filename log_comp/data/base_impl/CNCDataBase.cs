using System;

namespace imi_cnc_logger.log_comp.data
{
    abstract class CNCDataBase
    {
        public abstract string asString();
        public abstract bool read();
        public abstract string getValue(string[] args);
    }
}