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
                content[i, j] = new Content();
        }

        j++;
    }
    i++;
}

var valid = new HashSet<Content>();
for (int row = 0; row < rowCount; row++)
{
    for (int col = 0; col < colCount; col++)
    {
        if (content[row, col]?.Number.HasValue != true)
            continue;
        if (
            (row > 0 && col > 0 && content[row - 1, col - 1]?.IsSymbol == true) ||
            (row > 0 && content[row - 1, col]?.IsSymbol == true) ||
            (row > 0 && col < colCount - 1 && content[row - 1, col + 1]?.IsSymbol == true) ||
            (col > 0 && content[row, col - 1]?.IsSymbol == true) ||
            (col < colCount - 1 && content[row, col + 1]?.IsSymbol == true) ||
            (row < rowCount - 1 && col > 0 && content[row + 1, col - 1]?.IsSymbol == true) ||
            (row < rowCount - 1 && content[row + 1, col]?.IsSymbol == true) ||
            (row < rowCount - 1 && col < colCount - 1 && content[row + 1, col + 1]?.IsSymbol == true)
        )
            valid.Add(content[row, col]!);
    }
}

Console.WriteLine(valid.Sum(s => s.Number!.Value));

class Content
{
    public int? Number { get; set; }
    public bool IsSymbol => !Number.HasValue;
}