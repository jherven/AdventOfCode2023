var inventory = new Dictionary<CubeType, int>()
{
    { CubeType.Red, 12 },
    { CubeType.Green, 13 },
    { CubeType.Blue, 14 },
};

var lines = File.ReadAllLines("input.txt");
int powerSum = 0;
foreach (var line in lines)
{
    var parsedLine = ParseLine(line);
    powerSum += parsedLine.red * parsedLine.green * parsedLine.blue;
}

Console.WriteLine(powerSum);

(int red, int green, int blue) ParseLine(string line)
{
    line = line.Split(':')[1];
    var lineParts = line.Split(';').SelectMany(l => l.Trim().Split(',').Select(t => t.Trim())).ToList();
    return (
        lineParts.Where(c => c.EndsWith(CubeType.Red.ToString().ToLower())).Select(s => Convert.ToInt32(s.Split(' ')[0])).DefaultIfEmpty(0).Max(),
        lineParts.Where(c => c.EndsWith(CubeType.Green.ToString().ToLower())).Select(s => Convert.ToInt32(s.Split(' ')[0])).DefaultIfEmpty(0).Max(),
        lineParts.Where(c => c.EndsWith(CubeType.Blue.ToString().ToLower())).Select(s => Convert.ToInt32(s.Split(' ')[0])).DefaultIfEmpty(0).Max()
    );
}

enum CubeType
{
    Red,
    Green,
    Blue,
}
