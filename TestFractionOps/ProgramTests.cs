using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionOperations.Models;
using FractionOperations.Utilities;

namespace FractionOperations.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GenerateFinalOutputTest_ValidExpression()
        {
            string expression = "0 * 2 + 3/4 - -3&1/2 / 20/3";

            var expected = "1&11/40";

            var actual = Program.GenerateFinalOutput(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GenerateFinalOutputTest_exit()
        {
            string expression = "exit";

            var expected = "exit";

            var actual = Program.GenerateFinalOutput(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateFinalOutputTest_EmptyOrNull()
        {
            Program.GenerateFinalOutput("");
        }
    }
}