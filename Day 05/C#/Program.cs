using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static int Solve1(List<string> lines, int id)
    {
        int ans = 0;

        foreach (var update in lines.Skip(id + 1))
        {
            var nums = update.Split(',').Select(int.Parse).ToList();
            var hashMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Count; i++)
            {
                hashMap[nums[i]] = i;
            }

            bool flag = true;
            foreach (var rule in lines.Take(id))
            {
                var parts = rule.Split('|').Select(int.Parse).ToArray();
                int a = parts[0], b = parts[1];
                if (!hashMap.ContainsKey(a) || !hashMap.ContainsKey(b)) continue;
                if (hashMap[a] > hashMap[b])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                ans += nums[nums.Count / 2];
            }
        }

        return ans;
    }

    static void Fix(List<int> nums, int[,] cmp)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (cmp[nums[i], nums[j]] == -1)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
        }
    }

    static bool Check(List<int> nums, int[,] cmp)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (cmp[nums[i], nums[j]] == -1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    static int Solve2(List<string> lines, int id)
    {
        int[,] cmp = new int[100, 100];
        foreach (var rule in lines.Take(id))
        {
            var parts = rule.Split('|').Select(int.Parse).ToArray();
            int a = parts[0], b = parts[1];
            cmp[a, b] = 1;
            cmp[b, a] = -1;
        }

        int ans = 0;

        foreach (var update in lines.Skip(id + 1))
        {
            var nums = update.Split(',').Select(int.Parse).ToList();
            if (Check(nums, cmp))
            {
                continue;
            }

            Fix(nums, cmp);
            ans += nums[nums.Count / 2];
        }

        return ans;
    }

    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt").ToList();
        int id = lines.IndexOf("");

        Console.WriteLine("Answer of Day 5 part 1: " + Solve1(lines, id));
        Console.WriteLine("Answer of Day 5 part 2: " + Solve2(lines, id));
    }
}