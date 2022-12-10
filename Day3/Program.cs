// AdventOfCode2022-Day3

using System.Runtime.CompilerServices;

namespace Day3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var elves = File.ReadAllLines("input.txt");
            var matches = new List<char>();
            for (var elf = 0; elf < elves.Length; elf += 3)
            {
                var elf1 = elves[elf];
                var elf2 = elves[elf + 1];
                var elf3 = elves[elf + 2];
                
                for (var i = 0; i < elf1.Length; i++)
                {
                    for (var j = 0; j < elf2.Length; j++)
                    {
                        for (var k = 0; k < elf3.Length; k++)
                        {
                            if (elf1[i] == elf2[j] && elf1[i] == elf3[k])
                            {
                                matches.Add(elf1[i]);
                                goto search_end;
                            }
                        }
                    }
                }
                search_end:;
            }

            Console.WriteLine($"Sum:{matches.Select(GetPriority).Sum()}");
        }

        private static int GetPriority(char c)
        {
            if (char.IsLower(c))
            {
                return c - 'a' + 1;
            }

            return c - 'A' + 1 + 26;
        }
    }
}
