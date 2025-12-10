namespace AdventOfCode.Day5;

public class IngredientIdCalculator
{
    private readonly List<(long Min, long Max)> ranges;
    private readonly List<long> numbers;

    public IngredientIdCalculator(string[] inputLines)
    {
        ranges = [];
        numbers = [];
        ParseInputLines(inputLines);
    }

    public int CalculateResultPart1()
    {
        var result = 0;

        foreach (var number in numbers)
        {
            foreach (var (Min, Max) in ranges)
            {
                if (number > Min && number < Max)
                {
                    result++;
                    break;
                }
            }
        }

        return result;
    }

    public long CalculateResultPart2()
    {
        long result = 0;
        var handeledRanges = new List<(long Min, long Max)>();

        foreach (var (Min, Max) in ranges)
        {
            result += HandleRange((Min, Max), handeledRanges);
        }

        return result;
    }

    private static long HandleRange((long Min, long Max) currentRange, List<(long Min, long Max)> handeledRanges)
    {
        long currentResult = 0;

        var handleRange = true;

        foreach (var (HandeledMin, HandeledMax) in handeledRanges)
        {
            if (currentRange.Min >= HandeledMin && currentRange.Max <= HandeledMax)
            {
                handleRange = false;
                break;
            }

            if (currentRange.Min < HandeledMin && currentRange.Max >= HandeledMin && currentRange.Max <= HandeledMax)
            {
                var subRange = (currentRange.Min, HandeledMin - 1);
                currentResult += HandleRange(subRange, handeledRanges);
                handleRange = false;
                break;
            }

            if (currentRange.Max > HandeledMax && currentRange.Min >= HandeledMin && currentRange.Min <= HandeledMax)
            {
                var subRange = (HandeledMax + 1, currentRange.Max);
                currentResult += HandleRange(subRange, handeledRanges);
                handleRange = false;
                break;
            }

            if (currentRange.Min < HandeledMin && currentRange.Max > HandeledMax)
            {
                var subRange1 = (currentRange.Min, HandeledMin - 1);
                var subRange2 = (HandeledMax + 1, currentRange.Max);
                currentResult += HandleRange(subRange1, handeledRanges);
                currentResult += HandleRange(subRange2, handeledRanges);
                handleRange = false;
                break;
            }
        }

        if (handleRange)
        {
            handeledRanges.Add((currentRange.Min, currentRange.Max));
            currentResult += currentRange.Max - currentRange.Min + 1;
        }

        return currentResult;
    }

    private void ParseInputLines(string[] inputLines)
    {
        var blankLineReached = false;

        foreach (var line in inputLines)
        {
            if (string.IsNullOrEmpty(line))
            {
                blankLineReached = true;
                continue;
            }

            if (blankLineReached)
            {
                numbers.Add(long.Parse(line));
            }
            else
            {
                var rangeNumbers = line.Split("-");
                var min = long.Parse(rangeNumbers[0]);
                var max = long.Parse(rangeNumbers[1]);
                ranges.Add((min, max));
            }
        }
    }
}