using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string input = "372037-905157";

            var split = input.Split('-');
            var start = int.Parse(split[0]);
            var end = int.Parse(split[1]);

            var possiblePasswords = CountPossiblePassword(start, end);

            Console.WriteLine($"possible passwords: {possiblePasswords}");

            var possiblePasswordsPartTwo = CountPossiblePasswordsPartTwo(start, end);

            Console.WriteLine($"part two: {possiblePasswordsPartTwo}");

            Console.ReadLine();
        }

        public static bool IsPasswordValid(string password)
        {
            List<int> digits = ProcessStringToDigits(password);

            bool adjacentDoubleDigits = false;

            for (int i = 0; i < digits.Count; i++)
            {
                int current = digits[i];

                int nextIndex = i + 1;
                int? next = nextIndex < digits.Count ? (int?)digits[nextIndex] : null;

                if (next.HasValue)
                {
                    if (current == next.Value)
                    {
                        adjacentDoubleDigits = true;
                    }
                    else if (current > next.Value)
                    {
                        return false;
                    }
                }
            }

            return adjacentDoubleDigits;
        }

        public static bool IsPasswordValidPartTwo(string password)
        {
            var digits = ProcessStringToDigits(password);

            bool adjacentDoubleDigits = false;

            var digitDoubles = new Dictionary<int, int>(); // Key is what digit, Value is how many times

            AddDuplicateDigits(digits, digitDoubles);

            for (int i = 0; i < digits.Count; i++)
            {
                int current = digits[i];

                var next = GetNextOrNull(digits, i);

                if (next.HasValue)
                {
                    if (current == next.Value)
                    {
                        adjacentDoubleDigits = true;
                    }
                    else if (current > next.Value)
                    {
                        return false;
                    }
                }
            }

            return adjacentDoubleDigits && RepeatedDigitsAreInDoubles(digitDoubles);
        }

        private static int? GetNextOrNull(List<int> digits, int index)
        {
            int nextIndex = index + 1;
            return nextIndex < digits.Count ? (int?)digits[nextIndex] : null;
        }

        private static void AddDuplicateDigits(List<int> digits, Dictionary<int, int> dict)
        {
            foreach (var item in digits.GroupBy(x => x).Where(x => x.Count() > 1))
            {
                dict.Add(item.Key, item.Count());
            }
        }

        private static bool RepeatedDigitsAreInDoubles(Dictionary<int, int> dict)
        {
            foreach (var item in dict)
            {
                bool isEven = item.Value % 2 == 0;
                if (!isEven)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> ProcessStringToDigits(string password)
        {
            var digits = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                var digit = password.Substring(i, 1);
                digits.Add(int.Parse(digit));
            }

            return digits;
        }

        public static int CountPossiblePassword(int start, int end)
        {
            int count = 0;
            int delta = end - start;

            for (int i = 0; i < delta; i++)
            {
                string password = (start + i).ToString();
                if (IsPasswordValid(password))
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountPossiblePasswordsPartTwo(int start, int end)
        {
            int count = 0;
            int delta = end - start;

            for (int i = 0; i < delta; i++)
            {
                string password = (start + i).ToString();
                if (ValidPassword2(int.Parse(password)))
                {
                    count++;
                }
            }

            return count;
        }

        public static bool ValidPassword2(int n)
        {
            int temp = n;

            /* check for digit ascending */
            bool isAscending = true;
            bool hasDuplicate = false;
            bool checkingForDups = true;

            int duplicateCount = 0;

            var lastDigit = 0;
            while (temp != 0)
            {
                lastDigit = temp % 10;
                temp = temp / 10;

                if (temp % 10 > lastDigit)
                {
                    isAscending = false;
                    break;
                }

                if (temp % 10 == lastDigit && checkingForDups)
                {
                    if (hasDuplicate)
                    {
                        duplicateCount++;
                    }
                    else
                    {
                        hasDuplicate = true;
                        duplicateCount = 2;
                    }
                } else
                {
                    if ( duplicateCount == 2)
                    {
                        checkingForDups = false;
                    } else
                    {
                        duplicateCount = 0;
                        hasDuplicate = false;
                    }
                }


            }
            return isAscending && hasDuplicate;
        }
    }
}
