using System.Windows.Forms;
using cncGraF.iPlugin;
using System.Threading;
using System;
using FraeseLogger;

namespace imi_cnc_logger
{

    public class FraeseLogger: IPlugin {

        /// <summary>
        /// Plugin name
        /// </summary>
        public string Name {
            get {
                return "CNC Fräse Logger";                
            }
        }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description {
            get {
                return "here a description";                 
            }
        }

        /// <summary>
        /// Plugin start
        /// </summary>
        /// <param name="aPluginArgs">plugin args</param>
        /// <returns>plugin results</returns>
        public PluginResult Execute(PluginArgs aPluginArgs)
        {
            LoggerManger.THE().init(aPluginArgs.Connector, aPluginArgs.MachInfo);
            LoggerManger.THE().pushLog("initialized connector and machinfo");
            LoggerManger.THE().initDummy();
            LoggerManger.THE().pushLog("initialized dummies");

            LoggerData.Instance.init(aPluginArgs.Connector, aPluginArgs.MachInfo);
          
            LoggerDlg loggerDlg = new LoggerDlg();
            loggerDlg.Show();

            PluginResult thePluginResult = new PluginResult();
            return thePluginResult;
        }

    }
}
