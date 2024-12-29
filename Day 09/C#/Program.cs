public class BlockGroup
{
    public int? FileId { get; set; }
    public int Size { get; set; }
    public bool IsFreeSpace { get; set; }

    public BlockGroup(int? fileId, int size, bool isFreeSpace)
    {
        FileId = fileId;
        Size = size;
        IsFreeSpace = isFreeSpace;
    }
}

public class Block
{
    public int? FileId { get; set; }
    public bool IsFreeSpace { get; set; }

    public Block(int? fileId, bool isFreeSpace)
    {
        FileId = fileId;
        IsFreeSpace = isFreeSpace;
    }

    public override string ToString()
    {
        return IsFreeSpace ? "." : FileId.ToString();
    }
}

class Program
{
    static List<Block> GetBlocks(List<BlockGroup> diskMap)
    {
        var blocks = new List<Block>();
        foreach (var blockGroup in diskMap)
        {
            for (int i = 0; i < blockGroup.Size; i++)
            {
                blocks.Add(new Block(blockGroup.FileId, blockGroup.IsFreeSpace));
            }
        }
        return blocks;
    }

    static long GetChecksum(List<Block> blocks)
    {
        long checksum = 0;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].FileId.HasValue)
            {
                checksum += blocks[i].FileId.Value * i;
            }
        }
        return checksum;
    }

    static List<BlockGroup> GetDiskMap()
    {
        var diskMap = new List<BlockGroup>();
        var input = File.ReadAllText("input.txt").Trim();

        for (int i = 0; i < input.Length; i += 2)
        {
            diskMap.Add(new BlockGroup(i / 2, input[i] - '0', false));

            if (i + 1 < input.Length)
            {
                diskMap.Add(new BlockGroup(null, input[i + 1] - '0', true));
            }
        }
        return diskMap;
    }

    static void Main()
    {
        // Part 1
        var blocks = GetBlocks(GetDiskMap());
        int previousFreeBlockId = 0;

        for (int i = blocks.Count - 1; i >= 0; i--)
        {
            if (!blocks[i].IsFreeSpace)
            {
                for (int j = previousFreeBlockId; j < i; j++)
                {
                    if (blocks[j].IsFreeSpace)
                    {
                        var temp = blocks[i];
                        blocks[i] = blocks[j];
                        blocks[j] = temp;
                        previousFreeBlockId = j;
                        break;
                    }
                }
            }
        }

        long checksum = GetChecksum(blocks);
        Console.WriteLine($"Part 1 Checksum: {checksum}");

        // Part 2
        var startTime = DateTime.Now;
        var blockGroups = GetDiskMap();

        for (int i = blockGroups.Count - 1; i >= 0; i--)
        {
            if (blockGroups[i].FileId.HasValue)
            {
                for (int j = 0; j < i; j++)
                {
                    if (blockGroups[j].IsFreeSpace && blockGroups[j].Size >= blockGroups[i].Size)
                    {
                        var newFreeBlockGroups = new List<BlockGroup>
                        {
                            new BlockGroup(null, blockGroups[i].Size, true),
                            new BlockGroup(null, blockGroups[j].Size - blockGroups[i].Size, true)
                        };

                        if (newFreeBlockGroups[1].Size > 0)
                        {
                            blockGroups[j] = newFreeBlockGroups[0];
                            blockGroups.Insert(j + 1, newFreeBlockGroups[1]);
                            i++;
                        }

                        var temp = blockGroups[j];
                        blockGroups[j] = blockGroups[i];
                        blockGroups[i] = temp;
                        break;
                    }
                }
            }
        }

        blocks = GetBlocks(blockGroups);
        checksum = GetChecksum(blocks);

        var endTime = DateTime.Now;
        Console.WriteLine($"Part 2 Checksum: {checksum}");
        Console.WriteLine($"Part 2 executed in: {(endTime - startTime).TotalSeconds} seconds.");
    }
}
