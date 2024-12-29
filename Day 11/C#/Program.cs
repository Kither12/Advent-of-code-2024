class Program
{
    static void Main()
    {
        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        var inputLines = ReadLines(inputFilePath);
        var solution = Solve(inputLines);
        Console.WriteLine($"Part 1: {solution.Part1}");
        Console.WriteLine($"Part 2: {solution.Part2}");
    }

    static List<string> ReadLines(string inputFilePath)
    {
        return new List<string>(File.ReadAllLines(inputFilePath));
    }

    static (long Part1, long Part2) Solve(List<string> inputLines)
    {
        var stones = inputLines[0].Split(' ');

        return (
            Blink(stones, 25),
            Blink(stones, 75)
        );
    }

    static long Blink(string[] stones, long n)
    {
        var cache = new Dictionary<string, long>();

        long SolveStone(string stone, long n)
        {
            if (n == 0)
            {
                return 1;
            }

            var cacheKey = $"{stone},{n}";
            if (cache.ContainsKey(cacheKey))
            {
                return cache[cacheKey];
            }

            long result;

            if (stone == "0")
            {
                result = SolveStone("1", n - 1);
            }
            else if (stone.Length % 2 == 0)
            {
                var middleIndex = stone.Length / 2;
                var a = stone.Substring(0, middleIndex);
                var b = stone.Substring(middleIndex);
                result = SolveStone(Parselong(a).ToString(), n - 1) +
                         SolveStone(Parselong(b).ToString(), n - 1);
            }
            else
            {
                result = SolveStone((Parselong(stone) * 2024).ToString(), n - 1);
            }

            cache[cacheKey] = result;
            return result;
        }

        long sum = 0;
        foreach (var stone in stones)
        {
            sum += SolveStone(stone, n);
        }

        return sum;
    }

    static long Parselong(string value)
    {
        if (long.TryParse(value, out var result))
        {
            return result;
        }
        throw new FormatException($"Invalid longeger value: {value}");
    }
}
