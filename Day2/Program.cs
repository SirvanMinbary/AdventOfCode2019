using System;
using System.Collections.Generic;

namespace Day2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var intcodes = GetInput();
            intcodes[1] = 12;
            intcodes[2] = 2;

            ProcessGravityAssistProgram(intcodes);

            Console.WriteLine(intcodes[0]);

            var output = FindNounVerbPair(19690720);
            Console.WriteLine(output);

            Console.ReadLine();
        }

        public static void ProcessGravityAssistProgram(List<int> intcodes)
        {
            int index = 0;

            while (intcodes[index] != 99)
            {
                var first = ValueAtPosition(intcodes, index + 1);
                var second = ValueAtPosition(intcodes, index + 2);
                int sum = 0;

                var opcode = (Opcode)intcodes[index];
                switch (opcode)
                {
                    case Opcode.Add:
                        sum = first + second;
                        break;
                    case Opcode.Multiply:
                        sum = first * second;
                        break;
                    default:
                        throw new Exception();
                }

                var sumIndex = GetSumIndex(index);
                var valueAtSumIndex = intcodes[sumIndex];
                intcodes[valueAtSumIndex] = sum;

                index = GetNextOpIndex(index);
            }
        }

        private static int FindNounVerbPair(int target)
        {
            var pair = new NounVerbPair();

            while (true)
            {
                var intcodes = GetInput();
                intcodes[1] = pair.Noun;
                intcodes[2] = pair.Verb;

                ProcessGravityAssistProgram(intcodes);

                if (intcodes[0] == target)
                {
                    break;
                }

                if (pair.Noun == 99)
                {
                    pair.Noun = 0;
                    pair.Verb++;
                }
                else
                {
                    pair.Noun++;
                }
            }

            return CalculateNounVerbOutput(pair);
        }

        private static int CalculateNounVerbOutput(NounVerbPair pair)
        {
            return (100 * pair.Noun) + pair.Verb;
        }

        private class NounVerbPair
        {
            public int Noun { get; set; }
            public int Verb { get; set; }
        }

        private static int GetSumIndex(int index)
        {
            return index + 3;
        }

        private static int GetNextOpIndex(int index)
        {
            return index + 4;
        }

        private static int ValueAtPosition(List<int> intcodes, int pos)
        {
            var x = intcodes[pos];

            return intcodes[x];
        }

        private static List<int> GetInput()
        {
            var input = InputHelper.InputService.GetDataFromResource("Day2.txt");

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
            Multiply = 2,
            Halt = 99
        }
    }
}
