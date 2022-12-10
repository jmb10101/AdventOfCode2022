// AdventOfCode2022-Day6

namespace Day6
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var data = File.ReadAllText("input.txt");
            var marker = 0;
            var buffer = new HashSet<char>();
            var c = 14;
            for (var i = c - 1; i < data.Length; i++)
            {
                // Test for differences.
                buffer.Clear();
                for (var s = i - (c - 1); s <= i; s++)
                {
                    buffer.Add(data[s]);
                }

                if (buffer.Count == c)
                {
                    marker = i + 1;
                    break;
                }
            }
            
            Console.WriteLine($"1:{marker}");
        }
    }
}