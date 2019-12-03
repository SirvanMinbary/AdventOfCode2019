using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = InputHelper.InputService.GetDataFromResource("Day 1 part 1.txt");

            int fuelRequiredForModules = 0;

            foreach (var item in input)
            {
                var parsed = int.Parse(item);
                fuelRequiredForModules += CalculateFuel(parsed);
            }

            Console.WriteLine(fuelRequiredForModules);

            int totalRequiredFuel = 0;

            foreach (var item in input)
            {
                var parsed = int.Parse(item);
                totalRequiredFuel += CalculateFuelForFuel(parsed);
            }

            Console.WriteLine(totalRequiredFuel);

            Console.ReadLine();
        }

        public static int CalculateFuel(int module)
        {
            return (module / 3) - 2;
        }

        public static int CalculateFuelForFuel(int module)
        {
            int total = CalculateFuel(module);

            int remainder = total;

            while (remainder > 0)
            {
                remainder = CalculateFuel(remainder);
                if (remainder > 0)
                {
                    total += remainder;
                }
            }

            return total;
        }
    }
}
