using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    public class Player
    {
        public int LVL { get; set; }
        public int HP {get; set;}
        public int MP { get; set;}
        public int ATT { get; set;}
        public int ACC { get; set;}
        public int SPEED { get; set;}
        public int DEF { get; set;}

        public Player(int lvlBase, int hpBase, int mpBase, int attBase, int accBase, int speedBase, int defBase)
        {
            LVL = lvlBase;
            HP = hpBase;
            MP = mpBase;
            ATT = attBase;
            ACC = accBase;          
            SPEED = speedBase;
            DEF = defBase;
        }
    }
}
