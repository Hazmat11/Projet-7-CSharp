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
        public Fight(Player player, Enemy enemy)
        {
            MenuManager menu = new MenuManager();
            int Turn = 0;
            bool PlayerTurn;
            if (isPlayerFaster(player, enemy))
            {
                PlayerTurn = true;
            } else { PlayerTurn= false; }

            while (!isFightEnd(player, enemy))
            {
                Console.Write("Turn ");
                Console.WriteLine(Turn);
                if (PlayerTurn)
                {
                    if (doPlayerAttackHit(player, enemy))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You give Damage :");
                        Console.Write("-");
                        Console.Write(GiveDamageToEnemy(player, enemy));
                        Console.WriteLine(" HP");
                    }
                    else Console.WriteLine("Missed");

                    if(enemy._HP > 0)
                    {
                        if (doEnemyAttackHit(player, enemy))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You take Damage :");
                            Console.Write("-");
                            Console.Write(GiveDamageToPlayer(player, enemy));
                            Console.WriteLine(" HP");

                        }else Console.Write("You Evade");
                    }
                } 
                else
                {
                    if (doEnemyAttackHit(player, enemy))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You take Damage :");
                        Console.Write("-");
                        Console.Write(GiveDamageToPlayer(player, enemy));
                        Console.WriteLine(" HP");
                    }
                    else Console.Write("You Evade");

                    if (player._HP > 0)
                    {
                        if (doPlayerAttackHit(player, enemy))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You give Damage :");
                            Console.Write("-");
                            Console.Write(GiveDamageToEnemy(player, enemy));
                            Console.WriteLine(" HP");
                        } else Console.Write("Missed");
                    }
                }
                Turn++;

                Console.WriteLine("");
                Console.WriteLine("Debug :");
                Console.WriteLine("-------------------------------");
                Console.Write("Player Hp = ");
                Console.WriteLine(player._HP);
                Console.Write("Enemy LVL = ");
                Console.WriteLine(enemy._LVL);
                Console.Write("Enemy Hp = ");
                Console.WriteLine(enemy._HP);
                Console.WriteLine("------------------------------");
            }
        }

        ~Fight(){ }

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

        public int GiveDamageToPlayer(Player player, Enemy enemy)
        {
            int value = (enemy._ATT) - player._DEF;
            if (value < 0)
            {
                value = 0;
                player.TakeDamage(value);
            }
            else player.TakeDamage(value);
            return value;
        }

        public int GiveDamageToEnemy(Player player, Enemy enemy)
        {
            int value = (player._ATT) - enemy._DEF;
            if (value < 0)
            {
                value = 0;
                enemy.TakeDamage(value);
            }
            else enemy.TakeDamage(value);
            return value;
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
