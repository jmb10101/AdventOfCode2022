// AdventOfCode2022-Day2

namespace Day2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var score = 0;
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                score += Evaluate2(parts[0][0], parts[1][0]);
            }
            
            Console.WriteLine($"Score:{score}");
        }

        private static int Evaluate1(char opponentChoice, char playerChoice)
        {
            switch (opponentChoice)
            {
                case 'A':   // Rock
                    switch (playerChoice)
                    {
                        case 'X':   // Rock
                            return 3 + 1;
                        case 'Y':   // Paper
                            return 6 + 2;
                        case 'Z':   // Scissors
                            return 0 + 3;
                    }
                    break;
                case 'B':   // Paper
                    switch (playerChoice)
                    {
                        case 'X':   // Rock
                            return 0 + 1;
                        case 'Y':   // Paper
                            return 3 + 2;
                        case 'Z':   // Scissors
                            return 6 + 3;
                    }
                    break;
                case 'C':   // Scissors
                    switch (playerChoice)
                    {
                        case 'X':   // Rock
                            return 6 + 1;
                        case 'Y':   // Paper
                            return 0 + 2;
                        case 'Z':   // Scissors
                            return 3 + 3;
                    }
                    break;                
            }

            return 0;
        }
        
        private static int Evaluate2(char opponentChoice, char playerChoice)
        {
            // X = lose
            // Y = draw
            // Z = win
            switch (opponentChoice)
            {
                case 'A':   // Rock
                    switch (playerChoice)
                    {
                        case 'X':   // Scissors
                            return 0 + 3;
                        case 'Y':   // Rock
                            return 3 + 1;
                        case 'Z':   // Paper
                            return 6 + 2;
                    }
                    break;
                case 'B':   // Paper
                    switch (playerChoice)
                    {
                        case 'X':   // Rock
                            return 0 + 1;
                        case 'Y':   // Paper
                            return 3 + 2;
                        case 'Z':   // Scissors
                            return 6 + 3;
                    }
                    break;
                case 'C':   // Scissors
                    switch (playerChoice)
                    {
                        case 'X':   // Paper
                            return 0 + 2;
                        case 'Y':   // Scissors
                            return 3 + 3;
                        case 'Z':   // Rock
                            return 6 + 1;
                    }
                    break;                
            }

            return 0;
        }
    }
}
