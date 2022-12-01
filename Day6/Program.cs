using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = InputHelper.InputService.GetDataFromResource("day6.txt");

            var orbitals = new List<Orbital>();

            foreach (var item in input)
            {
                var split = item.Split(')');
                var beingOrbited = split[0];
                var inOrbit = split[1];

                var orbital = new Orbital { Name = inOrbit, Orbits = beingOrbited };
                orbitals.Add(orbital);
            }

            foreach (var item in orbitals)
            {
                var currentOrbit = item;
                while (true)
                {
                    var next = orbitals.FirstOrDefault(x => x.Name == currentOrbit.Orbits);
                    if (next == null)
                    {
                        item.TotalOrbits.Add(item.Orbits);
                        break;
                    }
                    item.TotalOrbits.Add(next.Name);
                    currentOrbit = next;
                }
            }

            Console.WriteLine("Total orbits are: " + orbitals.Sum(x => x.TotalOrbits.Count));

            var you = orbitals.First(x => x.Name == "YOU");
            var santa = orbitals.First(x => x.Name == "SAN");

            var commonOrbits = you.TotalOrbits.Intersect(santa.TotalOrbits);

            Orbital earliestCommon = null;
            var transfers = 0;

            foreach (var item in you.TotalOrbits)
            {
                if (commonOrbits.Contains(item))
                {
                    earliestCommon = orbitals.First(x => x.Name == item);
                    break;
                }
                transfers++;
            }

            var currentOrbitFromSanta = orbitals.First(x => x.Name == santa.Orbits);
            while (true)
            {
                if (currentOrbitFromSanta.Name == earliestCommon.Name)
                {
                    break;
                }

                transfers++;
                currentOrbitFromSanta = orbitals.First(x => x.Name == currentOrbitFromSanta.Orbits);
            }

            Console.WriteLine("Total transfers from YOU to SAN is: " + transfers);
        }
    }

    internal class Orbital
    {
        public string Name { get; set; }
        public string Orbits { get; set; }
        public List<string> TotalOrbits { get; set; } = new List<string>();
    }
}