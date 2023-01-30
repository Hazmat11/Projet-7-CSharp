using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Projet_7.Managers;
using System.Xml.Linq;
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

        public int keyValue = 0;

        public bool ingame = true;

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
            _SPEED = _SPEED + (_SPEED * _LVL / 2) / 100;
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

        public void detectKey(Player player)
        {  
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Z or ConsoleKey.UpArrow:
                    keyValue = 1;
                    break;
                case ConsoleKey.Q or ConsoleKey.LeftArrow:
                    keyValue = 2;
                    break;
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    keyValue = 3;
                    break;
                case ConsoleKey.D or ConsoleKey.RightArrow:
                    keyValue = 4;
                    break;
                case ConsoleKey.Escape:
                    ingame = false;
                    MenuManager menu = new MenuManager();
                    Console.Clear();
                    menu.PauseMenu(player);
                    break;
                default:
                    break;
            }
        }
    }
}