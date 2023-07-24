// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System;
using System.Formats.Asn1;
using FractionOperations.Models;
using FractionOperations.Utilities;

namespace FractionOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter an expression: ");
                string? expression = Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(expression))
                        throw new ArgumentException("Invalid Expression");
                    else if (expression.Trim().ToLower() == "exit")
                        break;

                    expression = expression.Trim();
                    
                    string result = GenerateFinalOutput(expression);
                    
                    Console.WriteLine("= " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static string GenerateFinalOutput(string input)
        {
            var ans = FractionOps.Calculate(input);
            ans = FractionOps.ReduceFraction(ans);
            return ExpressionHelpers.Stringify(ans);
        }
    }
}