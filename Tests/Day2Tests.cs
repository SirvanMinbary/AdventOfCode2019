using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    internal class Day2Tests
    {
        [Test]
        public void ProcessIntcodes()
        {
            var intcodes = new List<int> { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var expected = new List<int> { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };

            Day2.Program.ProcessGravityAssistProgram(intcodes);

            CollectionAssert.AreEqual(expected, intcodes);
        }
    }
}
