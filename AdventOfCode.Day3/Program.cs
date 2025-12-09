using AdventOfCode.Day3;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d3p1.txt");
var inputLines = File.ReadAllLines(path);

var joltageCalculator = new JoltageCalculator(inputLines);

Console.WriteLine(joltageCalculator.CalculateResultPart1());
Console.WriteLine(joltageCalculator.CalculateResultPart2());

Console.ReadLine();