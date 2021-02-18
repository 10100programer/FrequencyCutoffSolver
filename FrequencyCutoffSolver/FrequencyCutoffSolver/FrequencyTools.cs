using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FrequencyCutoffSolver
{
    static class FrequencyTools
    {
        static class FrequencyCutoff
        {
            /// <summary>
            /// Uses the Frequency Cutoff Formula to return in Hz the cutoff given resistance and capacitance
            /// </summary>
            /// <param name="Resistance"></param>
            /// <param name="Capacitance"></param>
            /// <returns>Frequency Cutoff</returns>
            static public double SimpleSolve(double Resistance, double Capacitance)
            {
                return 1 / (2 * Math.PI * Resistance * Capacitance);
            }
            static public double ClassSolve(ElectricalStuff.Capacitor Cap, ElectricalStuff.Resistor resistor)
            {
                throw new NotImplementedException();
            }
            static public double PredictiveSolve(double FrequencyToSolveFor,byte percentToTarget)
            {
                



            }
        }
    }
}
