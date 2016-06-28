using System.Windows.Forms;
using cncGraF.iPlugin;

namespace FraeseLogger {

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
            LoggerInstance.Instance.Connector = aPluginArgs.Connector;
            LoggerInstance.Instance.MachInfo = aPluginArgs.MachInfo;

            LoggerDlg loggerDlg = new LoggerDlg();
            loggerDlg.Show();

            PluginResult thePluginResult = new PluginResult();
            return thePluginResult;
        }

    }
}
