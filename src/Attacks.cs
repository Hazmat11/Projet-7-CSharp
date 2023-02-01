using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;

namespace Projet_7.src
{
    public class Attacks
    {
        public string _NAME { get; set; }
        public string _TYPE { get; set; }
        public int _ATT { get; set; }
        public int _MPCOST { get; set; }
        public string _FOR { get; set; }
        protected int _ACC { get; set; }


        public Attacks(string name, string type, int att, int cost, string user, int acc)
        {
            _NAME = name;
            _TYPE = type;
            _ATT = att;
            _MPCOST = cost;
            _FOR = user;
            _ACC = acc;
        }


        public int usePlayerAttack(Player user, Enemy target)
        {
            Random rdm = new Random();
            int ardm = rdm.Next(-_ACC, _ACC);
            int value = 0;
            if ( _FOR != "Enemy")
            {
                int mult = 2;
                if (_TYPE == "Plant" && target._TYPE == "Fire" || _TYPE == "Fire" && target._TYPE == "Water" || _TYPE == "Water" && target._TYPE == "Plant")
                {
                    value = ((user._ATT) - target._DEF + ardm) * mult;
                }
                else if (_TYPE == "Plant" && target._TYPE == "Water" || _TYPE == "Fire" && target._TYPE == "Plant" || _TYPE == "Water" && target._TYPE == "Fire")
                {
                    value = ((user._ATT) - target._DEF + ardm) / mult;
                }
                if (user._MP < _MPCOST)
                {
                    Console.WriteLine("You don't have enought Stamina");
                }
                else
                {
                    user.UseMP(_MPCOST);
                    if (value < 0)
                    {
                        value = 0;
                        target.TakeDamage(value);
                    } else target.TakeDamage(value);
                return value;
                }                                     
            } else
            {
                Console.WriteLine("You can't une this Attack");
            }
            return 0;
        }

        public int useEnemyAttack(Enemy user, Player target)
        {
            Random rdm = new Random();
            int ardm = rdm.Next(-_ACC, _ACC);
            int value = 0;
            if (_FOR != "Player")
            {
                int mult = 2;
                if (_TYPE == "Plant" && target._TYPE == "Fire" || _TYPE == "Fire" && target._TYPE == "Water" || _TYPE == "Water" && target._TYPE == "Plant")
                {
                    value = ((user._ATT) - target._DEF + ardm) * mult;
                }
                else if (_TYPE == "Plant" && target._TYPE == "Water" || _TYPE == "Fire" && target._TYPE == "Plant" || _TYPE == "Water" && target._TYPE == "Fire")
                {
                    value = ((user._ATT) - target._DEF + ardm) / mult;
                }
                if (user._MP < _MPCOST)
                {
                    Console.WriteLine("Enemy try to Attack but he is out of Stamina");
                }
                else
                {
                    user.UseMP(_MPCOST);
                    if (value < 0)
                    {
                        value = 0;
                        target.TakeDamage(value);
                    }
                    else target.TakeDamage(value);
                return value;
                }
            }
            else
            {
                Console.WriteLine("The Enemy try to use something that he don't know");
            }
            return 0;
        }

    }
}
