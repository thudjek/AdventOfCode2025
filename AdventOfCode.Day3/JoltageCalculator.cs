namespace AdventOfCode.Day3;

public class JoltageCalculator
{
    private readonly string[] _inputLines;
    public JoltageCalculator(string[] inputLines)
    {
        _inputLines = inputLines;
    }

    public int CalculateResultPart1()
    {
        var result = 0;

        foreach (var line in _inputLines)
        {
            var digits = ParseDigits(line);

            var firstMax = digits[0];
            var secondMax = 0;

            for (var i = 1; i < digits.Length; i++)
            {
                var currentDigit = digits[i];

                if (currentDigit > firstMax)
                {
                    if (i < digits.Length - 1)
                    {
                        firstMax = currentDigit;
                        secondMax = 0;
                    }
                    else
                    {
                        secondMax = currentDigit;
                    }
                }
                else if (currentDigit >= secondMax)
                {
                    secondMax = currentDigit;
                }
            }

            var calculatedNum = firstMax * 10 + secondMax;

            result += calculatedNum;
        }

        return result;
    }

    public long CalculateResultPart2()
    {
        long result = 0;
        var targetNumOfDigits = 12;

        foreach (var line in _inputLines)
        {
            var digits = ParseDigits(line);

            var numOfDigisPopulated = 0;
            var resultDigits = new int[targetNumOfDigits];

            var currentMax = 0;
            var lastPopulatedIndex = -1;
            var fillTheRest = false;

            while (numOfDigisPopulated < targetNumOfDigits)
            {
                if (fillTheRest)
                {
                    resultDigits[numOfDigisPopulated++] = digits[++lastPopulatedIndex];
                }
                else
                {
                    for (var i = lastPopulatedIndex + 1; i <= digits.Length - (targetNumOfDigits - numOfDigisPopulated); i++)
                    {
                        var currentDigit = digits[i];
                        if (currentDigit > currentMax)
                        {
                            currentMax = currentDigit;
                            lastPopulatedIndex = i;
                        }
                    }

                    resultDigits[numOfDigisPopulated] = currentMax;
                    numOfDigisPopulated++;
                    currentMax = 0;
                    fillTheRest = digits.Length - (lastPopulatedIndex + 1) == targetNumOfDigits - numOfDigisPopulated;
                }
            }

            long calculatedNum = 0;
            var multiplier = 100000000000;

            for (var i = 0; i < resultDigits.Length; i++)
            {
                calculatedNum += resultDigits[i] * multiplier;
                multiplier /= 10;
            }

            result += calculatedNum;
        }

        return result;
    }

    private static int[] ParseDigits(string line)
    {
        var digits = new int[line.Length];

        for (var i = 0; i < line.Length; i++)
        {
            var digit = line.AsSpan(i, 1);
            digits[i] = int.Parse(digit);
        }

        return digits;
    }
}