using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputHelper.InputService.GetDataFromResource("Day3.txt");
            var wire1 = new Wire();
            var wire2 = new Wire();

            ParseWireInput(input[0], wire1);
            ParseWireInput(input[1], wire2);
            var intersections = FindIntersections(wire1, wire2);

            var distances = new List<int>();
            foreach (var item in intersections)
            {
                distances.Add(CalculateManhattanDistance(item));
            }

            distances = distances.OrderBy(d => d).ToList();

            Console.WriteLine($"shortest distance is {distances[0]}");

            var steps = intersections.Select(p => p.StepsTaken).OrderBy(x => x).ToList();

            Console.WriteLine($"shortest steps taken is {steps[0]}");

            Console.ReadLine();
        }

        public static void ParseWireInput(string wireInput, Wire wire)
        {
            foreach (var instruction in wireInput.Split(','))
            {
                var direction = instruction.Substring(0, 1);
                var steps = int.Parse(instruction.Substring(1));

                for (int i = 0; i < steps; i++)
                {
                    wire.MoveWire(direction);
                }
            }
        }

        public static List<Position> FindIntersections(Wire wire1, Wire wire2)
        {
            var intersections = new List<Position>();

            foreach (var position in wire1.PositionHistory)
            {
                if (position.X == 0 && position.Y == 0)
                {
                    continue;
                }

                var intersection = wire2.PositionHistory.Find(p => p.X == position.X && p.Y == position.Y);
                if (intersection != null)
                {
                    intersection.StepsTaken += position.StepsTaken;
                    intersections.Add(intersection);
                }
            }

            return intersections;
        }

        public static int CalculateManhattanDistance(Position position)
        {
            return Math.Abs(position.X) + Math.Abs(position.Y);
        }

        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int StepsTaken { get; set; }
        }

        public class Wire
        {
            public Position CurrentPosition { get; set; } = new Position();
            public List<Position> PositionHistory { get; set; } = new List<Position>();

            public void MoveWire(string direction)
            {
                PositionHistory.Add(new Position { X = CurrentPosition.X, Y = CurrentPosition.Y, StepsTaken = CurrentPosition.StepsTaken });

                switch (direction)
                {
                    case "U":
                        CurrentPosition.X++;
                        break;
                    case "R":
                        CurrentPosition.Y++;
                        break;
                    case "D":
                        CurrentPosition.X--;
                        break;
                    case "L":
                        CurrentPosition.Y--;
                        break;
                }

                CurrentPosition.StepsTaken++;
            }
        }
    }
}
