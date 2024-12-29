class Program
{
    static List<(int row, int col)> FindTrailHeads(List<string> input)
    {
        var trailHeadLocations = new List<(int row, int col)>();

        for (int row = 0; row < input.Count; row++)
        {
            for (int col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == '0')
                {
                    trailHeadLocations.Add((row, col));
                }
            }
        }

        return trailHeadLocations;
    }

    static bool IsInWorld(int row, int col, List<string> world)
    {
        return row >= 0 && row < world.Count && col >= 0 && col < world[row].Length;
    }

    static int Find9s(int row, int col, List<string> input, HashSet<string> found, int prev = -1)
    {
        if (!IsInWorld(row, col, input))
        {
            return 0;
        }

        char curValChar = input[row][col];
        if (curValChar == '.')
        {
            return 0;
        }

        int curVal = curValChar - '0';
        if (prev + 1 != curVal)
        {
            return 0;
        }

        if (curVal == 9)
        {
            found.Add($"{row}:{col}");
            return 1;
        }

        return Find9s(row, col - 1, input, found, curVal) +
               Find9s(row, col + 1, input, found, curVal) +
               Find9s(row - 1, col, input, found, curVal) +
               Find9s(row + 1, col, input, found, curVal);
    }

    static (int part1Count, int part2Count) ParseInput(string fileName)
    {
        var input = new List<string>(File.ReadAllLines(fileName));
        var trailHeads = FindTrailHeads(input);

        int part1Count = 0;
        int part2Count = 0;

        foreach (var (row, col) in trailHeads)
        {
            var found = new HashSet<string>();
            part2Count += Find9s(row, col, input, found);
            part1Count += found.Count;
        }

        return (part1Count, part2Count);
    }

    static void Main()
    {
        var result1 = ParseInput("input.txt");
        Console.WriteLine(result1);

        var result2 = ParseInput("input.txt");
        Console.WriteLine(result2);
    }
}
