using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public sealed class PairManager
    {
        public IEnumerable<int> Pair1Range { get; init; } = new List<int>();
        public IEnumerable<int> Pair2Range { get; init; } = new List<int>();

        public PairManager(string pairLine)
        {
            var pairs = pairLine.Split(',');
            foreach (var pair in pairs)
            {
                if (pairs.First().Equals(pair))
                {
                    Pair1Range = GetNumbers(pair); 
                }

                if (pairs.Last().Equals(pair))
                {
                    Pair2Range = GetNumbers(pair); 
                }
            } 
        }

        public bool CheckIfFullyContain()
        {
            if (Pair1Range.Intersect(Pair2Range).Count() == Pair1Range.Count() || Pair2Range.Intersect(Pair1Range).Count() == Pair2Range.Count())
                return true;
            else
                return false;
        }
        public bool CheckIfRangesOverlap()
        {
            if (Pair1Range.Where(x => Pair2Range.Contains(x)).Count() > 0 || Pair2Range.Where(x => Pair1Range.Contains(x)).Count() > 0)
                return true;
            else
                return false;
        }
        private IEnumerable<int> GetNumbers(string pair)
        {
            var numbers = pair.Split('-');
            int number1 = int.Parse(numbers[0]);
            int number2 = int.Parse(numbers[1]);

            return Enumerable.Range(number1, number2 - number1 + 1);
        }
    }
}
