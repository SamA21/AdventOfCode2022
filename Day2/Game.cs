using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class Game
    {
        public static void RunGamesP1(List<string> data)
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
                else if (!won.HasValue)
                {
                    playerPoints += 3;
                }
                totalScore += playerPoints;

            }

            Console.WriteLine(totalScore);
        }


        public static void RunGamesP2(List<string> data)
        {
            int totalScore = 0;
            foreach (var fight in data)
            {
                var results = fight.Split(' ');
                var resultNeeded = CheckResultNeeded((string)results[1]);
                var cheatedFightString = GetResultNeeded(resultNeeded, (string)results[0]);
                var results2 = cheatedFightString.Split(' ');
                var playerPoints = ConvertSymbolToPoints((string)results2[1]);
                if (resultNeeded.HasValue && resultNeeded.Value)
                {
                    playerPoints += 6;
                }
                else if (!resultNeeded.HasValue)
                {
                    playerPoints += 3;
                }
                totalScore += playerPoints;
            }

            Console.WriteLine(totalScore);
        }

        private static string GetResultNeeded(bool? resultNeeded, string oppenentSymbol)
        {
            switch (resultNeeded)
            {
                case true:
                    return AWinResult(oppenentSymbol);
                case false:
                    return ALoseResult(oppenentSymbol);
                case null:
                    return ADrawResult(oppenentSymbol);
            }
        }

        private static string AWinResult(string oppenentSymbol)
        {

            switch (oppenentSymbol)
            {
                case "A":
                    return "A Y";
                case "B":
                    return "B Z";
                case "C":
                    return "C X";
                default:
                    return string.Empty;
            }
        }
        private static string ALoseResult(string oppenentSymbol)
        {
            switch (oppenentSymbol)
            {
                case "A":
                    return "A Z";
                case "B":
                    return "B X";
                case "C":
                    return "C Y";
                default:
                    return string.Empty;
            }
        }
        private static string ADrawResult(string oppenentSymbol)
        {
            switch (oppenentSymbol)
            {
                case "A":
                    return "A X";
                case "B":
                    return "B Y";
                case "C":
                    return "C Z";
                default:
                    return string.Empty;
            }
        }
        private static bool? CheckResultNeeded(string resultNeeded)
        {
            switch (resultNeeded)
            {
                case "X":
                    return false;
                case "Y":
                    return null;
                case "Z":
                    return true;
                default:
                    return false;
            }
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

