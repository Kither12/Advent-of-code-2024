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

        // Calculate the answer
        int ans = 0;
        for (int i = 0; i < asSorted.Count; i++)
        {
            int tmp = Math.Abs(asSorted[i] - bsSorted[i]);
            ans += tmp;
        }

        // Output the result
        Console.WriteLine(ans);
    }
}
