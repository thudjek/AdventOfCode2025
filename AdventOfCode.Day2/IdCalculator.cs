namespace AdventOfCode.Day2;

public class IdCalculator
{
    public static long CalculateResultPart1(List<long> inputNumbers)
    {
        long result = 0;

        foreach (var inputNumber in inputNumbers)
        {
            var numAsString = inputNumber.ToString();

            if (numAsString.Length % 2 != 0)
            {
                continue;
            }

            var firstPart = numAsString.AsSpan(0, numAsString.Length / 2);
            var secondPart = numAsString.AsSpan(numAsString.Length / 2);

            if (firstPart.SequenceEqual(secondPart))
            {
                result += inputNumber;
            }
        }

        return result;
    }

    public static long CalculateResultPart2(List<long> inputNumbers)
    {
        long result = 0;

        foreach (var inputNumber in inputNumbers)
        {
            var numAsString = inputNumber.ToString();

            if (numAsString.Length == 1)
            {
                continue;
            }

            if (IsNumberWithSameDigits(numAsString))
            {
                result += inputNumber;
                continue;
            }

            var divisors = GetAllDivisors(numAsString.Length);

            if (divisors.Count == 0)
            {
                continue;
            }

            foreach (var divisor in divisors)
            {
                if (DoesNumberContainSameParts(numAsString, divisor))
                {
                    result += inputNumber;
                    break;
                }
            }
        }

        return result;
    }

    private static bool IsNumberWithSameDigits(string numAsString)
    {
        var firstChar = numAsString[0];

        for (var i = 1; i < numAsString.Length; i++)
        {
            if (numAsString[i] != firstChar)
            {
                return false;
            }
        }

        return true;
    }

    public static bool DoesNumberContainSameParts(string numAsString, int numOfParts)
    {
        var lengthOfOnePart = numAsString.Length / numOfParts;
        var firstPart = numAsString.AsSpan(0, lengthOfOnePart);
        var nextStartIndex = lengthOfOnePart;

        for (int i = 2; i <= numOfParts; i++)
        {
            var nextPart = numAsString.AsSpan(nextStartIndex, lengthOfOnePart);
            nextStartIndex += lengthOfOnePart;

            if (!firstPart.SequenceEqual(nextPart))
            {
                return false;
            }
        }

        return true;
    }

    private static List<int> GetAllDivisors(int num)
    {
        var result = new List<int>();
        for (var i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                result.Add(i);
            }
        }

        return result;
    }
}