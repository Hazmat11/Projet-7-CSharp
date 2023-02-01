using Projet_7.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.Managers
{
    internal class ObjectInit
    {
        static Dictionary<string, Item> _dictionary;
        public static Dictionary<string, Item> Dictionary { get => _dictionary; }

        static ObjectInit()
        {
            _dictionary = new Dictionary<string, Item>()
            {
                { "HealP", new Item("Bandage", 1,100,false,0) },
                { "MPP", new Item("Monster",0,0,false,100) },
                { "CureP", new Item("Pfizer",0,-5,true,0) },
            };
        }
    }
}
