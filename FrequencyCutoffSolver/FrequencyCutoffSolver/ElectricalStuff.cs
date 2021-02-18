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
            public decimal[] CommonValues()
            {
                return new decimal[] { };
            }

            public string ToSIString(SI.Units UnitOutput)
            {
                throw new NotImplementedException();
            }
        }
        public class Capacitor:ElectricalComponents
        {
            public decimal[] CommonValues()
            {
                return new decimal[] { };
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
        decimal[] CommonValues();
        /// <summary>
        /// Returns a string with the spefifed Si Unit
        /// </summary>
        /// <param name="sI"></param>
        /// <returns></returns>
        string ToSIString(SI.Units UnitOutput);

    }
}
