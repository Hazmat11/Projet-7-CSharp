

using System.Drawing;

namespace Projet_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        static void Game()
        {

            ConsoleKey key = ConsoleKey.Enter;
            while (key != ConsoleKey.Escape) {
                Console.WriteLine("Hello, World!");

                Point PlayerPosition = new Point(8, 36);
                //map[PlayerPosition.Y,PlayerPosition.X] = DefaultTile;
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                switch (input.Key)
                {
                    case ConsoleKey.Z or ConsoleKey.UpArrow:
                        //PlayerPosition = new Point(PlayerPosition.X, PlayerPosition.Y - 1);
                        Console.WriteLine("up");
                        break;
                    case ConsoleKey.Q or ConsoleKey.LeftArrow:
                        //PlayerPosition = new Point(PlayerPosition.X - 1, PlayerPosition.Y);
                        Console.WriteLine("left");
                        break;
                    case ConsoleKey.S or ConsoleKey.DownArrow:
                        //PlayerPosition = new Point(PlayerPosition.X, PlayerPosition.Y + 1);
                        Console.WriteLine("down");
                        break;
                    case ConsoleKey.D or ConsoleKey.RightArrow:
                        //PlayerPosition = new Point(PlayerPosition.X + 1, PlayerPosition.Y);
                        Console.WriteLine("right");
                        break;
                }
            }
        }

        static void DrawMap()
        {
            private static char[][] Map = new[] // map object, might store it in a text file
            {
            new [] { '^', '/', '\\', '/', '\\', '^', '^', '^', ' ', ' ', ' ', '^', ' ', '/', '\\', '/', '\\', ' ', '/', '\\', '^', '^', '/', '\\', '^', '/', '\\', '^', '^', '^', ' ', '^', ' ', ' ', ' ', '^', '/', '\\', '/', '\\', '^', '/', '\\', '/', '\\', ' ', '/', '\\', '^', '^', '/', '\\', ' ' },
            new [] { 'o', 'o', 'o', '~', 'o', '~', 'o', '~', 'o', 'o', '~', 'o', '~', '~', 'o', '~', 'o', 'o', '~' },
            new [] { '^', '^', '/', '\\', '^', '/', '\\', '^', '/', '\\', '^', '^', '/', '\\', ' ', '^', '/', '\\', '^', '^', '^', '^', ' ', '/', '\\', ' ', '/', '\\', '/', '\\', ' ', '/', '\\', ' ', ' ', '^', '^', ' ', ' ', '^', '/', '\\', '^', '/', '\\', ' ', '/', '\\', '^', '/', '\\', '^', ' ', '^', '^' },
            new [] { '^', '^', '/', '\\', '^', '/', '\\', '/', '\\', '/', '\\', '^', '/', '\\', '^', '/', '\\', '^', '/', '\\', '/', '\\', '^', ' ', '/', '\\', ' ', ' ', ' ', '^', ' ', '^', ' ', ' ', '^', '^', ' ', '/', '\\', '^', '/', '\\', '^', '^', '/', '\\', '^', '^', '^', '^', '^', '/', '\\', ' ' },
            new [] { 'o', 'o', '~', '~', '~', '~', '~', 'o', 'o', 'o', 'o', '~', 'o', 'o', '~', '~', 'o', '~', 'o' },
            new [] { ' ', '.', '.', '.', '.', '|', '.', '.', '.', '.', '|', '|', '|', '.', '.', '.', '.', '|', '.', '|', '.', '|', '.', '|', '.', '|', '.', '.', '|', '.', '.', '.', '.', '.', '|', '|', '.', '.', '|', '.', '.', '|', '|', '.', '|', '.', '|', '.' },
            new [] { '^', '/', '\\', '/', '\\', ' ', '^' }
            };
        }
    }
}