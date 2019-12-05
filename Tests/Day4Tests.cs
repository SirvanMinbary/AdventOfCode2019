using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class Day4Tests
    {
        [TestCase("111111", true)]
        [TestCase("223450", false)]
        [TestCase("123789", false)]
        public void IsPasswordValid(string password, bool expected)
        {
            var isValid = Day4.Program.IsPasswordValid(password);

            Assert.AreEqual(expected, isValid);
        }

        [TestCase("112233", true)]
        [TestCase("123444", false)]
        [TestCase("111122", true)]
        [TestCase("232111", false)]
        [TestCase("223450", false)]
        [TestCase("898989", false)]
        [TestCase("989898", false)]
        public void IsPasswordValidPartTwo(string password, bool expected)
        {
            var isValid = Day4.Program.IsPasswordValidPartTwo(password);

            Assert.AreEqual(expected, isValid);
        }
    }
}
