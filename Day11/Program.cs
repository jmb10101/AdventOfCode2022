// AdventOfCode2022-Day11

using Day11.Day11;

namespace Day11
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            // Create monkeys.
            var monkeys = new List<Day11.Monkey>();
            for (var i = 0; i < lines.Length; i += 7)
            {
                var monkey = new Monkey();
                monkeys.Add(monkey);

                // Starting Items.
                var startingItemParts = lines[i + 1].Split(' ').Skip(4);
                foreach (var startingItemPart in startingItemParts)
                {
                    monkey.Items.Add(long.Parse(startingItemPart.Replace(",", string.Empty)));
                }

                // Operation.
                var parameters = lines[i + 2].Split(' ').Skip(6).ToArray();
                var symbol = parameters[0];
                var value = parameters[1];

                monkey.Operation = symbol == "*" ? Operation.Multiply : Operation.Add;

                if (value == "old")
                {
                    monkey.ValueIsOld = true;
                }
                else
                {
                    monkey.Value = long.Parse(value);
                }

                // Test.
                monkey.TestValue = long.Parse(lines[i + 3].Split(' ').Skip(5).First());
                monkey.TrueValue = int.Parse(lines[i + 4].Split(' ').Skip(9).First());
                monkey.FalseValue = int.Parse(lines[i + 5].Split(' ').Skip(9).First());
            }

            // Find the common divisor to avoid int overflow (the puzzle solution is dependent on int-constrained modulo operations).
            long commonDivisor = 1;
            foreach (var monkey in monkeys)
            {
                commonDivisor *= monkey.TestValue;
            }

            // Start Rounds.
            var rounds = 10000;
            for (var i = 0; i < rounds; i++)
            {
                for (var m = 0; m < monkeys.Count; m++)
                {
                    var monkey = monkeys[m];

                    // Inspect Item.
                    var items = monkey.Items.Count;
                    monkey.Inspections += (long)items;
                    for (var j = 0; j < items; j++)
                    {
                        var item = monkey.Items.First();
                        monkey.Items.RemoveAt(0);
                        var value = monkey.ValueIsOld ? item : monkey.Value;
                        if (monkey.Operation == Operation.Add)
                        {
                            item += value;
                        }
                        else
                        {
                            item *= value;
                        }

                        // Monkey gets bored with item.
                        //item /= 3;

                        item = (item % commonDivisor);
                        if (item % monkey.TestValue == 0)
                        {
                            monkeys[monkey.TrueValue].Items.Add(item);
                        }
                        else
                        {
                            monkeys[monkey.FalseValue].Items.Add(item);
                        }
                    }
                }
            }
            
            // Calculate monkey business.
            var busiestMonkeys = monkeys
                .OrderByDescending(x => x.Inspections)
                .Take(2)
                .Select(x => x.Inspections)
                .ToArray();
            Console.WriteLine($"Monkey Business:{busiestMonkeys[0] * busiestMonkeys[1]}");
        }
    }
}