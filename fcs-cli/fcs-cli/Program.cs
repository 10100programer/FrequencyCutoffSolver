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
            FrequencyTools.FrequencyCutoff.PredictiveSolve(1000, 1);
            Console.ReadLine();
        }
    }
}
