using AdventOfCode.Day6;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d6p1.txt");
var inputLines = File.ReadAllLines(path);

var mathHomework = new MathHomework(inputLines);

//Console.WriteLine(mathHomework.CalculateResultPart1());
Console.WriteLine(mathHomework.CalculateResultPart2());

Console.ReadLine();