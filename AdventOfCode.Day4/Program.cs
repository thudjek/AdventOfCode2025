using AdventOfCode.Day4;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d4p1.txt");
var inputLines = File.ReadAllLines(path);

var rollsCalculator = new RollsCalculator(inputLines);

Console.WriteLine(rollsCalculator.CalculateResultPart1());
Console.WriteLine(rollsCalculator.CalculateResultPart2());

Console.ReadLine();
