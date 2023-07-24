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
        [TestMethod()]
        public void ParseExpressionTest()
        {
            var monomials = ExpressionHelpers.ParseExpression("1&2/3 / 2&1/2");
            
            Assert.IsTrue(monomials.Length == 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseExpressionTest_Invalid()
        {
            ExpressionHelpers.ParseExpression("1&2/3 2&1/2");
        }

        [TestMethod()]
        public void StringifyTest_ValidMixedFraction()
        {
            string actual = "1&1/2";

            Fraction frac = new Fraction(1, 1, 2);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(actual, strFrac);
        }

        [TestMethod()]
        public void StringifyTest_ValidFraction()
        {
            string actual = "1/2";

            Fraction frac = new Fraction(0, 1, 2);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(actual, strFrac);
        }

        [TestMethod()]
        public void StringifyTest_ValidWhole()
        {
            string actual = "1";

            Fraction frac = new Fraction(1);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(actual, strFrac);
        }
        
        [TestMethod()]
        public void StringifyTest_ValidZero()
        {
            string actual = "0";

            Fraction frac = new Fraction(0, 0, 1);
            var strFrac = ExpressionHelpers.Stringify(frac);

            Assert.AreEqual(actual, strFrac);
        }
    }
}