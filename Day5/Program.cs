using Day5;

var crane = new CraneManager("data.txt");
crane.MoveDataUsingSetInstructions(false);
crane.TopItems();
crane.MoveDataUsingSetInstructions(true);
Console.WriteLine("Part 2");
crane.TopItems();
Console.ReadLine();
