using System.Numerics;

namespace Day11
{
    namespace Day11
    {
        public enum Operation
        {
            Add,
            Multiply,
        }

        public class Monkey
        {
            public List<long> Items { get; set; } = new List<long>();
            public Operation Operation { get; set; }
            public long Value { get; set; }
            public bool ValueIsOld { get; set; } = false;
            public long TestValue { get; set; }
            public int TrueValue { get; set; }
            public int FalseValue { get; set; }
            public long Inspections { get; set; } = 0;
        }
    }
}
