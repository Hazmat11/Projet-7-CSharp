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
                Console.Clear();
                Console.WriteLine("You are Full Life");
            } else
            {
                if (player._HP + _HEALTH > player._HPMAX)
                {
                    player._HP = player._HPMAX;
                }
                else
                {
                    player._HP += _HEALTH;
                }
            }
        }

        public int RegenMana(Player player)
        {
            player._MP += _PM;
            return _PM;
        }

        public string Cure(Player player)
        {
            player._EFCT = EffectInit.Dictionary["None"];
            return EffectInit.Dictionary["None"]._NAME;
        }
    }
}
