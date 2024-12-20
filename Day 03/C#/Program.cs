using System.Text.RegularExpressions;

class Program
{
    static long Solve1(string input)
    {
        long ans = 0;
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

        foreach (Match match in regex.Matches(input))
        {
            long num1 = long.Parse(match.Groups[1].Value);
            long num2 = long.Parse(match.Groups[2].Value);
            ans += num1 * num2;
        }

        return ans;
    }

    static long Solve2(string mem)
    {
        long ans = 0;
        bool doSum = true;

        var regex = new Regex(@"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)");

        foreach (Match match in regex.Matches(mem))
        {
            switch (match.Value)
            {
                case "do()":
                    doSum = true;
                    break;
                case "don't()":
                    doSum = false;
                    break;
                default:
                    if (doSum)
                    {
                        int x = int.Parse(match.Groups[1].Value);
                        int y = int.Parse(match.Groups[2].Value);
                        ans += x * y;
                    }
                    break;
            }
        }

        return ans;
    }

    static void Main(string[] args)
    {
        string text = File.ReadAllText("input.txt");

        Console.WriteLine($"Answer for Day 3 Part 1: {Solve1(text)}");
        Console.WriteLine($"Answer for Day 3 Part 2: {Solve2(text)}");
    }
}