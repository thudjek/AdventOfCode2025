using AdventOfCode.Day5;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_d5p1.txt");
var inputLines = File.ReadAllLines(path);

var ingredientIdCalculator = new IngredientIdCalculator(inputLines);

Console.WriteLine(ingredientIdCalculator.CalculateResultPart1());
Console.WriteLine(ingredientIdCalculator.CalculateResultPart2());

Console.ReadLine();