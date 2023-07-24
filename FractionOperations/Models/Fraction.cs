using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperations.Models
{
    public class Fraction
    {
        public int Whole { get; set; } = 0;
        public int Numerator { get; set; } = 0;
        public int Denominator { get; set; } = 1;

        public Fraction(int whole = 0, int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
                throw new ArgumentException("Invalid Expression. Can't divide by 0");
            Whole = whole;
            Numerator = numerator;
            Denominator = denominator;
        }
    }
}
