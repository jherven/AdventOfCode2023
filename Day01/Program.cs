var lines = File.ReadAllLines("input.txt");
var result = lines.Sum(line => {
	var digits = line.Where(c => Char.IsDigit(c)).ToList();
	return Convert.ToInt32(digits.First() + "" + digits.Last());
});
Console.WriteLine(result);

