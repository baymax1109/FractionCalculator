using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionOperations.Models;

namespace FractionOperations.Utilities
{
    public class FractionOps
    {
        public static Fraction Calculate(string input)
        {
            string[] terms = ExpressionHelpers.ParseExpression(input);
            var stack = new Stack<Fraction>();

            Fraction FirstOperand = ParseFraction(terms[0]);
            stack.Push(FirstOperand);

            for (int i = 2; i < terms.Length; i += 2)
            {
                var operand = ParseFraction(terms[i]);
                var operation = terms[i - 1];

                if (operation == "+")
                {
                    stack.Push(operand);
                }
                else if (operation == "-")
                {
                    operand = Subtract(new Fraction(), operand);
                    stack.Push(operand);
                }
                else if (operation == "*")
                {
                    var operand1 = stack.Pop();
                    var ans = Multiply(operand1, operand);
                    stack.Push(ans);
                }
                else if (operation == "/")
                {
                    var operand1 = stack.Pop();
                    var ans = Divide(operand1, operand);
                    stack.Push(ans);
                }
                else
                    throw new ArgumentException("Invalid Expression");
            }
            Fraction answer = stack.ElementAt(0);
            for (int i = 1; i < stack.Count(); i++)
            {
                answer = Add(answer, stack.ElementAt(i));
            }
            return answer;
        }

        public static Fraction Add(Fraction a, Fraction b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Null fraction");

            //int gcd = Gcd(a.Denominator, b.Denominator);
            int lcm = MathHelpers.Lcm(a.Denominator, b.Denominator);

            int quotienta = lcm / a.Denominator;
            int quotientb = lcm / b.Denominator;

            a = ConvertToImproperFraction(a);
            b = ConvertToImproperFraction(b);

            int numerator = a.Numerator * quotienta + b.Numerator * quotientb;

            var ans = new Fraction(0, numerator, lcm);
            //ans = ReduceFraction(ans, gcd);

            return ans;
        }

        public static Fraction Multiply(Fraction a, Fraction b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Null fraction");

            a = ConvertToImproperFraction(a);
            b = ConvertToImproperFraction(b);

            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;

            return new Fraction(0, numerator, denominator);
        }

        public static Fraction Divide(Fraction a, Fraction b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Null fraction");

            a = ConvertToImproperFraction(a);
            b = ConvertToImproperFraction(b);

            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;

            return new Fraction(0, numerator, denominator);
        }

        public static Fraction Subtract(Fraction a, Fraction b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Null fraction");
            //int gcd = Gcd(a.Denominator, b.Denominator);
            int lcm = MathHelpers.Lcm(a.Denominator, b.Denominator);

            int quotienta = lcm / a.Denominator;
            int quotientb = lcm / b.Denominator;

            a = ConvertToImproperFraction(a);
            b = ConvertToImproperFraction(b);

            int numerator = a.Numerator * quotienta - b.Numerator * quotientb;

            var ans = new Fraction(0, numerator, lcm);
            //ans = ReduceFraction(ans, gcd);

            return ans;
        }




        static Fraction ConvertToImproperFraction(Fraction frac)
        {
            if (frac == null)
                throw new ArgumentNullException("Null fraction");
            var isNegativeFraction = false;
            if(frac.Numerator < 0 || frac.Whole < 0)
            {
                isNegativeFraction = true;
                frac.Numerator = Math.Abs(frac.Numerator);
                frac.Whole = Math.Abs(frac.Whole);
            }
            var improperNumerator = frac.Whole * frac.Denominator + frac.Numerator;
            if (isNegativeFraction)
            {
                improperNumerator *= -1;
            }
            return new Fraction(0, improperNumerator, frac.Denominator);
        }

        public static Fraction ReduceFraction(Fraction frac)
        {
            if (frac == null)
                throw new ArgumentNullException("Null fraction");

            frac.Numerator += frac.Whole * frac.Denominator;
            var gcd = MathHelpers.Gcd(frac.Numerator, frac.Denominator);

            frac.Numerator /= gcd;
            frac.Denominator /= gcd;

            frac.Whole = frac.Numerator / frac.Denominator;
            frac.Numerator %= frac.Denominator;

            return frac;
        }

        public static Fraction ParseFraction(string input)
        {
            if(input == null)
                throw new ArgumentNullException("input");
            
            string[] nums = input.Split(new char[] { '&', '/' });

            if (nums.Length == 0)
                throw new ArgumentException("Invalid Expression");


            if (nums.Length == 1 && int.TryParse(input, out int n))
            {
                return new Fraction(n);
            }

            else if (input.Contains('/') && nums.Length == 2)
            {
                if (input[nums[0].Length] != '/')
                    throw new ArgumentException("Invalid Expression");
                int numerator = int.Parse(nums[0]);

                return new Fraction(0, numerator, int.Parse(nums[1]));
            }

            else if (input.Contains('&') && input.Contains('/') && nums.Length == 3)
            {
                if (input[nums[0].Length] != '&' || input[nums[0].Length + nums[1].Length + 1] != '/')
                    throw new ArgumentException("Invalid Expression");
                int whole = int.Parse(nums[0]);
                int numerator = int.Parse(nums[1]);
                int denominator = int.Parse(nums[2]);

                if (whole != 0 && (numerator < 0 || denominator < 0))
                    throw new ArgumentException("Invalid Expression");

                if (whole < 0)
                    numerator = -1 * numerator;

                return new Fraction(whole, numerator, int.Parse(nums[2]));
            }

            else
                throw new ArgumentException("Invalid expression");
        }
    }
}
