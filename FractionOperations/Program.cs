// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System;
using System.Formats.Asn1;
using FractionOperations.Models;
using FractionOperations.Utilities;

namespace FractionOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter an expression or type 'exit': ");
                    string? expression = Console.ReadLine();
                    
                    var result = GenerateFinalOutput(expression?.Trim());
                    
                    if (result == "exit")
                        break;
                    
                    Console.WriteLine("= " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static string GenerateFinalOutput(string? expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("Invalid Expression");
            
            else if (expression.ToLower() == "exit")
                return "exit";
            
            var ans = FractionOps.Calculate(expression);

            ans = FractionOps.ReduceFraction(ans);

            string result = ExpressionHelpers.Stringify(ans);

            return result;
        }
    }
}