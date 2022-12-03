using AdventHelper;
using Day3;
using System.Linq;

var backpacks = AdventTextReader.GetListFromFile("data.txt");
int points = 0;
var sorter = new Sorter("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
points = sorter.SetupBackpacks(backpacks);

Console.WriteLine(points);
points = sorter.SetupBackpackGroups(backpacks);
Console.WriteLine(points);
Console.ReadLine();
