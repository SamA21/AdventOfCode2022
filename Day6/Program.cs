using AdventHelper;
using Day6;

var signals = AdventTextReader.GetListFromFile("data.txt");
foreach(var signal in signals)
{
    Console.WriteLine("Part 1");
    Console.WriteLine(SignalParser.ProcessedCharsP1(signal)?.ToString());
    Console.WriteLine("Part 2");
    Console.WriteLine(SignalParser.ProcessedCharsP2(signal, 14)?.ToString());
}
Console.ReadLine();