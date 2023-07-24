using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionOperations.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionOperations.Models;

namespace FractionOperations.Utilities.Tests
{
    [TestClass()]
    public class FractionOpsTests
    {
        [TestMethod()]
        public void CalculateTest_ValidExpression()
        {
            string expression = "0 * 2 + 3/4 - -3&1/2 / 20/3";

            var expected = new Fraction(0, 51, 40);

            var actual = FractionOps.Calculate(expression);

            ValidateTestData(expected, actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTest_InvalidExpression()
        {
            string expression = "0 x 3";

            var actual = FractionOps.Calculate(expression);
        }


        [TestMethod()]
        public void AddTest_TwoFractions()
        {
            var ans = new Fraction(0, 9, 4);

            var a = new Fraction(1, 1, 2);
            var b = new Fraction(0, 3, 4);

            var res = FractionOps.Add(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void AddTest_TwoNegativeFractions()
        {
            var ans = new Fraction(0, -9, 4);

            var a = new Fraction(-1, 1, 2);
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Add(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void AddTest_OnePostiveOneNegativeFraction()
        {
            var ans = new Fraction(0, 3, 4);

            var a = new Fraction(1, 1, 2);
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Add(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest_null()
        {
            Fraction a = null;
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Add(a, b);
        }

        [TestMethod()]
        public void MultiplyTest_TwoPositiveFractions()
        {
            var ans = new Fraction(0, 6, 6);

            var a = new Fraction(1, 1, 2);
            var b = new Fraction(0, 2, 3);

            var res = FractionOps.Multiply(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void MultiplyTest_TwoNegativeFractions()
        {
            var ans = new Fraction(0, 6, 6);

            var a = new Fraction(-1, 1, 2);
            var b = new Fraction(0, -2, 3);

            var res = FractionOps.Multiply(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void MultiplyTest_OnePositiveOneNegativeFractions()
        {
            var ans = new Fraction(0, -6, 6);

            var a = new Fraction(1, 1, 2);
            var b = new Fraction(0, -2, 3);

            var res = FractionOps.Multiply(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MultiplyTest_null()
        {
            Fraction a = null;
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Multiply(a, b);
        }


        [TestMethod()]
        public void DivideTest_TwoPositiveFractions()
        {
            var ans = new Fraction(0, 9, 10);

            var a = new Fraction(1, 1, 2);
            var b = new Fraction(0, 5, 3);

            var res = FractionOps.Divide(a, b);
            //res = FractionOps.ReduceFraction(res);

            ValidateTestData(ans, res);
        }
        [TestMethod()]
        public void DivideTest_OnePositiveOneNegativeFraction()
        {
            var ans = new Fraction(0, -9, 10);

            var a = new Fraction(-1, 1, 2);
            var b = new Fraction(0, 5, 3);

            var res = FractionOps.Divide(a, b);

            ValidateTestData(ans, res);
        }
        [TestMethod()]
        public void DivideTest_TwoNegativeFractions()
        {
            var ans = new Fraction(0, -9, -10);

            var a = new Fraction(-1, 1, 2);
            var b = new Fraction(0, -5, 3);

            var res = FractionOps.Divide(a, b);

            ValidateTestData(ans, res);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DivideTest_null()
        {
            Fraction a = null;
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Divide(a, b);
        }


        [TestMethod()]
        public void SubtractTest_TwoPositiveFractions()
        {
            var ans = new Fraction(0, 9, 4);

            var a = new Fraction(4, 3, 4);
            var b = new Fraction(2, 1, 2);

            var res = FractionOps.Subtract(a, b);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void SubtractTest_TwoNegativeFractions()
        {
            var ans = new Fraction(0, -9, 4);

            var a = new Fraction(-4, 3, 4);
            var b = new Fraction(-2, 1, 2);

            var res = FractionOps.Subtract(a, b);
            //res = FractionOps.ReduceFraction(res);

            ValidateTestData(ans, res);
        }

        [TestMethod()]
        public void SubtractTest_OnePositiveOneNegativeFractions()
        {
            var ans = new Fraction(0, -29, 4);

            var a = new Fraction(-4, 3, 4);
            var b = new Fraction(2, 1, 2);

            var res = FractionOps.Subtract(a, b);
            //res = FractionOps.ReduceFraction(res);

            ValidateTestData(ans, res);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubtractTest_null()
        {
            Fraction a = null;
            var b = new Fraction(0, -3, 4);

            var res = FractionOps.Subtract(a, b);
        }


        [TestMethod()]
        public void ReduceFractionTest()
        {
            Fraction res = new Fraction(0, 1, 2);

            var inpfrac = new Fraction(0, 15, 30);

            var reduced = FractionOps.ReduceFraction(inpfrac);

            ValidateTestData(res, reduced);
        }
        [TestMethod()]
        public void ReduceFractionWhole()
        {
            Fraction res = new Fraction(2, 0);

            var inpfrac = new Fraction(0, 60, 30);

            var reduced = FractionOps.ReduceFraction(inpfrac);

            ValidateTestData(res, reduced);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReduceFractionNull()
        {
            FractionOps.ReduceFraction(null);
        }

        [TestMethod()]
        public void ParseFractionTest_Whole()
        {
            string fracStr = "1";

            var expected = new Fraction(1);

            var actual = FractionOps.ParseFraction(fracStr);

            ValidateTestData(expected, actual);
        }
        [TestMethod()]
        public void ParseFractionTest_Improper()
        {
            string fracStr = "22/7";

            var expected = new Fraction(0, 22, 7);

            var actual = FractionOps.ParseFraction(fracStr);

            ValidateTestData(expected, actual);
        }
        [TestMethod()]
        public void ParseFractionTest_Mixed()
        {
            string fracStr = "1&22/7";

            var expected = new Fraction(1, 22, 7);

            var actual = FractionOps.ParseFraction(fracStr);

            ValidateTestData(expected, actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseFraction_nullString()
        {
            string fracStr = null;
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString0()
        {
            string fracStr = "/&";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString1()
        {
            string fracStr = "1l2";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString2()
        {
            string fracStr = "1/2&3";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString3()
        {
            string fracStr = "1&2&";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString4()
        {
            string fracStr = "1&-2";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString5()
        {
            string fracStr = "1&2/-3";
            FractionOps.ParseFraction(fracStr);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseFraction_InvalidString6()
        {
            string fracStr = "ajshfv";
            FractionOps.ParseFraction(fracStr);
        }

        public void ValidateTestData(Fraction expected, Fraction actual)
        {
            Assert.AreEqual(expected.Whole, actual.Whole);
            Assert.AreEqual(expected.Numerator, actual.Numerator);
            Assert.AreEqual(expected.Denominator, actual.Denominator);
        }
    }
}