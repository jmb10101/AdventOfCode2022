// AdventOfCode2022-Day4

namespace Day4
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var matches = 0;
            foreach (var line in lines)
            {
                var assignments = line.Split(',');
                var a1 = assignments[0].Split('-');
                var a2 = assignments[1].Split('-');
                var a1Min = int.Parse(a1[0]);
                var a1Max = int.Parse(a1[1]);
                var a2Min = int.Parse(a2[0]);
                var a2Max = int.Parse(a2[1]);
                
                // 1
                // if ((a1Min <= a2Min && a1Max >= a2Max) || (a2Min <= a1Min && a2Max >= a1Max))
                // 2
                if (!(a1Min > a2Max || a2Min > a1Max))
                {
                    matches++;
                }
            }

            Console.WriteLine($"Answer:{matches}");
        }
    }
}