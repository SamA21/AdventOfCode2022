using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class Game
    {


        public static void RunGames(List<string> data)
        {
            int totalScore = 0; 
            foreach (var fight in data)
            {
                bool? won = CheckIfWon(fight);
                var results = fight.Split(' ');
                var playerPoints = ConvertSymbolToPoints((string)results[1]);
                if (won.HasValue && won.Value)
                {
                    playerPoints += 6;
                }
                else if(!won.HasValue)
                {
                    playerPoints += 3;
                }
                totalScore += playerPoints;

            }

            Console.WriteLine(totalScore);
        }
        private static bool? CheckIfWon(string fightString)
        {
            switch (fightString)
            {
                case "A X":
                case "B Y":
                case "C Z":
                    return null;
                case "A Y":
                case "B Z":
                case "C X":
                    return true;
                case "A Z":
                case "B X":
                case "C Y":
                    return false;
                default:
                    return false;
            }
        }
        private static int ConvertSymbolToPoints(string symbol)
        {
            switch (symbol)
            {
                case "A":
                case "X":
                    return 1;
                case "B":
                case "Y":
                    return 2;
                case "C":
                case "Z":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}

