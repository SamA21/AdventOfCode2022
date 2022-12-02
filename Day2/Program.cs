using AdventHelper;
using Day2;

var strategy = AdventTextReader.GetListFromFile("data.txt");
Console.WriteLine(strategy.Count);
Game.RunGames(strategy);
Console.ReadLine();