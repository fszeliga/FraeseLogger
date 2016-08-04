using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraeseLogger
{
    public static class ConnectorUtility
    {
        private static Connector instance;
        public static Connector GetConnector()
        {
            if (instance == null)
            {
                instance = new Connector("\\");
                instance.Load("../../vendor/config.xml");
            }
            return instance;
        }

        public static SMCSettings GetConnectorSettings()
        {
            return GetConnector().SMCSettings;
        }
    }
}
