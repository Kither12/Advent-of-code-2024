using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static readonly (int dy, int dx)[] Directions =
    {
        (-1, 0), (0, 1), (1, 0), (0, -1)
    };

    static (Dictionary<(int y, int x), int> grid, (int y, int x) cur) BuildGrid(string fileName)
    {
        var grid = new Dictionary<(int y, int x), int>();
        (int y, int x) cur = (-1, -1);

        foreach (var (row, y) in File.ReadLines(fileName).Select((line, y) => (line.Trim(), y)))
        {
            for (int x = 0; x < row.Length; x++)
            {
                char el = row[x];
                if (el == '.')
                {
                    grid[(y, x)] = 0;
                }
                else if (el == '#')
                {
                    grid[(y, x)] = -1;
                }
                else
                {
                    grid[(y, x)] = 1;
                    cur = (y, x);
                }
            }
        }

        return (grid, cur);
    }

    static ((int y, int x)? newPos, int directionIndex) CalcNextPos(Dictionary<(int y, int x), int> grid, (int y, int x) cur, int directionIndex)
    {
        var (dy, dx) = Directions[directionIndex];
        var newPos = (cur.y + dy, cur.x + dx);

        if (!grid.ContainsKey(newPos))
        {
            return (null, directionIndex);
        }
        else if (grid[newPos] == -1)
        {
            directionIndex = (directionIndex + 1) % Directions.Length;
            return CalcNextPos(grid, cur, directionIndex);
        }
        else
        {
            return (newPos, directionIndex);
        }
    }

    static void Main(string[] args)
    {
        string fileName = args.Length > 0 ? args[0] : "input.txt";
        int directionIndex = 0;

        var (grid, cur) = BuildGrid(fileName);
        int visited1 = 1;

        var visited = new List<(int y, int x)>();

        bool onGrid = true;
        while (onGrid)
        {
            var (newPos, newDirectionIndex) = CalcNextPos(grid, cur, directionIndex);

            if (!newPos.HasValue)
            {
                onGrid = false;
                break;
            }
            else
            {
                if (grid[newPos.Value] == 0)
                {
                    visited1++;
                    visited.Add(newPos.Value);
                    grid[newPos.Value] = 1;
                }
                cur = newPos.Value;
                directionIndex = newDirectionIndex;
            }
        }

        Console.WriteLine($"Part 1 Visited {visited1} cells");

        int loop2 = 0;
        foreach (var pos in visited)
        {
            (grid, cur) = BuildGrid(fileName);
            grid[pos] = -1;

            onGrid = true;
            directionIndex = 0;
            var loopVisited = new List<(int y, int x)>();
            int index = 0;
            int max = grid.Keys.Count + 1;

            while (onGrid)
            {
                var (newPos, newDirectionIndex) = CalcNextPos(grid, cur, directionIndex);
                index++;

                if (!newPos.HasValue)
                {
                    onGrid = false;
                    break;
                }
                else if (index > max)
                {
                    loop2++;
                    onGrid = false;
                    break;
                }
                else
                {
                    if (grid[newPos.Value] == 0)
                    {
                        loopVisited.Add(newPos.Value);
                        grid[newPos.Value] = 1;
                    }
                    cur = newPos.Value;
                    directionIndex = newDirectionIndex;
                }
            }
        }

        Console.WriteLine($"Part 2: The total number of loops is {loop2}");
    }
}