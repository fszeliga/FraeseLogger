using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace imi_cnc_logger
{
    public class LoggerFileWriter
    {
        private bool writeTitle;
        private LoggerData li = LoggerData.Instance;

        public bool logActiveProg { get; internal set; }
        public bool logDoorStatus { get; internal set; }
        public bool logSpindleStatus { get; internal set; }
        public bool logEndschalter { get; internal set; }
        public bool logStartTime { get; internal set; }
        public bool logEndTime { get; internal set; }
        public bool logWorktime { get; internal set; }
        public bool logFeedRate { get; internal set; }
        public bool logCutSpeed { get; internal set; }
        public bool logMaxCutSpeed { get; internal set; }
        public bool logHeightSensorActive { get; internal set; }
        public bool logFreilauf { get; internal set; }
        public bool logGCode { get; internal set; }
        public bool logPositions { get; internal set; }
        public bool logSpindleSpeed { get; internal set; }
        public bool logSpannung { get; internal set; }

        public LoggerFileWriter(bool writeTitle)
        {
            li.logCount = 0;
            this.writeTitle = writeTitle;
        }

        public void logCNC()
        {
            String filename = li.LogFileDir + li.log_filename;

            using(StreamWriter file = new StreamWriter(@filename))
            {
                if (writeTitle)
                {
                    String lineTitle = "";
                    if (logActiveProg)
                    {
                        lineTitle = "aktives NC-Programm;"; //1
                    }
                    if (logDoorStatus){
                        lineTitle += "Türe geschlossen;"; //2
                    }
                    if (logSpindleSpeed)
                    {
                        lineTitle += "Spindel Drehzahl;";//4
                    }
                    if (logSpindleStatus){
                        lineTitle += "Spindel dreht sich;";//3
                    }
                    if (logEndschalter){
                        lineTitle += "Endschalter X;";//11
                        lineTitle += "Endschalter Y;";//12
                        lineTitle += "Endschalter Z;";//13
                    }
                    if(logStartTime){
                        lineTitle += "Start NC;";//9
                    }
                    if (logEndTime){
                        lineTitle += "Ende NC;";//10
                    }
                    if (logWorktime){
                        lineTitle += "Bearbeitungszeit;";//8
                    }
                    if (logFeedRate){
                        lineTitle += "Vorschub;";//7
                    }
                    if (logCutSpeed){
                        lineTitle += "Schnittgeschwindigkeit;";//6
                    }
                    if (logMaxCutSpeed){
                        lineTitle += "max.Schnittgeschwindigkeit;";//14
                    }
                    if (logHeightSensorActive)
                    {
                        lineTitle += "Werkzeuglängsensor aktiv;";//15
                    }
                    if (logFreilauf){
                        lineTitle += "Freilauf;";//5
                    }
                    if (logGCode)
                    {
                        lineTitle += "GCode Zeile;";//18
                        lineTitle += "GCode;";//19
                    }
                    if(logPositions){
                        lineTitle += "Position X;";//20
                        lineTitle += "Position Y;";//21
                        lineTitle += "Position Z;";//22
                    }
                    if (logSpannung){
                        lineTitle += "Spannung analoger Eingang 1;";//16
                        lineTitle += "Spannung analoger Eingang 2;";//17
                    }

                    lineTitle += "Datum;";//23
                    lineTitle += "Uhrzeit;";//24

                    file.WriteLine(lineTitle);
                }


                while (li.logThreadRunning)
                {

                    String line = "";
                    if (logActiveProg)
                    {
                        //line = li.activeProg + ";";//1
                    }
                    if (logDoorStatus)
                    {
                        line += li.doorOpen + ";";//2
                    }
                    if (logSpindleStatus)
                    {
                        line += li.spindleOn + ";";//3
                    }
                    if (logSpindleSpeed)
                    {
                        line += li.spindlespeed + ";";//4
                    }
                    if (logEndschalter)
                    {
                        //line += li.endschalterX + ";";//11
                        //line += li.endschalterY + ";";//12
                        //line += li.endschalterZ + ";";//13
                    }
                    if (logStartTime)
                    {
                        line += li.startTime + ";";//9
                    }
                    if (logEndTime)
                    {
                        line += li.endTime + ";";//10
                    }
                    if (logWorktime)
                    {
                        line += li.worktime.ToString() + ";";//8
                    }
                    if (logFeedRate)
                    {
                        line += li.vorschub + ";";//7
                    }
                    if (logCutSpeed)
                    {
                        line += li.cutSpeed + ";";//6
                    }
                    if (logMaxCutSpeed)
                    {
                        line += li.maxCutSpeed + ";";//14
                    }
                    if (logHeightSensorActive)
                    {
                        line += li.heightSensorActive + ";";//15
                    }
                    if (logFreilauf)
                    {
                        line += li.freilauf + ";";//5
                    }
                    if (logGCode)
                    {
                        //line += li.gCodeLine.ToString() + ";";//18
                        //line += li.gCode + ";";//19
                    }
                    if (logPositions)
                    {
                        //line += li.positions.X + ";";//20
                        //line += li.positions.Y + ";";//21
                        //line += li.positions.Z + ";";//22
                    }
                    if (logSpannung)
                    {
                        line += li.volt1 + ";";//16
                        line += li.volt2 + ";";//17
                    }

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
