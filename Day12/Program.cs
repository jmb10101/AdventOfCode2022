// AdventOfCode2022-Day12

namespace Day12
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var columns = lines[0].Length;
            var rows = lines.Length;
            var map = new int[columns, rows];
            var start = (0, 0);
            var end = (0, 0);

            // Create elevation map.
            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    var @char = lines[y][x];
                    if (@char == 'S')
                    {
                        start = (x, y);
                        @char = 'a';
                    }
                    else if (@char == 'E')
                    {
                        end = (x, y);
                        @char = 'z';
                    }

                    map[x, y] = (int)(@char - 'a') + 1;
                }
            }

            Console.WriteLine($"1:");
        }
    }
}