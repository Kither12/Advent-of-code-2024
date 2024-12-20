class Program
{
    static int FindX_MAS(List<string> matrix, int x, int y)
    {
        int m = matrix.Count;
        int n = matrix[x].Length;
        int flag = 0;

        if (x + 2 < m && y + 2 < n && matrix[x + 1][y + 1] == 'A' &&
            ((matrix[x][y] == 'M' && matrix[x + 2][y + 2] == 'S') || (matrix[x][y] == 'S' && matrix[x + 2][y + 2] == 'M')))
        {
            flag = 1;
        }

        if (x + 2 < m && flag == 1 &&
            ((matrix[x][y + 2] == 'M' && matrix[x + 2][y] == 'S') || (matrix[x][y + 2] == 'S' && matrix[x + 2][y] == 'M')))
        {
            return 1;
        }

        return 0;
    }

    static int FindXMAS(List<string> matrix, int x, int y)
    {
        int m = matrix.Count;
        int n = matrix[x].Length;
        string refString = "XMAS";
        int count = 0;
        int ptrf = 0, ptrd = 0, ptrcr = 0, ptrcl = 0, inc = 0, end = 0;

        if (matrix[x][y] == 'X')
        {
            ptrf = ptrd = ptrcr = ptrcl = 0;
            end = 4;
            inc = 1;
        }
        else if (matrix[x][y] == 'S')
        {
            ptrf = ptrd = ptrcr = ptrcl = 3;
            end = -1;
            inc = -1;
        }

        for (int i = 0; i < 4; i++)
        {
            if (y + i < n && matrix[x][y + i] == refString[ptrf])
                ptrf += inc;

            if (x + i < m && matrix[x + i][y] == refString[ptrd])
                ptrd += inc;

            if (y + i < n && x + i < m && matrix[x + i][y + i] == refString[ptrcr])
                ptrcr += inc;

            if (y - i >= 0 && x + i < m && matrix[x + i][y - i] == refString[ptrcl])
                ptrcl += inc;
        }

        count = (ptrf == end ? 1 : 0) + (ptrd == end ? 1 : 0) + (ptrcr == end ? 1 : 0) + (ptrcl == end ? 1 : 0);
        return count;
    }

    static void Main()
    {
        var matrix = new List<string>();

        using (var inpFile = new StreamReader("input.txt"))
        {
            string line;
            while ((line = inpFile.ReadLine()) != null)
            {
                matrix.Add(line);
            }
        }

        int count1 = 0;
        int count2 = 0;

        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                // Part 1
                if (matrix[i][j] == 'X' || matrix[i][j] == 'S')
                    count1 += FindXMAS(matrix, i, j);

                // Part 2
                if (matrix[i][j] == 'M' || matrix[i][j] == 'S')
                    count2 += FindX_MAS(matrix, i, j);
            }
        }

        Console.WriteLine(count1);
        Console.WriteLine(count2);
    }
}
