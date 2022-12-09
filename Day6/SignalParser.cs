using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class SignalParser
    {
        public static Marker? ProcessedCharsP1(string signal)
        {
            int count = 0;
            int index = 0;
            bool foundBuffer = false;
            while (!foundBuffer)
            {
                List<char> charsTested = new List<char>();
                foreach (char c in signal.Skip(index).Take(4))
                {
                    charsTested.Add(c);

                    if (charsTested.Where(x => x == c).Count() > 1)
                    {
                        count = 0;
                        var matchedIndex = charsTested.LastIndexOf(c);
                        var firstMatchedIndex = charsTested.IndexOf(c);
                        var indexDif = matchedIndex - firstMatchedIndex;
                        index = index - indexDif + 1;
                        break;
                    }
                    else
                    {
                        count++;
                        if(count == 4)
                        {
                            foundBuffer = true;
                            var markerString = new string(charsTested.ToArray());
                            var markerIndex = signal.IndexOf(markerString) + markerString.Length;
                            return new Marker(markerString, markerIndex); 
                        }
                    }
                    index++;
                }
            }

            return null;

        }

        public static Marker? ProcessedCharsP2(string signal, int matchAmmount)
        {
            int count = 0;
            int index = 0;
            bool foundBuffer = false;
            while (!foundBuffer)
            {
                List<char> charsTested = new List<char>();
                foreach (char c in signal.Skip(index).Take(matchAmmount))
                {
                    charsTested.Add(c);

                    if (charsTested.Where(x => x == c).Count() > 1)
                    {
                        count = 0;
                        var matchedIndex = charsTested.LastIndexOf(c);
                        var firstMatchedIndex = charsTested.IndexOf(c);
                        var indexDif = matchedIndex - firstMatchedIndex;
                        index = index - indexDif + 1;
                        break;
                    }
                    else
                    {
                        count++;
                        if (count == matchAmmount)
                        {
                            foundBuffer = true;
                            var markerString = new string(charsTested.ToArray());
                            var markerIndex = signal.IndexOf(markerString) + markerString.Length;
                            return new Marker(markerString, markerIndex);
                        }
                    }
                    index++;
                }
            }

            return null;

        }
    }
}
