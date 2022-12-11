// AdventOfCode2022-Day10

namespace Day10
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var x = 1;
            var cycle = 1;
            var signals = new List<int>();
            var pixels = string.Empty;
            signals.Add(0);
            foreach (var line in lines)
            {
                RenderPixel(signals, ref pixels, x, cycle);
                cycle++;

                var parts = line.Split(' ');
                if (parts.Length < 2)
                {
                    // noop
                    continue;
                }

                RenderPixel(signals, ref pixels, x, cycle);
                cycle++;

                x += int.Parse(parts[1]);
            }

            //Console.WriteLine($"1:{signals[20] + signals[60] + signals[100] + signals[140] + signals[180] + signals[220]}");
            Console.WriteLine(pixels[..40]);
            Console.WriteLine(pixels[40..80]);
            Console.WriteLine(pixels[80..120]);
            Console.WriteLine(pixels[120..160]);
            Console.WriteLine(pixels[160..200]);
            Console.WriteLine(pixels[200..240]);
        }

        private static void RenderPixel(IList<int> signals, ref string pixels, int x, int cycle)
        {
            signals.Add(x * cycle);
            var xPixel = (cycle - 1) % 40 + 1;
            if (Math.Abs(xPixel - (x + 1)) <= 1)
            {
                pixels += '#';
            }
            else
            {
                pixels += '.';
            }
        }
    }
}
