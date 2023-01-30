using Projet_7.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.Managers
{
    public class AttacksInit
    {
        static Dictionary<string, Attacks> _dictionary;

        public static Dictionary<string, Attacks> Dictionary { get => _dictionary; }

        static AttacksInit()
        {
            _dictionary = new Dictionary<string, Attacks>()
            {
                { "Punch", new Attacks("Punch","Basic", 5, 0, "Both", 5) },
                { "Stad", new Attacks("Stab", "Basic", 5, 10, "Player", 6) },
                { "FlameThrower", new Attacks("FlameThrower", "Fire", 10, 20, "Both", 10) }
            };
        }
    }
}
