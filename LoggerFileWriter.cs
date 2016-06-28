using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FraeseLogger
{
    public class LoggerFileWriter
    {
        private bool writeTitle;
        private LoggerInstance li = LoggerInstance.Instance;

        public LoggerFileWriter(bool writeTitle)
        {
            li.logCount = 0;
            this.writeTitle = writeTitle;
        }

        public void logCNC()
        {
            String filename = li.LogFileDir + li.log_filename;
            using(System.IO.StreamWriter file = new StreamWriter(@filename))
            {
                if (writeTitle)
                {
                    String lineTitle = "aktives NC-Programm";
                    lineTitle += "Türe geschlossen";
                    lineTitle += "Spindel dreht sich";
                    lineTitle += "Schnittgeschwindigkeit";
                    lineTitle += "Vorschub";
                    lineTitle += "Bearbeitungszeit";
                    lineTitle += "Start NC-Programm";
                    lineTitle += "Ende NC - Programm";
                    lineTitle += "Endschalter";
                    lineTitle += "max.Schnittgeschwindigkeit";
                    lineTitle += "Werkzeuglängsensor aktiv";
                    lineTitle += "Spannung analoger Eingang 1";
                    lineTitle += "Spannung analoger Eingang 2";
                    lineTitle += "Datum";
                    lineTitle += "Uhrzeit";

                    file.WriteLine(lineTitle);
                }


                while (li.logThreadRunning)
                {
                    /*
                     1- aktives NC-Programm
                    2- Türe geschlossen
                    3- Spindel dreht sich
                    4- Schnittgeschwindigkeit
                    5- Vorschub
                    6- Bearbeitungszeit (Hautpzeit) Start /Ende einer Bearbeitung
                    7- Start NC-Programm
                    8- Ende NC-Programm
                    9- Endschalter
                    10 - max. Schnittgeschwindigkeit erreicht
                    11- Werkzeuglängsensor aktiv

                    12 - Spannung analoger Eingang 1
                    13 - Spannung analoger Eingang 2

                    */
                    //1;2;3;4;5;6;7;8;9;10;11;12;13;Datum;Zeit

                    String line = li.ActiveProg + ";";
                    line += li.DoorOpen + ";";
                    line += li.SpindleOn + ";";
                    line += li.CutSpeed + ";";
                    line += li.Vorschub + ";";
                    line += li.Worktime + ";";
                    line += li.StartTime + ";";
                    line += li.EndTIme + ";";
                    line += li.Endschalter + ";";
                    line += li.MaxCutSpeed + ";";
                    line += "N/A Werkzeuglängsensor aktiv?" + ";";
                    line += li.volt1 + ";";
                    line += li.volt2 + ";";
                    line += DateTime.Now.ToString("dd-MM-yyyy") + ";";
                    line += DateTime.Now.ToString("HH:mm:ss.ff");

                    file.WriteLine(line);
                    li.logCount += 1;
                    System.Threading.Thread.Sleep(li.logInterval);
                }
            }

        }
    }
}
