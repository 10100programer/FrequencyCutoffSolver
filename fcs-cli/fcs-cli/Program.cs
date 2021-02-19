using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyCutoffSolver;
namespace fcs_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Enter Frequency in Hz");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(":>");
            double Freq = double.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the precision % (recomend 1%)");
            Console.Write(":>");
            byte Percent = byte.Parse(Console.ReadLine());
            FrequencyTools.FrequencyCutoff.PredictiveSolve(Freq, Percent);
            Console.ReadLine();
        }
    }
}
