// AdventOfCode2022-Day1

var lines = File.ReadAllLines("input.txt");

var elfCalories = new List<int>();
elfCalories.Add(0);
foreach (var line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        elfCalories.Add(0);
    }
    else
    {
        elfCalories[^1] += int.Parse(line);
    }
}

var top3Sum = elfCalories.OrderByDescending(x => x).Take(3).Sum();
Console.WriteLine($"Max calories:{elfCalories.Max()} Top 3 sum:{top3Sum}");