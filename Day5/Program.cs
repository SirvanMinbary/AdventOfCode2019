using System;
using System.Collections.Generic;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static List<int> GetInput()
        {
            var input = InputHelper.InputService.GetDataFromResource("day5.txt");

            var split = input[0].Split(',');

            List<int> intcodes = new List<int>();

            foreach (var item in split)
            {
                intcodes.Add(int.Parse(item));
            }

            return intcodes;
        }

        private enum Opcode
        {
            Add = 1,
            Multiply,
            Save,
            Output,
            Halt = 99
        }
    }
}