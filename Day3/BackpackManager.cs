using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class BackpackManager
    {
        public string Compartment1 {get;set;} = string.Empty;
        public string Compartment2 {get;set;} = string.Empty;

        public BackpackManager(string backpackInfo)
        {
            if (backpackInfo.Length % 2 == 0)
            {
                var halfLength = backpackInfo.Length / 2;
                Compartment1 = backpackInfo.Substring(0, halfLength);
                Compartment2 = backpackInfo.Substring(halfLength, halfLength);
            }
            else
            {
                //error can't split                
            }
        }
    }
}
