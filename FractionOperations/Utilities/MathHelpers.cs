using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperations.Utilities
{
    public class MathHelpers
    {
        public static int Lcm(int a, int b)
        {
            var gcd = Gcd(a, b);
            return Math.Abs(a / gcd * b);
        }

        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}
