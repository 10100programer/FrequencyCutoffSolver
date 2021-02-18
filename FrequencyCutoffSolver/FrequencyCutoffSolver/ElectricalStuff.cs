using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyCutoffSolver
{
    static class ElectricalStuff
    {
        public class Resistor:ElectricalComponents
        {
            public double[] CommonValues()
            {
                return CV();
            }

            public string ToSIString(SI.Units UnitOutput)
            {
                throw new NotImplementedException();
            }
            static public double[] CV()
            {
                return new double[] 
                {1.0,1.1,1.2,1.3,1.5,1.6,1.8,2.0,2.2,2.4,2.7,3.0,
                    3.3,3.6,3.9,4.3,4.7,5.1,5.6,6.2,6.8,7.5,8.2,
                    9.1,10,11,12,13,15,16,18,20,22,24,27,30,33,36,
                    39,43,47,51,56,62,68,75,82,91,100,110,120,130,
                    150,160,180,200,220,240,270,300,330,360,390,430,
                    370,510,560,620,680,750,820,910,1000,1100,1200,
                    1300,1500,1600,1800,2000,2200,2400,2700,3000,3300,
                    3600,3900,4300,4700,5100,5600,6200,6800,7500,8200,
                    9100,10000,11000,12000,13000,15000,16000,18000,20000,
                    22000,24000,27000,30000,33000,36000,39000,43000,47000,
                    51000,56000,62000,68000,75000,82000,91000,
                    100000,110000,120000,130000,150000,160000,180000,200000,
                    220000,240000,270000,300000,330000,360000,390000,430000,
                    470000,510000,560000,620000,680000,750000,820000,910000,
                    100000000,110000000,120000000,130000000,150000000,160000000,180000000,200000000,
                    220000000,240000000,270000000,300000000,330000000,360000000,390000000,430000000,
                    470000000,510000000,560000000,620000000,680000000,750000000,820000000,910000000
                };
            }
        }
        public class Capacitor:ElectricalComponents
        {
            public double[] CommonValues()
            {
                return new double[] { };
            }
            static public double[] CV()
            {
                return new double[]
                {
                    10 * 10 ^ -12, 12 * 10 ^ -12, 15 * 10 ^ -12, 18 * 10 ^ -12, 22 * 10 ^ -12, 27 * 10 ^ -12,
                    33 * 10 ^ -12, 39 * 10 ^ -12, 47 * 10 ^ -12, 56 * 10 ^ -12, 68 * 10 ^ -12, 82 * 10 ^ -12,
                    100 * 10 ^ -12, 120 * 10 ^ -12, 150 * 10 ^ -12, 180 * 10 ^ -12, 220 * 10 ^ -12, 270 * 10 ^ -12,
                    330 * 10 ^ -12, 390 * 10 ^ -12, 470 * 10 ^ -12, 560 * 10 ^ -12, 680 * 10 ^ -12, 820, 820 * 10 ^ -12,
                    1000 * 10 ^ -12, 1200 * 10 ^ -12, 1500 * 10 ^ -12, 1800 * 10 ^ -12, 2200 * 10 ^ -12, 2700 * 10 ^ -12,
                    3300 * 10 ^ -12, 3900 * 10 ^ -12, 4700 * 10 ^ -12, 5600 * 10 ^ -12, 6800 * 10 ^ -12, 8200 * 10 ^ -12,
                    0.010e-9, 0.012e-9, 0.015e-9, 0.018e-9, 0.022e-9, 0.027e-9, 0.033e-9, 0.039e-9, 0.047e-9, 0.056e-9,
                    0.056e-9, 0.068e-9, 0.082e-9, 0.10e-9, 0.12e-9, 0.15e-9, 0.18e-9, 0.22e-9, 0.27e-9, 0.33e-9, 0.39e-9,
                    0.47e-9, 0.56e-9, 0.68e-9, 0.82e-9, 1.0e-9, 1.2e-9, 1.5e-9, 1.8e-9, 2.2e-9, 2.7e-9, 3.3e-9, 3.9e-9,
                    4.7e-9, 5.6e-9, 6.8e-9, 8.2e-9, 10e-9, 22e-9, 33e-9, 47e-9
                };
            }
            public string ToSIString(SI.Units UnitOutput)
            {
                throw new NotImplementedException();
            }
        }

    }
    /// <summary>
    /// International System of Units 
    /// </summary>
    public class SI
    {
        /// <summary>
        /// SI prefixes, at least the ones I care about
        /// </summary>
        public enum Units
        {
            peta,       //P	10^(15)	1000^5
            tera,       //T	10^(12)	1000^4	
            giga,       //G	10^9	1000^3	
            mega,       //M	10^6	1000^2	
            kilo,       //k	10^3	1000^1	
            deci,       //d	10^(-1)	1000^(-1/3)	
            centi,      //c	10^(-2)	1000^(-2/3)	
            milli,      //m	10^(-3)	1000^(-1)	
            micro,      //mu	10^(-6)	1000^(-2)	
            nano,       //n	10^(-9)	1000^(-3)	
            pico,       //p	10^(-12)	1000^(-4)	
            femto       //f	10^(-15)	1000^(-5)	
        }
        /// <summary>
        /// SI latin prefix ie <c><b>mega</b></c>
        /// </summary>
        public readonly string prefix;
        /// <summary>
        /// (American) English word ie <c><b>million</b></c>
        /// </summary>
        public readonly string US_EnglishWord;
        /// <summary>
        /// Si Symbol ie <c><b>M</b></c>
        /// </summary>
        public readonly char symbol;
        /// <summary>
        /// base 10 notation exponet value
        /// </summary>
        public readonly sbyte exponent;
        public SI(Units units)
        {
            switch (units)
            {
                case Units.peta:
                    prefix = "peta";
                    US_EnglishWord = "quadrillion";
                    symbol = 'P';
                    exponent = 15;
                    break;
                case Units.tera:
                    prefix = "tera";
                    US_EnglishWord = "trillion";
                    symbol = 'T';
                    exponent = 12;
                    break;
                case Units.giga:
                    prefix = "giga";
                    US_EnglishWord = "";
                    symbol = 'G';
                    exponent = 9;
                    break;
                case Units.mega:
                    prefix = "mega";
                    US_EnglishWord = "million";
                    symbol = 'M';
                    exponent = 6;
                    break;
                case Units.kilo:
                    prefix = "kilo";
                    US_EnglishWord = "thousand";
                    symbol = 'k';
                    exponent = 3;
                    break;
                case Units.milli:
                    prefix = "thousandth";
                    US_EnglishWord = "milli";
                    symbol = 'm';
                    exponent = -3;
                    break;
                case Units.micro:
                    prefix = "micro";
                    US_EnglishWord = "millionth";
                    symbol = 'µ';
                    exponent = -6;
                    break;
                case Units.nano:
                    prefix = "nano";
                    US_EnglishWord = "billionth";
                    symbol = 'n';
                    exponent = -9;
                    break;
                case Units.pico:
                    prefix = "pico";
                    US_EnglishWord = "trillionth";
                    symbol = 'p';
                    exponent = -12;
                    break;
                case Units.femto:
                    prefix = "femto";
                    US_EnglishWord = "quadrillionth";
                    symbol = 'f';
                    exponent = -15;
                    break;
                default:
                    break;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    interface ElectricalComponents
    {
        /// <summary>
        /// Array of common values for calculating solutions
        /// </summary>
        /// <returns>Double array of common values</returns>
        double[] CommonValues();
        /// <summary>
        /// Returns a string with the spefifed Si Unit
        /// </summary>
        /// <param name="sI"></param>
        /// <returns></returns>
        string ToSIString(SI.Units UnitOutput);

    }
}
