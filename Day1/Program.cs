using AdventHelper;
using Day1;

var allLines = AdventTextReader.GetListFromFile("data.txt", true);
Console.WriteLine(allLines.Count);
var elves = Calories.ConvertData(allLines);
var maxCalories = elves.Max(x => x.TotalCalories);
Console.WriteLine(maxCalories); 
var maxCalories3Elves = elves.OrderByDescending(x => x.TotalCalories).Take(3).Sum(x => x.TotalCalories);
Console.WriteLine(maxCalories3Elves);
Console.ReadLine();