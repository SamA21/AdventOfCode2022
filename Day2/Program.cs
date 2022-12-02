using AdventHelper;
using Day2;

var strategy = AdventTextReader.GetListFromFile("data.txt");
Console.WriteLine(strategy.Count);
Game.RunGamesP1(strategy);
Game.RunGamesP2(strategy);
Console.ReadLine();