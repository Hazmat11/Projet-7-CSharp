using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;

namespace Projet_7.src
{
    public class Player
    {
        MapInit mi = new MapInit();
        public int _LVL { get; set; }
        public int _HP { get; set; }
        public int _MP { get; set; }
        public int _ATT { get; set; }
        public int _ACC { get; set; }
        public int _SPEED { get; set; }
        public int _DEF { get; set; }
        public int _X { get; set; }
        public int _Y { get; set; }

        public Player(int lvlBase, int hpBase, int mpBase, int attBase, int accBase, int speedBase, int defBase)
        {
            _LVL = lvlBase;
            _HP = hpBase;
            _MP = mpBase;
            _ATT = attBase;
            _ACC = accBase;
            _SPEED = speedBase;
            _DEF = defBase;
            _X = 0;
            _Y = 0;
        }

        public void LVLUp()
        {
            _LVL++;
            _ATT = _ATT + (_ATT * _LVL) / 100;
            _ACC = _ACC + (_ACC * _LVL) / 100;
            _SPEED = _SPEED + (_SPEED * _LVL/2) / 100;
            _DEF = _DEF + (_DEF * _LVL) / 100;
            _HP = _HP + (_HP * _LVL) / 100;
        }

        public void TakeDamage(int value)
        {
            _HP = _HP - value;
        }

        public void Heal(int value)
        {
            _HP = _HP + value;
        }

        public void UseMP(int value)
        {
            _MP = _MP - value;
        }

        public void RegenMP(int value)
        {
            _MP++;
        }

        public void Move()
        {       
            for (int y = 0; y < mi.tab.GetLength(0); y++)
            {
                for (int x = 0; x < mi.tab.GetLength(1); x++)
                {
                    Console.Write(mi.tab[y, x]);
                    if (mi.tab[y, x] == '&')
                    {
                        Console.Write(mi.tab[y, x]);
                        _X = x;
                        _Y = y;
                    }
                }
                Console.WriteLine();
            }
            detectKey();
        }

        public void detectKey()
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
                        /*                        mi.tab[Y,X] = '~';
                                                mi.tab[Y, X += 1] = '&';*/
                        Console.WriteLine("right");
                        mi.WriteTab();
                        break;
                }
            }
        }
    }
}
