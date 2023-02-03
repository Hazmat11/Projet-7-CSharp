using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;

namespace Projet_7.Managers
{
    internal class EnemyManager
    {
        public Enemy CreateEnemy()
        {
            Random random = new Random();
            Random lvlRandom = new Random();
            int rnd = random.Next(0, 3);
            int lrnd = random.Next(-5, 5);
            Console.ReadKey(true);
            Enemy enemy = new Enemy("",0, 0, 0, 0, 0, 0, 0, "") ;
            if (PlayerInit.PlayerList["player1"]._LVL + lrnd <=0 ) lrnd = 0;
            switch (rnd)
            {
                case 0:
                    int HazmatLVL = lvlRandom.Next(1, PlayerInit.PlayerList["player1"]._LVL + lrnd);
                    Enemy Hazmat = new Enemy("Renardo4000", HazmatLVL, 100, 100, 15, 2, 5, 6, "Water");
                    Hazmat.Init();
                    enemy = Hazmat;
                    break;
                case 1:
                    int PandouilleLVL = lvlRandom.Next(1, PlayerInit.PlayerList["player1"]._LVL + lrnd);
                    Enemy Pandouille = new Enemy("Zearcus", PandouilleLVL, 100, 100, 25, 5, 8, 3, "Plant");
                    Pandouille.Init();
                    enemy = Pandouille;
                    break;
                case 2:
                    int KyosukeLVL = lvlRandom.Next(1, PlayerInit.PlayerList["player1"]._LVL + lrnd);
                    Enemy Kyosuke = new Enemy("Kyosuke", KyosukeLVL, 100, 100, 40, 3, 10, 1, "Fire");
                    Kyosuke.Init();
                    enemy = Kyosuke;
                    break;
            }
            return enemy;
        }
    }
}
