var lines = File.ReadAllLines("input.txt");
int rowCount = lines.Length;
int colCount = lines[0].Length;
Content?[,] content = new Content?[rowCount, colCount];
int i = 0;
foreach (var line in lines)
{
    Content? lastNumber = null;
    int j = 0;
    foreach (var square in line)
    {
        bool isDigit = char.IsDigit(square);
        if (isDigit)
        {
            lastNumber ??= new Content() { Number = 0 };
            lastNumber.Number = Convert.ToInt32(lastNumber.Number + "" + square);
            content[i, j] = lastNumber;
        }
        else 
        {
            lastNumber = null;
            if (square != '.')
                content[i, j] = new Content() { Symbol = square };
        }

        j++;
    }
    i++;
}

int sum = 0;
for (int row = 0; row < rowCount; row++)
{
    for (int col = 0; col < colCount; col++)
    {
        if (content[row, col]?.IsGearSymbol != true)
            continue;
        HashSet<Content> gears = new HashSet<Content>();
        if ((row > 0 && col > 0 && content[row - 1, col - 1]?.Number.HasValue == true)) gears.Add(content[row - 1, col - 1]!);
        if ((row > 0 && content[row - 1, col]?.Number.HasValue == true)) gears.Add(content[row - 1, col]!);
        if ((row > 0 && col < colCount - 1 && content[row - 1, col + 1]?.Number.HasValue == true)) gears.Add(content[row - 1, col + 1]!);
        if ((col > 0 && content[row, col - 1]?.Number.HasValue == true)) gears.Add(content[row, col - 1]!);
        if ((col < colCount - 1 && content[row, col + 1]?.Number.HasValue == true)) gears.Add(content[row, col + 1]!);
        if ((row < rowCount - 1 && col > 0 && content[row + 1, col - 1]?.Number.HasValue == true)) gears.Add(content[row + 1, col - 1]!);
        if ((row < rowCount - 1 && content[row + 1, col]?.Number.HasValue == true)) gears.Add(content[row + 1, col]!);
        if ((row < rowCount - 1 && col < colCount - 1 && content[row + 1, col + 1]?.Number.HasValue == true)) gears.Add(content[row + 1, col + 1]!);

        var gearsList = gears.ToList();
        if (gears.Count == 2)
            sum += (gearsList[0].Number!.Value * gearsList[1].Number!.Value);
    }
}

Console.WriteLine(sum);

class Content
{
    public int? Number { get; set; }
    public bool IsSymbol => Symbol.HasValue;
    public char? Symbol { get; set; }
    public bool IsGearSymbol => IsSymbol && Symbol!.Value == '*';
}