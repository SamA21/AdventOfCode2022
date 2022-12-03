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
        public Sorter(string priorities)
        {
            Priorities = priorities.ToCharArray();
        }
        private int GetPriority(char result)
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

        public int SetupBackpackGroups(List<string> backpacks)
        {
            int points = 0;
            int index = 0;
            while(index < backpacks.Count)
            {
                var backPackGroup = backpacks.Take(new Range(index, index+3)).ToArray();
                var intersect = backPackGroup[0].Intersect(backPackGroup[1]).Intersect(backPackGroup[2]);
                int pointResult = GetPriority(intersect.First());
                points += pointResult;
                index += 3;
            }
            return points;
        }
    }
}
