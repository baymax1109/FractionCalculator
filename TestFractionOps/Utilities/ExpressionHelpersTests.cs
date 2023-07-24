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
    public class ExpressionHelpersTests
    {
        /// <summary>
        /// ParseExpression() function tests
        /// </summary>
        [TestMethod()]
        public void ParseExpressionTest_BinomialExpression()
        {
            var expectedRes = new string[] { "1&2/3", "/", "2&1/2" };
            var monomials = ExpressionHelpers.ParseExpression("   1&2/3 / 2&1/2  ");
    
            Assert.IsTrue(monomials.Length == 3);
            CollectionAssert.AreEqual(expectedRes, monomials);
        }

        [TestMethod()]
        public void ParseExpressionTest_PolynomialExpression()
        {
            var expectedRes = new string[] { "1&2/3", "/", "2&1/2", "+", "1/2"};
            var monomials = ExpressionHelpers.ParseExpression("   1&2/3 / 2&1/2 + 1/2 ");

            Assert.IsTrue(monomials.Length == 5);
            CollectionAssert.AreEqual(expectedRes, monomials);
        }

        [TestMethod()]
        public void ParseExpressionTest_SingleTerm()
        {
            var expectedToken = "1&2/3";
            var monomials = ExpressionHelpers.ParseExpression(" 1&2/3    ");

            Assert.AreEqual(expectedToken, monomials[0]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseExpressionTest_ExpressionWithNoOperator()
        {
            ExpressionHelpers.ParseExpression("1&2/3 2&1/2");
        }

        /// <summary>
        /// Stringify() function tests
        /// </summary>

        [TestMethod()]
        public void StringifyTest_ValidMixedFraction()
        {
            string expected = "1&1/2";

            Fraction frac = new Fraction(1, 1, 2);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(expected, strFrac);
        }

        [TestMethod()]
        public void StringifyTest_ValidProperFraction()
        {
            string expected = "1/2";

            Fraction frac = new Fraction(0, 1, 2);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(expected, strFrac);
        }

        [TestMethod()]
        public void StringifyTest_ValidWholeNumber()
        {
            string expected = "-1/7";

            Fraction frac = new Fraction(0, -1, 7);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(expected, strFrac);
        }
        
        [TestMethod()]
        public void StringifyTest_ValidZeroValue()
        {
            string expected = "0";

            Fraction frac = new Fraction(0, 0, 1);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(expected, strFrac);
        }


        [TestMethod()]
        public void StringifyTest_ValidNegativeMixedFraction()
        {
            string expected = "-1&1/2";

            Fraction frac = new Fraction(-1, 1, 2);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(expected, strFrac);
        }
    }
}