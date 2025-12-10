namespace AdventOfCode.Day6;

public class MathHomework
{
    private string[,] grid;
    private readonly int numberOfRows;
    private readonly int numberOfColumns;

    private readonly string[] _inputLines;
    public MathHomework(string[] inputLines)
    {
        _inputLines = inputLines;
    }

    public long CalculateResultPart1()
    {
        ParseInputLines(_inputLines);

        long result = 0;

        for (int i = 0; i < numberOfColumns; i++)
        {
            long currentResult = 0;
            string operation = null;

            for (int j = numberOfRows - 1; j >= 0; j--)
            {
                if (long.TryParse(grid[j, i], out var num))
                {
                    currentResult = operation == "*"
                        ? currentResult * num
                        : currentResult + num;

                    continue;
                }

                operation = grid[j, i];

                if (operation == "*")
                {
                    currentResult = 1;
                }
            }

            result += currentResult;
        }

        return result;
    }

    public long CalculateResultPart2()
    {
        long result = 0;
        var numberOfRows = _inputLines.Length;
        var numberOfColumns = _inputLines[0].Length;
        var numbers = new List<long>();

        for (int i = numberOfColumns - 1; i >= 0; i--)
        {
            char? operation = null;
            long currentResult = 0;
            long currentNumber = 0;
            var digitList = new List<long>();

            for (int j = 0; j < numberOfRows; j++)
            {
                var ch = _inputLines[j][i];

                if (j == numberOfRows - 1)
                {
                    for (int k = 0; k < digitList.Count; k++)
                    {
                        currentNumber += digitList[k] * (long)Math.Pow(10, digitList.Count - 1 - k);
                    }

                    digitList.Clear();
                    numbers.Add(currentNumber);

                    if (ch == '+' || ch == '*')
                    {
                        operation = ch;
                        i--;

                        if (ch == '*')
                        {
                            currentResult = 1;
                        }
                    }

                    break;
                }

                if (long.TryParse(ch.ToString(), out var digit))
                {
                    digitList.Add(digit);
                }
            }

            if (operation != null)
            {
                foreach (var num in numbers)
                {
                    currentResult = operation == '*'
                        ? currentResult * num
                        : currentResult + num;
                }

                numbers.Clear();
                result += currentResult;
            }
        }

        return result;
    }

    private void ParseInputLines(string[] inputLines)
    {
        for (var i = 0; i < inputLines.Length; i++)
        {
            var splitLine = inputLines[i].Split(" ").ToList();
            splitLine.RemoveAll(x => x == "");

            grid ??= new string[inputLines.Length, splitLine.Count];

            for (int j = 0; j < splitLine.Count; j++)
            {
                grid[i, j] = splitLine[j];
            }
        }
    }
}