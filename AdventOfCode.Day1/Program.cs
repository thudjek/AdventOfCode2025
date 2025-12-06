using AdventOfCode.Day1;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d1p1.txt");
var allInputs = File.ReadAllLines(path);

var safe = new Safe();

Console.WriteLine(safe.CalculateResultPart1(allInputs));
Console.WriteLine(safe.CalculateResultPart2(allInputs));

Console.ReadLine();