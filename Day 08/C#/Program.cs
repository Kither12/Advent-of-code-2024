using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        var grid = new List<List<string>>();
        var ants = new Dictionary<string, List<int[]>>();

        for (int y = 0; y < input.Length; y++)
        {
            grid.Add(new List<string>());
            for (int x = 0; x < input[y].Length; x++)
            {
                var col = input[y][x].ToString();
                if (col != ".")
                {
                    if (!ants.ContainsKey(col))
                        ants[col] = new List<int[]>();

                    ants[col].Add(new[] { y, x });
                }
                grid[y].Add(col);
            }
        }

        void Part1()
        {
            var newGrid = grid.Select(row => new List<string>(row)).ToList();
            int count = 0;

            foreach (var locs in ants.Values)
            {
                foreach (var loc in locs)
                {
                    foreach (var other in locs)
                    {
                        if (loc[0] == other[0] && loc[1] == other[1])
                            continue;

                        var diff = new[] { loc[0] - other[0], loc[1] - other[1] };
                        var newLoc = new[] { loc[0] + diff[0], loc[1] + diff[1] };

                        if (newLoc[0] >= 0 && newLoc[0] < newGrid.Count && newLoc[1] >= 0 && newLoc[1] < newGrid[0].Count)
                        {
                            if (newGrid[newLoc[0]][newLoc[1]] != "#")
                            {
                                newGrid[newLoc[0]][newLoc[1]] = "#";
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Part1: " + count);
        }

        void Part2()
        {
            int count = 0;

            foreach (var locs in ants.Values)
            {
                foreach (var loc in locs)
                {
                    foreach (var other in locs)
                    {
                        if (loc[0] == other[0] && loc[1] == other[1])
                            continue;

                        var diff = new[] { loc[0] - other[0], loc[1] - other[1] };
                        var newLoc = new[] { loc[0] + diff[0], loc[1] + diff[1] };

                        while (newLoc[0] >= 0 && newLoc[0] < grid.Count && newLoc[1] >= 0 && newLoc[1] < grid[0].Count)
                        {
                            if (grid[newLoc[0]][newLoc[1]] != "#")
                            {
                                grid[newLoc[0]][newLoc[1]] = "#";
                            }
                            newLoc = new[] { newLoc[0] + diff[0], newLoc[1] + diff[1] };
                        }
                    }
                }
            }

            foreach (var row in grid)
            {
                foreach (var col in row)
                {
                    if (col != ".")
                        count++;
                }
            }

            Console.WriteLine("Part2: " + count);
        }

        Part1();
        Part2();
    }
}
