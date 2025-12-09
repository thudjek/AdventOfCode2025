using AdventOfCode.Day2;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d2p1.txt");
var inputText = File.ReadAllText(path);
var allRanges = inputText.Split(',');
var allNumbers = new List<long>();

foreach (var range in allRanges)
{
    var numbersAsString = range.Split('-');

    if (!long.TryParse(numbersAsString[0], out var firstNum) || !long.TryParse(numbersAsString[1], out var secondNum))
    {
        throw new InvalidDataException("Invalid input data.");
    }

    for (var i = firstNum; i <= secondNum; i++)
    {
        allNumbers.Add(i);
    }
}

var idCalculator = new IdCalculator(allNumbers);

Console.WriteLine(idCalculator.CalculateResultPart1());
Console.WriteLine(idCalculator.CalculateResultPart2());

Console.ReadLine();

