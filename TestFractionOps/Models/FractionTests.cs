using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperations.Models.Tests
{
    [TestClass()]
    public class FractionTests
    {
        [TestMethod()]
        public void FractionTest()
        {
            Fraction fraction = new Fraction();
            
            Assert.IsNotNull(fraction);
        }
        
        [TestMethod()]
        public void FractionTest2()
        {
            Fraction testfrac = new Fraction();
            testfrac.Whole = 1;
            testfrac.Numerator = 2;
            testfrac.Denominator = 3;
            
            Fraction fraction = new Fraction(1,2,3);

            Assert.ReferenceEquals(fraction, testfrac);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void FractionTest3()
        {
            Fraction fraction = new Fraction(1, 2, 0);
        }
    }
}