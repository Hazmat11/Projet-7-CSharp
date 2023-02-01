using Projet_7.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.Managers
{
    internal class EffectInit
    {
        static Dictionary<string, Effects> _dictionary;

        public static Dictionary<string, Effects> Dictionary { get => _dictionary; }

        static EffectInit()
        {
            _dictionary = new Dictionary<string, Effects>()
            {
                { "None", new Effects("None",0,0) },
                { "Burn", new Effects("Burn",10,100) },
            };
        }
    }
}
