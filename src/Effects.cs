using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    public class Effects
    {
        public string _NAME;
        public int _DMG;
        public int _HITCH;

        public Effects(string name, int damage, int hitch) 
        {
            _NAME = name;
            _DMG = damage;
            _HITCH = hitch;
        }

        public int GiveDamagetoEnemy(Enemy target)
        {
            target._HP -= _DMG;
            Console.Write("Enemy suffer of ");
            Console.WriteLine(_NAME);
            Console.Write("He Take ");
            Console.Write(_DMG);
            Console.WriteLine(" Damage");
            return _DMG;
        }

        public int GiveDamagetoPlayer(Player target)
        {
            target._HP -= _DMG;
            Console.Write("You suffer of ");
            Console.WriteLine(_NAME);
            Console.Write("You Take ");
            Console.Write(_DMG);
            Console.WriteLine(" Damage");
            return _DMG;
        }
    }
}
