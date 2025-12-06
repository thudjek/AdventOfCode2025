namespace AdventOfCode.Day1;

public class Safe
{
    private const int totalNumbers = 100;

    private int currentNumber = 0;

    public int CalculateResultPart1(string[] inputs)
    {
        currentNumber = 50;
        var result = 0;

        foreach (var input in inputs)
        {
            var (Direction, Value) = ParseInput(input);

            if (Direction == 'R')
            {
                currentNumber += Value;

                if (currentNumber <= 99)
                {
                    continue;
                }

                currentNumber %= totalNumbers;

                if (currentNumber == 0)
                {
                    result++;
                }
            }
            else
            {
                currentNumber -= Value;

                if (currentNumber < 0)
                {
                    currentNumber = Math.Abs(currentNumber);

                    while (currentNumber > totalNumbers)
                    {
                        currentNumber -= totalNumbers;
                    }

                    currentNumber = (totalNumbers - currentNumber) % totalNumbers;
                }

                if (currentNumber == 0)
                {
                    result++;
                }
            }
        }

        return result;
    }

    public int CalculateResultPart2(string[] inputs)
    {
        currentNumber = 50;
        var result = 0;

        foreach (var input in inputs)
        {
            var (Direction, Value) = ParseInput(input);

            if (Direction == 'R')
            {
                currentNumber += Value;

                if (currentNumber <= 99)
                {
                    continue;
                }

                var numOfTimesZeroWasPassed = currentNumber / totalNumbers;

                currentNumber %= totalNumbers;

                result += numOfTimesZeroWasPassed;
            }
            else
            {
                var prevNumber = currentNumber;
                currentNumber -= Value;

                if (currentNumber == 0)
                {
                    result++;
                    continue;
                }

                if (currentNumber < 0)
                {
                    currentNumber = Math.Abs(currentNumber);

                    int numOfTimesZeroWasPassed;

                    if (prevNumber == 0 && currentNumber <= 99)
                    {
                        numOfTimesZeroWasPassed = 0;
                    }
                    else if (prevNumber == 0 && currentNumber > 99)
                    {
                        numOfTimesZeroWasPassed = currentNumber / totalNumbers;
                    }
                    else
                    {
                        numOfTimesZeroWasPassed = (currentNumber + totalNumbers) / totalNumbers;
                    }

                    while (currentNumber > totalNumbers)
                    {
                        currentNumber -= totalNumbers;
                    }

                    currentNumber = (totalNumbers - currentNumber) % totalNumbers;

                    result += numOfTimesZeroWasPassed;
                }
            }
        }

        return result;
    }

    private static (char Direction, int Value) ParseInput(string input)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(input);

        var direction = input[0];

        if (direction != 'R' && direction != 'L')
        {
            throw new ArgumentException($"Invalid direction in input {input}.");
        }

        if (!int.TryParse(input.AsSpan(1), out var value))
        {
            throw new ArgumentException($"Invalid value in input {input}.");
        }

        return (direction, value);
    }
}