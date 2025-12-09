namespace AdventOfCode.Day4;

public class RollsCalculator
{
    private const char At = '@';
    private const char Dot = '.';

    private bool[,] currentGrid;
    private bool[,] nextGrid;
    private int lastRowIndex;
    private int lastColumnIndex;

    public RollsCalculator(string[] inputLines)
    {
        ParseInputLinesToGrid(inputLines);
        lastRowIndex = currentGrid.GetLength(0) - 1;
        lastColumnIndex = currentGrid.GetLength(1) - 1;
    }

    public int CalculateResultPart1()
    {
        var result = 0;

        for (var row = 0; row <= lastRowIndex; row++)
        {
            for (var col = 0; col <= lastColumnIndex; col++)
            {
                if (!currentGrid[row, col])
                {
                    continue;
                }

                var adjacentRollNum = 0;

                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;

                        if ((row + i < 0) || (row + i > lastRowIndex) || (col + j < 0) || (col + j > lastColumnIndex))
                            continue;

                        if (currentGrid[row + i, col + j])
                            adjacentRollNum++;
                    }
                }

                if (adjacentRollNum < 4)
                {
                    result++;
                }
            }
        }

        return result;
    }

    public int CalculateResultPart2()
    {
        int iterationResult;
        var totalResult = 0;

        do
        {
            iterationResult = 0;

            for (var row = 0; row <= lastRowIndex; row++)
            {
                for (var col = 0; col <= lastColumnIndex; col++)
                {
                    if (!currentGrid[row, col])
                    {
                        continue;
                    }

                    var adjacentRollNum = 0;

                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;

                            if ((row + i < 0) || (row + i > lastRowIndex) || (col + j < 0) || (col + j > lastColumnIndex))
                                continue;

                            if (currentGrid[row + i, col + j])
                                adjacentRollNum++;
                        }
                    }

                    if (adjacentRollNum < 4)
                    {
                        iterationResult++;
                        nextGrid[row, col] = false;
                    }
                }
            }

            totalResult += iterationResult;
            currentGrid = nextGrid;

        } while (iterationResult != 0);

        return totalResult;
    }

    private void ParseInputLinesToGrid(string[] inputLines)
    {
        for (int i = 0; i < inputLines.Length; i++)
        {
            for (int j = 0; j < inputLines[i].Length; j++)
            {
                currentGrid ??= new bool[inputLines.Length, inputLines[i].Length];
                nextGrid ??= new bool[inputLines.Length, inputLines[i].Length];

                currentGrid[i, j] = inputLines[i][j] == At;
                nextGrid[i, j] = inputLines[i][j] == At;
            }
        }
    }
}