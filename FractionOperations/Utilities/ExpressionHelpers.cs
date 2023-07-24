using FractionOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperations.Utilities
{
    public class ExpressionHelpers
    {
        public static string[] ParseExpression(string expression)
        {
            string[] terms = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (terms.Length % 2 == 0)
                throw new ArgumentException("Invalid expression");

            return terms;
        }

        public static string Stringify(Fraction frac)
        {
            string ans = "";

            if (frac.Whole == 0 && frac.Numerator == 0)
                return "0";

            if (frac.Whole != 0)
            {
                ans = String.Format("{0}", frac.Whole);
                if (frac.Numerator != 0)
                    ans += "&";
            }

            if (frac.Numerator != 0)
                ans += String.Format("{0}/{1}", Math.Abs(frac.Numerator), Math.Abs(frac.Denominator));

            return ans;
        }
    }
}
