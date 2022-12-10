// AdventOfCode2022-Day5

namespace Day5
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var stacks = new List<List<char>>();
            var initializingStacks = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    initializingStacks = false;
                    continue;
                }

                if (initializingStacks)
                {
                    for (var i = 0; i < line.Length; i++)
                    {
                        if (!char.IsUpper(line[i]))
                            continue;
                        
                        var stack = (i - 1) / 4;
                        var stacksToAdd = stack + 1 - stacks.Count;
                        for (var s = 0; s < stacksToAdd; s++)
                        {
                            stacks.Add(new List<char>());
                        }
                            
                        stacks[stack].Add(line[i]);
                    }
                }
                else
                {
                    var parts = line.Split(' ');
                    var iterations = int.Parse(parts[1]);
                    var from = int.Parse(parts[3]) - 1;
                    var to = int.Parse(parts[5]) - 1;

                    var moved = new List<char>();
                    for (var i = 0; i < iterations; i++)
                    {
                        if (stacks[from].Any())
                        {
                            //stacks[to].Insert(0, stacks[from][0]);
                            //stacks[from].RemoveAt(0);
                            moved.Add(stacks[from][0]);
                            stacks[from].RemoveAt(0);
                        }
                    }

                    for (var i = moved.Count - 1; i >= 0; i--)
                    {
                        stacks[to].Insert(0, moved[i]);
                    }
                }
            }

            
            Console.WriteLine($"1:{new string(stacks.Select(x => x.First()).ToArray())}");
        }
    }
}