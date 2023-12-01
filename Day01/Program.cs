string[] letterNumbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var lines = File.ReadAllLines("input.txt");
var result = lines.Sum(line => {
	var digits1 = ReplaceFirstLetterOccurence(line).Where(c => Char.IsDigit(c)).ToList();
	var digits2 = ReplaceLastLetterOccurence(line).Where(c => Char.IsDigit(c)).ToList();
	return Convert.ToInt32(digits1.First() + "" + digits2.Last());
});
Console.WriteLine(result);

string ReplaceFirstLetterOccurence(string row) {
	var part = "";
	foreach (var letter in row)
	{
		if (Char.IsDigit(letter))
			break;
		part += letter;
		for (var i = 0; i < letterNumbers.Length; i++)
		{
			var ln = letterNumbers[i];
			if (part.EndsWith(ln))
				return row.Replace(ln, (i + 1).ToString());
		}
	}
	return row;
}

string ReplaceLastLetterOccurence(string row) {
	var part = "";
	foreach (var letter in row.Reverse()) {
		if (Char.IsDigit(letter))
			break;
		part = letter + part;
		for (var i = 0; i < letterNumbers.Length; i++)
		{
			var ln = letterNumbers[i];
			if (part.StartsWith(ln))
				return row.Replace(ln, (i + 1).ToString());
		}
	}
	return row;
}

