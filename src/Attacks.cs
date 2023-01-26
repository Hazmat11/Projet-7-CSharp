using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class Attacks
    {
        public char _TYPE { get; set; }
        public int _ATT { get; set; }
        public int _MPCOST { get; set; }
        public char _FOR { get; set; }

        public Attacks(char type, int att, int cost, char user)
        {
            _TYPE= type;
            _ATT= att;
            _MPCOST= cost;
            _FOR= user;
        }

        public int usePlayerAttack(Player user, Enemy target)
        {
            if ( _FOR != 'E')
            {
                user.UseMP(_MPCOST);
                Random rdm = new Random();
                int ardm = rdm.Next(-5, 5);
                int value = (user._ATT) - target._DEF + ardm;
                if (value < 0)
                {
                    value = 0;
                    target.TakeDamage(value);
                }
                else target.TakeDamage(value);
                return value;
            } else
            {
                Console.WriteLine("You can't une this Attack");
                return 0;
            }
        }

        public void useEnemyAttack(Enemy user)
        {

        }

    }
}
