using AdventHelper;
using Day1;

var allLines = AdventTextReader.GetListFromFile("data.txt", true);
Console.WriteLine(allLines.Count);
var elves = Calories.ConvertData(allLines);
var maxCalories = elves.Max(x => x.TotalCalories);
Console.WriteLine(maxCalories); 
Console.ReadLine();
