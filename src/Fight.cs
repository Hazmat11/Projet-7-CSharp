using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class Fight
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
                    Enemy Hazmat = new Enemy(HazmatLVL, 150, 5, 10, 50, 5, 8);
                    Hazmat.Init();
                    enemy = Hazmat;
                    break;
                case 1:
                    int PandouileLVL = lvlRandom.Next(0, 100);
                    Enemy Pandouile = new Enemy(PandouileLVL, 100, 8, 14, 80, 10, 5);
                    Pandouile.Init();
                    enemy = Pandouile;
                    break;
                case 2:
                    int KyosukeLVL = lvlRandom.Next(0, 100);
                    Enemy Kyosuke = new Enemy(KyosukeLVL, 80, 15, 20, 60, 40, 2);
                    Kyosuke.Init();
                    enemy = Kyosuke;
                    break;
            }
            return enemy;
        }

        public bool isPlayerFaster(Player player, Enemy enemy){
            if (player._SPEED >= enemy._SPEED)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool isFightEnd(Player player, Enemy enemy)
        {
            if (player._HP <= 0 || enemy._HP <= 0)
            {
                return true;
            } else 
            {
                return false;
            }
        }

        public void GiveDamageToPlayer(Player player, Enemy enemy)
        {
            int value = (enemy._ATT) - player._DEF;
            if (value < 0)
            {
                value = 0;
                player.TakeDamage(value);
            }
            else player.TakeDamage(value);
        }

        public void GiveDamageToEnemy(Player player, Enemy enemy)
        {
            int value = (player._ATT) - enemy._DEF;
            if (value < 0)
            {
                value = 0;
                enemy.TakeDamage(value);
            }
            else enemy.TakeDamage(value);
        }

        public bool doPlayerAttackHit(Player player, Enemy enemy)
        {
            Random random = new Random();
            if (player._ACC < enemy._SPEED)
            {
                int HitChance = random.Next(0, 100);
                if (HitChance > 40)
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }

        public bool doEnemyAttackHit(Player player, Enemy enemy)
        {
            Random random = new Random();
            if (enemy._ACC < player._SPEED)
            {
                int HitChance = random.Next(0, 100);
                if (HitChance > 30)
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }
    }
}
