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
                    String lineTitle = "aktives NC-Programm;"; //1
                    lineTitle += "Türe geschlossen;"; //2
                    lineTitle += "Spindel dreht sich;";//3
                    lineTitle += "Spindel Drehzahl;";//4
                    lineTitle += "Freilauf;";//5
                    lineTitle += "Schnittgeschwindigkeit;";//6
                    lineTitle += "Vorschub;";//7
                    lineTitle += "Bearbeitungszeit;";//8
                    lineTitle += "Start NC-Programm;";//9
                    lineTitle += "Ende NC - Programm;";//10
                    lineTitle += "Endschalter X;";//11
                    lineTitle += "Endschalter Y;";//12
                    lineTitle += "Endschalter Z;";//13
                    lineTitle += "max.Schnittgeschwindigkeit;";//14
                    lineTitle += "Werkzeuglängsensor aktiv;";//15
                    lineTitle += "Spannung analoger Eingang 1;";//16
                    lineTitle += "Spannung analoger Eingang 2;";//17
                    lineTitle += "GCode Zeile;";//18
                    lineTitle += "GCode;";//19
                    lineTitle += "Position X;";//20
                    lineTitle += "Position Y;";//21
                    lineTitle += "Position Z;";//22
                    lineTitle += "Datum;";//23
                    lineTitle += "Uhrzeit;";//24

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

                    String line = li.activeProg + ";";//1
                    line += li.doorOpen + ";";//2
                    line += li.spindleOn + ";";//3
                    line += li.spidlespeed + ";";//4
                    line += li.freilauf + ";";//5
                    line += li.cutSpeed + ";";//6
                    line += li.vorschub + ";";//7
                    line += li.worktime.ToString() + ";";//8
                    line += li.startTime + ";";//9
                    line += li.endTIme + ";";//10
                    line += li.endschalterX + ";";//11
                    line += li.endschalterY + ";";//12
                    line += li.endschalterZ + ";";//13
                    line += li.maxCutSpeed + ";";//14
                    line += li.heightSensorActive + ";";//15
                    line += li.volt1 + ";";//16
                    line += li.volt2 + ";";//17
                    line += li.gCodeLine.ToString() + ";";//18
                    line += li.gCode + ";";//19
                    line += li.positions.x + ";";//20
                    line += li.positions.y + ";";//21
                    line += li.positions.z + ";";//22
                    line += DateTime.Now.ToString("dd-MM-yyyy") + ";";//23
                    line += DateTime.Now.ToString("HH:mm:ss.ff");//24

                    file.WriteLine(line);
                    li.logCount += 1;
                    System.Threading.Thread.Sleep(li.logInterval);
                }
            }

        }
    }
}
