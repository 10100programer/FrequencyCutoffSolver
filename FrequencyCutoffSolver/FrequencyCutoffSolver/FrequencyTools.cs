using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FrequencyCutoffSolver
{
    public static class FrequencyTools
    {
        public static class FrequencyCutoff
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
            static public List<FrequencyCutoffSolution> PredictiveSolve(double FrequencyToSolveFor, byte percentToTarget)
            {
                List<FrequencyCutoffSolution> frequencyCutoffSolutions = new List<FrequencyCutoffSolution>();
                //int DebugCTS = 0;
                //int Capcts = 0;
                //int rescts = 0;
                //FrequencyCutoffSolution fcs = new FrequencyCutoffSolution(0,0,0);
                foreach (double Cap in ElectricalStuff.Capacitor.CV())
                {
                    foreach (double Res in ElectricalStuff.Resistor.CV())
                    {
                        double Freq = SimpleSolve(Res, Cap);
                        if (WithinRangePercentage(Freq, percentToTarget, FrequencyToSolveFor))
                        {
                            //Console.WriteLine(Res + "Ω | " + Cap + "F =" + Freq);
                            frequencyCutoffSolutions.Add(new FrequencyCutoffSolution(Cap, Res, Freq));
                        }
                        //DebugCTS++;
                        //rescts++;
                    }
                    //Capcts++;
                    //rescts = 0;
                }
                foreach (FrequencyCutoffSolution item in frequencyCutoffSolutions)
                {
                    Console.WriteLine(item.ToString());
                }


                return frequencyCutoffSolutions;
            }
            /// <summary>
            /// checks if num is in range of target value
            /// </summary>
            /// <param name="num"></param>
            /// <param name="percentage"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            static private bool WithinRangePercentage (double num, double percentage, double target)
            {
                double upperlimit = num + (num * (percentage *.01));
                double lowerlimit = num - (num * (percentage * .01));
                if(target < upperlimit && target > lowerlimit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class FrequencyCutoffSolution
        {
            public readonly ElectricalStuff.Capacitor capacitor;
            public readonly ElectricalStuff.Resistor resistor;
            public readonly SI sI;
            public readonly double Capacitance;
            public readonly double Resistance;
            public readonly double Frequency;

            public FrequencyCutoffSolution(double cap, double res, double freq)
            {
                capacitor = new ElectricalStuff.Capacitor(cap);
                resistor = new ElectricalStuff.Resistor(res);
                sI = SI.AutoDetermineUnit(freq);
                Capacitance = cap;
                Resistance = res;
                Frequency = freq;
            }
            public override string ToString()
            {
                return "Solution:>>>>>>>>>\n" + resistor.ToSIString() + "\n" + capacitor.ToSIString() + "\n" + sI.BaseToSIOutput(Frequency,"Hz") + "\n" ;
            }
        }
    }
}
