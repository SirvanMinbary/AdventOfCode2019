using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class Day1Tests
    {
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void CalculateFuel_ReturnsCorrect(int mass, int fuelRequired)
        {
            var result = Day1.Program.CalculateFuel(mass);

            Assert.AreEqual(result, fuelRequired);
        }

        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void CalculateFuelForFuel_ReturnsCorrect(int mass, int fuelRequired)
        {
            var result = Day1.Program.CalculateFuelForFuel(mass);

            Assert.AreEqual(result, fuelRequired);
        }
    }
}
