using Projet_7.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    public class Item
    {
        public string _NAME { get; set; }
        public int _QUANTITY { get; set; }
        public int _HEALTH { get; set; }
        public bool _CURE { get; set; }
        public int _PM { get; set; }

        public Item(string name, int quantity, int health, bool cure, int pm)
        {
            _NAME = name;
            _QUANTITY = quantity;
            _HEALTH = health;
            _CURE = cure;
            _PM = pm;
        }

        public void Healing(Player player)
        {
            if (player._HP == player._HPMAX)
            {
                Console.WriteLine("You are Full Life");
            } else
            {
                if (_QUANTITY > 0)
                {
                    if (player._HP + _HEALTH > player._HPMAX)
                    {
                        Console.Write("You Get Heal +");
                        Console.WriteLine(player._HPMAX - player._HP);
                        player._HP = player._HPMAX;
                        _QUANTITY--;
                    }
                    else
                    {
                        player._HP += _HEALTH;
                        _QUANTITY--;
                        Console.Write("You Get Heal +");
                        Console.WriteLine(_HEALTH);
                    }
                }
                else
                {
                    Console.Write("You Don't Have ");
                    Console.WriteLine(_NAME);
                }

            }
        }

        public int RegenMana(Player player)
        {
            if (player._HP == player._HPMAX)
            {
                Console.WriteLine("You are Full of Stamina");
            }
            else
            {
                if (_QUANTITY > 0)
                {
                    player._MP += _PM;
                    _QUANTITY--;
                    Console.Write("You Get Stamina +");
                    Console.WriteLine(_PM);
                }
                else
                {
                    Console.Write("You Don't Have ");
                    Console.WriteLine(_NAME);
                }
            }

            return _PM;
        }

        public void Cure(Player player)
        {
            if (player._EFCT == EffectInit.Dictionary["None"])
            {
                Console.WriteLine("You are Good");
            }
            else
            {
                if (_QUANTITY > 0)
                {
                    player._EFCT = EffectInit.Dictionary["None"];
                    _QUANTITY--;
                    Console.Write("You Get Healed");
                    Console.WriteLine(_PM);
                }
                else
                {
                    Console.Write("You Don't Have ");
                    Console.WriteLine(_NAME);
                }
            }
        }
    }
}
