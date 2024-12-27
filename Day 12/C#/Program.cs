using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static readonly (int dr, int dc)[] Directions = { (-1, 0), (0, 1), (1, 0), (0, -1) }; // up, right, down, left

    static void Main(string[] args)
    {
        string infile = args.Length >= 1 ? args[0] : "input.txt";
        string[] grid = File.ReadAllLines(infile);
        int rows = grid.Length;
        int cols = grid[0].Length;

        HashSet<(int, int)> seen = new();
        int p1 = 0, p2 = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (seen.Contains((r, c)))
                    continue;

                Queue<(int, int)> queue = new();
                queue.Enqueue((r, c));

                int area = 0, perimeter = 0;
                Dictionary<(int dr, int dc), HashSet<(int, int)>> perim = new();

                while (queue.Count > 0)
                {
                    var (r2, c2) = queue.Dequeue();
                    if (seen.Contains((r2, c2)))
                        continue;

                    seen.Add((r2, c2));
                    area++;

                    foreach (var (dr, dc) in Directions)
                    {
                        int rr = r2 + dr;
                        int cc = c2 + dc;

                        if (rr >= 0 && rr < rows && cc >= 0 && cc < cols && grid[rr][cc] == grid[r2][c2])
                        {
                            queue.Enqueue((rr, cc));
                        }
                        else
                        {
                            perimeter++;
                            if (!perim.ContainsKey((dr, dc)))
                                perim[(dr, dc)] = new HashSet<(int, int)>();

                            perim[(dr, dc)].Add((r2, c2));
                        }
                    }
                }

                int sides = 0;
                foreach (var (direction, positions) in perim)
                {
                    HashSet<(int, int)> seenPerim = new();
                    foreach (var (pr, pc) in positions)
                    {
                        if (seenPerim.Contains((pr, pc)))
                            continue;

                        sides++;
                        Queue<(int, int)> perimQueue = new();
                        perimQueue.Enqueue((pr, pc));

                        while (perimQueue.Count > 0)
                        {
                            var (r2, c2) = perimQueue.Dequeue();
                            if (seenPerim.Contains((r2, c2)))
                                continue;

                            seenPerim.Add((r2, c2));
                            foreach (var (dr, dc) in Directions)
                            {
                                int rr = r2 + dr;
                                int cc = c2 + dc;
                                if (positions.Contains((rr, cc)))
                                    perimQueue.Enqueue((rr, cc));
                            }
                        }
                    }
                }

                p1 += area * perimeter;
                p2 += area * sides;
            }
        }

        Console.WriteLine(p1);
        Console.WriteLine(p2);
    }
}
