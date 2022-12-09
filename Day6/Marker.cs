using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Marker
    {
        public string MatchedString { get; init; }
        public int FoundIndex { get; set; }
        public Marker(string marker, int indexFound)
        {
            MatchedString = marker;
            FoundIndex = indexFound;
        }

        public override string ToString()
        {
            return $"Found marker {MatchedString.ToString()} at index {FoundIndex}";
        }
    }
}
