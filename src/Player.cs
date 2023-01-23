using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    public class Player
    {
        public int LVL { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int ATT { get; set; }
        public int ACC { get; set; }
        public int SPEED { get; set; }
        public int DEF { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int lvlBase, int hpBase, int mpBase, int attBase, int accBase, int speedBase, int defBase)
        {
            LVL = lvlBase;
            HP = hpBase;
            MP = mpBase;
            ATT = attBase;
            ACC = accBase;
            SPEED = speedBase;
            DEF = defBase;
            X = 0;
            Y = 0;
        }
        public void Move()
        {
            ConsoleKey key = ConsoleKey.Enter;
            while (key != ConsoleKey.Escape)
            {
                //map[PlayerPosition.Y,PlayerPosition.X] = DefaultTile;
                ConsoleKeyInfo input = Console.ReadKey();
                //Console.Clear();
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
