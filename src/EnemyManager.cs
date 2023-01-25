using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class EnemyManager
    {
        public Enemy CreateEnemy()
        {
            Random random = new Random();
            Random lvlRandom = new Random();
            int rnd = random.Next(0, 2);
            Enemy enemy = new Enemy(0, 0, 0, 0, 0, 0, 0);
            switch (rnd)
            {
                case 0:
                    int HazmatLVL = lvlRandom.Next(0, 100);
                    Enemy Hazmat = new Enemy(HazmatLVL, 100, 100, 15, 2, 5, 6);
                    Hazmat.Init();
                    enemy = Hazmat;
                    break;
                case 1:
                    int PandouileLVL = lvlRandom.Next(0, 100);
                    Enemy Pandouile = new Enemy(PandouileLVL, 100, 100, 25, 5, 8, 3);
                    Pandouile.Init();
                    enemy = Pandouile;
                    break;
                case 2:
                    int KyosukeLVL = lvlRandom.Next(0, 100);
                    Enemy Kyosuke = new Enemy(KyosukeLVL, 100, 100, 40, 3, 10, 1);
                    Kyosuke.Init();
                    enemy = Kyosuke;
                    break;
            }
            return enemy;
        }
    }
}
