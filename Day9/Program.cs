// AdventOfCode2022-Day9

namespace Day9
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var tailVisits = new HashSet<(int x, int y)>();
            var rope = new List<(int x, int y)>();
            for (var i = 0; i < 10; i++)
            {
                rope.Add((0,0));
            }
            
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var direction = parts[0];
                var iterations = int.Parse(parts[1]);

                for (var i = 0; i < iterations; i++)
                {
                    // Move head.
                    switch (direction)
                    {
                        case "L":
                            rope[0] = (rope[0].x - 1, rope[0].y);
                            break;
                        case "U":
                            rope[0] = (rope[0].x, rope[0].y + 1);
                            break;
                        case "R":
                            rope[0] = (rope[0].x + 1, rope[0].y);
                            break;
                        case "D":
                            rope[0] = (rope[0].x, rope[0].y - 1);
                            break;
                    }
                    
                    // Move each knot according to the one in front of it.
                    for (var k = 1; k < rope.Count; k++)
                    {
                        var head = rope[k - 1];
                        var tail = rope[k];
                        var toHead = (x:head.x - tail.x, y:head.y - tail.y);
                        var d = (float)Math.Sqrt((float) (toHead.x * toHead.x + toHead.y * toHead.y));
                        if (d > 1.5f)
                        {
                            // Not touching.
                            if (head.x == tail.x)
                            {
                                rope[k] = (rope[k].x, rope[k].y + Math.Sign(toHead.y));
                            }
                            else if (head.y == tail.y)
                            {
                                rope[k] = (rope[k].x + Math.Sign(toHead.x), rope[k].y);
                            }
                            else
                            {
                                rope[k] = (rope[k].x + Math.Sign(toHead.x), rope[k].y + Math.Sign(toHead.y));
                            }
                        }
                    }
                    
                    tailVisits.Add(rope.Last());
                }
            }
            
            Console.WriteLine($"Tail visits:{tailVisits.Count}");
        }
    }
}
