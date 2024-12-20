class Program
{
    static int Solve1(string input)
    {
        int ans = 0;

        var lines = input.TrimEnd()
            .Split('\n')
            .Select(line => line.Split(' ')
                .Select(int.Parse)
                .ToList())
            .ToList();

        foreach (var x in lines)
        {
            if (IsSortedDescending(x) || IsSortedAscending(x))
            {
                bool valid = true;
                for (int i = 0; i < x.Count - 1; i++)
                {
                    if (Math.Abs(x[i] - x[i + 1]) < 1 || Math.Abs(x[i] - x[i + 1]) > 3)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    ans++;
            }
        }

        return ans;
    }

    static int Solve2(string input)
    {
        int ans = 0;

        var lines = input.TrimEnd()
            .Split('\n')
            .Select(line => line.Split(' ')
                .Select(int.Parse)
                .ToList())
            .ToList();

        foreach (var x in lines)
        {
            if (!Check(x))
            {
                for (int i = 0; i < x.Count; i++)
                {
                    var tmp = new List<int>(x);
                    tmp.RemoveAt(i);

                    if (Check(tmp))
                    {
                        ans++;
                        break;
                    }
                }
            }
            else
            {
                ans++;
            }
        }

        return ans;
    }

    static bool Check(List<int> a)
    {
        if (!(IsSortedDescending(a) || IsSortedAscending(a)))
            return false;

        for (int i = 0; i < a.Count - 1; i++)
        {
            if (Math.Abs(a[i] - a[i + 1]) < 1 || Math.Abs(a[i] - a[i + 1]) > 3)
                return false;
        }

        return true;
    }

    static bool IsSortedDescending(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] < list[i + 1])
                return false;
        }
        return true;
    }

    static bool IsSortedAscending(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
                return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        string content = File.ReadAllText("input.txt");

        Console.WriteLine($"Answers to Day 2 Part 1 is: {Solve1(content)}");
        Console.WriteLine($"Answers to Day 2 Part 2 is: {Solve2(content)}");
    }
}