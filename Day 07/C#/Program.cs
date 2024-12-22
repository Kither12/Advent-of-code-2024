class Program
{
    static long Concat(long a, long b)
    {
        return long.Parse($"{a}{b}");
    }

    static bool IsSolvable(long target, List<long> args, List<Func<long, long, long>> operations)
    {
        return args.Skip(1).Aggregate(new List<long> { args[0] }, (acc, x) =>
        {
            var newAcc = new List<long>();
            foreach (var value in acc)
            {
                foreach (var op in operations)
                {
                    newAcc.Add(op(value, x));
                }
            }
            return newAcc;
        }).Any(x => x == target);
    }

    static (long target, List<long> numbers) ParseLine(string line)
    {
        var parts = line.Split(':');
        long target = long.Parse(parts[0]);
        var numbers = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        return (target, numbers);
    }

    static long SolveA(string filePath)
    {
        var operators = new List<Func<long, long, long>> { (a, b) => a + b, (a, b) => a * b };

        return File.ReadLines(filePath)
            .Select(ParseLine)
            .Where(pair => IsSolvable(pair.target, pair.numbers, operators))
            .Select(pair => pair.target)
            .Sum();
    }

    static long SolveB(string filePath)
    {
        var operators = new List<Func<long, long, long>> { (a, b) => a + b, (a, b) => a * b, Concat };

        return File.ReadLines(filePath)
            .Select(ParseLine)
            .Where(pair => IsSolvable(pair.target, pair.numbers, operators))
            .Select(pair => pair.target)
            .Sum();
    }

    static void Main(string[] args)
    {
        string filePath = "./input.txt";
        Console.WriteLine($"Part 1: {SolveA(filePath)}");
        Console.WriteLine($"Part 2: {SolveB(filePath)}");
    }
}
