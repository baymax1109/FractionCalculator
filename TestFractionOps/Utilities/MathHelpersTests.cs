using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionOperations.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperations.Utilities.Tests
{
    [TestClass()]
    public class MathHelpersTests
    {
        [TestMethod()]
        public void GcdTest()
        {
            int gcdAns = 3;

            var gcd = MathHelpers.Gcd(-9, 12);

            Assert.AreEqual(gcdAns, gcd);
        }

        [TestMethod()]
        public void LcmTest()
        {
            int lcmAns = 6;

            var lcm = MathHelpers.Lcm(2, 3);

            Assert.AreEqual(lcmAns, lcm);
        }
    }
}