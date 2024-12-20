class Program
{
    static void Main()
    {
        // Initialize lists for storing input values
        List<int> a = new List<int>();
        List<int> b = new List<int>();

        // Read file and populate lists
        foreach (var line in File.ReadLines("input.txt"))
        {
            var parts = line.Split("   ");
            if (parts.Length == 2 && int.TryParse(parts[0], out int first) && int.TryParse(parts[1], out int second))
            {
                a.Add(first);
                b.Add(second);
            }
        }

        // Sort the lists
        var asSorted = a.OrderBy(x => x).ToList();
        var bsSorted = b.OrderBy(x => x).ToList();

        // Calculate the Part 1 answer
        int ans1 = 0;
        for (int i = 0; i < asSorted.Count; i++)
        {
            int tmp = Math.Abs(asSorted[i] - bsSorted[i]);
            ans1 += tmp;
        }

        // Calculate the Part 2 answer
        int ans2 = 0;
        foreach (var numA in a)
        {
            int countB = b.Count(x => x == numA);
            ans2 += numA * countB;
        }


        // Output the result
        Console.WriteLine(ans1);
        Console.WriteLine(ans2);
    }
}
