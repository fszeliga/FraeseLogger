using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTesting
{
    class Program
    {


        [STAThread]
        static void Main(string[] args)
        {
            new PWM();
            Console.WriteLine("works");
        }
    }
}
