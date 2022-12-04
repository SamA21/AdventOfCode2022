using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public sealed class PairManager
    {
        public int Pair1Min { get; init; }
        public int Pair1Max { get; init; }
        public int Pair2Min { get; init; }
        public int Pair2Max { get; init; }

        public PairManager(string pairLine)
        {
            var pairs = pairLine.Split(',');
            foreach (var pair in pairs)
            {
                if (pairs.First().Equals(pair))
                {
                    var numbers = GetNumbers(pair);
                    Pair1Min = numbers.Item1;
                    Pair1Max = numbers.Item2;

                }

                if (pairs.Last().Equals(pair))
                {
                    var numbers = GetNumbers(pair);
                    Pair2Min = numbers.Item1;
                    Pair2Max = numbers.Item2;
                }
            } 
        }

        public bool CheckIfFullyContain()
        {
            var pair1 = Enumerable.Range(Pair1Min, Pair1Max - Pair1Min + 1);
            var pair2 = Enumerable.Range(Pair2Min, Pair2Max - Pair2Min + 1);
            if (pair1.Intersect(pair2).Count() == pair1.Count() || pair2.Intersect(pair1).Count() == pair2.Count())
                return true;
            else
                return false;
        }
        public bool CheckIfRangesOverlap()
        {
            var pair1 = Enumerable.Range(Pair1Min, Pair1Max - Pair1Min + 1);
            var pair2 = Enumerable.Range(Pair2Min, Pair2Max - Pair2Min + 1);
            if (pair1.Where(x => pair2.Contains(x)).Count() > 0 || pair2.Where(x => pair1.Contains(x)).Count() > 0)
                return true;
            else
                return false;
        }
        private (int, int) GetNumbers(string pair)
        {
            var numbers = pair.Split('-');
            int number1 = int.Parse(numbers[0]);
            int number2 = int.Parse(numbers[1]);
            return (number1, number2);
        }
    }
}
