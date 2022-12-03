using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Sorter
    {
        public char[] Priorities { get; init; }
        public Sorter()
        {
            Priorities = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }
        public int GetPriority(char result)
        {
            var index = Array.IndexOf(Priorities, result);
            return index += 1;
        }

        public int SetupBackpacks(List<string> backpacks)
        {
            int points = 0; 
            foreach (var backpack in backpacks)
            {
                var currentBackpack = new BackpackManager(backpack);
                var intersect = currentBackpack.Compartment1.Intersect(currentBackpack.Compartment2);
                int pointResult = GetPriority(intersect.First());
                points += pointResult;
            }
            return points;
        }
    }
}
