using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTesting
{

    class PWM
    {
        dotNet powerSocket = new dotNet();
        deviceClass device = new deviceClass();

        public PWM()
        {
            //powerSocket.GetDevList();
            ProcessStartInfo perlStartInfo = new ProcessStartInfo(@"C:\Perl64\bin\perl.exe");
            perlStartInfo.Arguments = "C:\\Users\\Filip\\Documents\\Boenigk\\cncGraF7\\plugins\\FraeseLogger\\readFromWebsite.pl";
            perlStartInfo.UseShellExecute = false;
            perlStartInfo.RedirectStandardOutput = true;
            perlStartInfo.RedirectStandardError = true;
            perlStartInfo.CreateNoWindow = false;

            Process perl = new Process();
            perl.StartInfo = perlStartInfo;
            perl.Start();
            perl.WaitForExit();
            string output = perl.StandardOutput.ReadToEnd();

            Console.WriteLine(output);
        }
       
    }
}
