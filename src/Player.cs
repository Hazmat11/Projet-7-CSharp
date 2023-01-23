using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    public class PlayerMove
    {
        static void Move() { 
            ConsoleKey key = ConsoleKey.Enter;
            while (key != ConsoleKey.Escape) {
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
    }
}
