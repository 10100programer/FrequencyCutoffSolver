﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyCutoffSolver
{
    static public class ElectricalStuff
    {
        public class Resistor:ElectricalComponents
        {
            private readonly double value;
            public double[] CommonValues()
            {
                return CV();
            }

            public string ToSIString()
            {
                SI sI = SI.AutoDetermineUnit(value);

                return sI.BaseToSIOutput(value, "Ω");
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
                    100000000,110000000,120000000,130000000,150000000,160000000,
                    180000000,200000000,220000000,240000000,270000000,300000000,
                    330000000,360000000,390000000,430000000,470000000,510000000,
                    560000000,620000000,680000000,750000000,820000000,910000000
                };
            }
            public Resistor(double rawvalue)
            {
                value = rawvalue;
            }
        }
        public class Capacitor:ElectricalComponents
        {
            private readonly double value;
            public double[] CommonValues()
            {
                return CV();
            }
            static public double[] CV()
            {
                return new double[]
                {
                    10e-12, 12e-12, 15e-12, 18e-12, 22e-12, 27e-12,
                    33e-12, 39e-12, 47e-12, 56e-12, 68e-12, 82e-12,
                    100e-12, 120e-12, 150e-12, 180e-12, 220e-12, 270e-12,
                    330e-12, 390e-12, 470e-12, 560e-12, 680e-12, 820, 820e-12,
                    1000e-12, 1200e-12, 1500e-12, 1800e-12, 2200e-12, 2700e-12,
                    3300e-12, 3900e-12, 4700e-12, 5600e-12, 6800e-12, 8200e-12,     //25
                    0.010e-9, 0.012e-9, 0.015e-9, 0.018e-9, 0.022e-9, 0.027e-9,     //31
                    0.033e-9, 0.039e-9, 0.047e-9, 0.056e-9,0.056e-9, 0.068e-9,      //37 
                    0.082e-9, 0.10e-9, 0.12e-9, 0.15e-9, 0.18e-9, 0.22e-9, 0.27e-9, //44 
                    0.33e-9, 0.39e-9,0.47e-9, 0.56e-9, 0.68e-9, 0.82e-9, 1.0e-9, 
                    1.2e-9, 1.5e-9, 1.8e-9, 2.2e-9, 2.7e-9, 3.3e-9, 3.9e-9,
                    4.7e-9, 5.6e-9, 6.8e-9, 8.2e-9, 10e-9, 22e-9, 33e-9, 47e-9
                };
            }
            public string ToSIString()
            {
                SI sI = SI.AutoDetermineUnit(value);

                return sI.BaseToSIOutput(value,"F");

            }
            public Capacitor(double rawvalue)
            {
                value = rawvalue;
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
            none,       //  10^0    
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
        public readonly string symbol;
        /// <summary>
        /// base 10 notation exponet value
        /// </summary>
        public readonly sbyte exponent;
        public string BaseToSIOutput(double value)
        {
            value = value * Math.Pow(10,exponent);
            return value.ToString() + symbol;
        }
        public string BaseToSIOutput(double value, string Unit)
        {
            value = value * Math.Pow(10, -exponent);
            return String.Format("{0,8:###.0000}", value)  + symbol + Unit;
        }
        public static SI AutoDetermineUnit(double value)
        {
            int cts = 0;
            if (value > 1000)
            {
                while (value > 1000)
                {
                    value = value / 1000;
                    cts++;
                }
            }
            else if (value < 1)
            {
                while (value < 1)
                {
                    value = value * 1000;
                    cts--;
                }
            }
            Units UTZ;
            switch (cts)
            {
                case 1:
                    UTZ = Units.kilo;
                    break;
                case 2:
                    UTZ = Units.mega;
                    break;
                case 3:
                    UTZ = Units.giga;
                    break;
                case 4:
                    UTZ = Units.tera;
                    break;
                case 5:
                    UTZ = Units.peta;
                    break;
                case -1:
                    UTZ = Units.milli;
                    break;
                case -2:
                    UTZ = Units.micro;
                    break;
                case -3:
                    UTZ = Units.nano;
                    break;
                case -4:
                    UTZ = Units.pico;
                    break;
                case -5:
                    UTZ = Units.femto;
                    break;
                default:
                    UTZ = Units.none;
                    break;
            }
            return new SI(UTZ);
        }
        public SI(Units units)
        {
            switch (units)
            {
                case Units.peta:
                    prefix = "peta";
                    US_EnglishWord = "quadrillion";
                    symbol = "P";
                    exponent = 15;
                    break;
                case Units.tera:
                    prefix = "tera";
                    US_EnglishWord = "trillion";
                    symbol = "T";
                    exponent = 12;
                    break;
                case Units.giga:
                    prefix = "giga";
                    US_EnglishWord = "";
                    symbol = "G";
                    exponent = 9;
                    break;
                case Units.mega:
                    prefix = "mega";
                    US_EnglishWord = "million";
                    symbol = "M";
                    exponent = 6;
                    break;
                case Units.kilo:
                    prefix = "kilo";
                    US_EnglishWord = "thousand";
                    symbol = "k";
                    exponent = 3;
                    break;
                case Units.none:
                    prefix = "";
                    US_EnglishWord = "";
                    symbol = "";
                    exponent = 0;
                    break;
                case Units.milli:
                    prefix = "thousandth";
                    US_EnglishWord = "milli";
                    symbol = "m";
                    exponent = -3;
                    break;
                case Units.micro:
                    prefix = "micro";
                    US_EnglishWord = "millionth";
                    symbol = "µ";
                    exponent = -6;
                    break;
                case Units.nano:
                    prefix = "nano";
                    US_EnglishWord = "billionth";
                    symbol = "n";
                    exponent = -9;
                    break;
                case Units.pico:
                    prefix = "pico";
                    US_EnglishWord = "trillionth";
                    symbol = "p";
                    exponent = -12;
                    break;
                case Units.femto:
                    prefix = "femto";
                    US_EnglishWord = "quadrillionth";
                    symbol = "f";
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
        string ToSIString();

    }
}
