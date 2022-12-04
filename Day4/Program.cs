using AdventHelper;
using Day4;

var pairs = AdventTextReader.GetListFromFile("data.txt");
Console.WriteLine(pairs.Count);
int fullyContainPairs = 0;
int overlapPairs = 0;

foreach (var pair in pairs)
{
    var pairManager = new PairManager(pair);
    bool doesFullyContain = pairManager.CheckIfFullyContain();
    if(doesFullyContain)
        fullyContainPairs++;
    bool doesOverlap = pairManager.CheckIfRangesOverlap();
    if (doesOverlap)
        overlapPairs++;
}
Console.WriteLine(fullyContainPairs);
Console.WriteLine(overlapPairs);
Console.ReadLine();