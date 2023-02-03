using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Projet_7.Managers;
using Windows.UI.Xaml.Controls;

namespace Projet_7.src
{
    internal class Fight
    {
        public Fight(Player fplayer, Enemy enemy)
        {
            Player player = fplayer;

            AudioManager music = new AudioManager();
            music.PlayMusic("Fight.wav");

            int MaxMPPlayer = player._MP;
            int MaxMPEnemy = enemy._MP;
            /*Attacks test = new Attacks('p',5,2,'P');*/
            Waiter wait = new Waiter();
            MenuManager menu = new MenuManager();
            Random rdm = new Random();
            int Turn = 0;
            bool PlayerTurn;
            bool doPlayerDefend = false;
            string[] Skill;
            string[] Items;

            List<string> EnemyAttacksListing = new List<string>();
            string[] EnemyAttacks = { };

            foreach (KeyValuePair<string, Attacks> c in AttacksInit.Dictionary)
            {
                if (c.Value._FOR != "Player")
                {
                    EnemyAttacksListing.Add(c.Key);                    
                }
                EnemyAttacks = EnemyAttacksListing.ToArray();
            }

            if (PlayerInit.PlayerList["player1"]._HP <= 0)
            {
                player = PlayerInit.PlayerList["player2"];
            }
            if (PlayerInit.PlayerList["player2"]._HP <= 0 && PlayerInit.PlayerList["player1"]._HP <= 0)
            {
                player = PlayerInit.PlayerList["player3"];
            }

            if (isPlayerFaster(player, enemy))
            {
                PlayerTurn = true;
            } else { PlayerTurn= false; }

            while (!isFightEnd(player, enemy))
            {
                Console.Write("Turn");
                Console.WriteLine(Turn);
                if (PlayerTurn)
                {
                    if (player._HP > 0)
                    {
                        DisplayStats(player, enemy);
                        menu.FightMenu();
                        if (menu._ID == 0)
                        {
                            menu.AttackMenu();
                            if (menu._ID == 0)
                            {
                                Skill = menu.SkillMenu();
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine("=== Player Turn ===");
                                Console.WriteLine("");
                                Console.Write("You use ");
                                Console.WriteLine(Skill[menu._ID]);
                                Console.WriteLine("");
                                if (doPlayerAttackHit(player, enemy))
                                {
                                    Console.WriteLine("You give Damage :");
                                    Console.Write("-");
                                    Console.Write(AttacksInit.Dictionary[Skill[menu._ID]].usePlayerAttack(player, enemy));
                                    Console.WriteLine(" HP");

                                    int efctrdm = rdm.Next(0, 100);
                                    if (efctrdm <= AttacksInit.Dictionary[Skill[menu._ID]]._EFCT._HITCH)
                                    {
                                        enemy._EFCT = AttacksInit.Dictionary[Skill[menu._ID]]._EFCT;
                                    }
                                    wait.Wait();
                                }
                                else
                                {
                                    Console.WriteLine("You Missed");
                                    wait.Wait();
                                }
                                if (player._EFCT != EffectInit.Dictionary["None"])
                                {
                                    Console.WriteLine("");
                                    player._EFCT.GiveDamagetoPlayer(player);
                                }
                                wait.Wait();
                            }
                            else if (menu._ID == 1)
                            {
                                Console.Clear();
                                doPlayerDefend = true;
                                player._DEF += 5;
                                Console.WriteLine("You defend Yourself");
                                wait.Wait();
                                if (player._EFCT != EffectInit.Dictionary["None"])
                                {
                                    Console.WriteLine("");
                                    player._EFCT.GiveDamagetoPlayer(player);
                                }
                                wait.Wait();
                            }
                            else if (menu._ID == 2)
                            {
                                player = ChangePlayer(menu);
                                DisplayStats(player, enemy);
                                wait.Wait();
                            }
                        }
                        else if (menu._ID == 1)
                        {
                            Items = menu.ItemFightMenu();
                            ObjectInit.Dictionary[Items[menu._ID]].Healing(player);
                            ObjectInit.Dictionary[Items[menu._ID]].Cure(player);
                            ObjectInit.Dictionary[Items[menu._ID]].RegenMana(player);
                            ObjectInit.Dictionary[Items[menu._ID]]._QUANTITY -= 1;
                            wait.Wait();
                            Console.Clear();
                        }
                        else if (menu._ID == 2)
                        {
                            if (rdm.Next(0, 2) != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You Escaped");
                                wait.Wait();
                                enemy._HP = -1;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You Fail your Escape");
                                wait.Wait();
                            }
                        }
                    } else
                    {
                        player._ALIVE = false;
                        if (PlayerInit.PlayerList["player1"]._ALIVE == true || PlayerInit.PlayerList["player2"]._ALIVE == true || PlayerInit.PlayerList["player3"]._ALIVE == true)
                        {
                            player = ChangePlayer(menu);
                            DisplayStats(player, enemy);
                            wait.Wait();
                        }
                        else
                        {
                            //Dead
                        }
                    }
                    
                    if (enemy._HP > 0)
                    {
                        int ardm = rdm.Next(0, EnemyAttacks.Length);
                        Console.WriteLine("");
                        Console.WriteLine("=== Enemy Turn ===");
                        Console.WriteLine("");
                        Console.Write("Enemy use ");
                        Console.WriteLine(EnemyAttacks[ardm]);
                        Console.WriteLine("");
                        if (doEnemyAttackHit(player, enemy))
                        {
                            Console.WriteLine("You take Damage :");
                            Console.Write("-");
                            Console.Write(AttacksInit.Dictionary[EnemyAttacks[ardm]].useEnemyAttack(enemy, player));
                            Console.WriteLine(" HP");
                            wait.Wait();
                        }
                        else
                        {
                            Console.Write("You Evade");
                            wait.Wait();
                        }
                        if (enemy._EFCT != EffectInit.Dictionary["None"])
                        {
                            Console.WriteLine("");
                            enemy._EFCT.GiveDamagetoEnemy(enemy);
                            wait.Wait();
                        }
                    }
                }
                else
                {
                    DisplayStats(player, enemy);
                    int ardm = rdm.Next(0, EnemyAttacks.Length);
                    Console.WriteLine("");
                    Console.WriteLine("=== Enemy Turn ===");
                    Console.WriteLine("");
                    Console.Write("Enemy use ");
                    Console.WriteLine(EnemyAttacks[ardm]);
                    Console.WriteLine("");
                    if (doEnemyAttackHit(player, enemy))
                    {
                        Console.WriteLine("You take Damage :");
                        Console.Write("-");
                        Console.Write(AttacksInit.Dictionary[EnemyAttacks[ardm]].useEnemyAttack(enemy, player));
                        Console.WriteLine(" HP");
                        wait.Wait();
                    }
                    else
                    {
                        Console.Write("You Evade");
                        wait.Wait();
                    }
                    if (enemy._EFCT != EffectInit.Dictionary["None"])
                    {
                        Console.WriteLine("");
                        enemy._EFCT.GiveDamagetoEnemy(enemy);
                        wait.Wait();
                    }

                    if (player._HP > 0)
                    {
                        DisplayStats(player, enemy);
                        menu.FightMenu();
                        if (menu._ID == 0)
                        {
                            menu.AttackMenu();
                            if (menu._ID == 0)
                            {
                                Skill = menu.SkillMenu();
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine("=== Player Turn ===");
                                Console.WriteLine("");
                                Console.Write("You use ");
                                Console.WriteLine(Skill[menu._ID]);
                                Console.WriteLine("");
                                if (doPlayerAttackHit(player, enemy))
                                {
                                    Console.WriteLine("You give Damage :");
                                    Console.Write("-");
                                    Console.Write(AttacksInit.Dictionary[Skill[menu._ID]].usePlayerAttack(player, enemy));
                                    Console.WriteLine(" HP");
                                    wait.Wait();
                                }
                                else
                                {
                                    Console.WriteLine("You Missed");
                                    wait.Wait();
                                }
                            }
                            else if (menu._ID == 1)
                            {
                                Console.Clear();
                                doPlayerDefend = true;
                                player._DEF += 5;
                                Console.WriteLine("You defend Yourself");
                                wait.Wait();
                                if (player._EFCT != EffectInit.Dictionary["None"])
                                {
                                    player._EFCT.GiveDamagetoPlayer(player);
                                }
                                wait.Wait();
                            }
                            else if (menu._ID == 2)
                            {
                                player = ChangePlayer(menu);
                                DisplayStats(player, enemy);
                                wait.Wait();
                            }
                        }
                        else if (menu._ID == 1)
                        {
                            Items = menu.ItemFightMenu();
                            ObjectInit.Dictionary[Items[menu._ID]].Healing(player);
                            ObjectInit.Dictionary[Items[menu._ID]].Cure(player);
                            ObjectInit.Dictionary[Items[menu._ID]].RegenMana(player);
                            ObjectInit.Dictionary[Items[menu._ID]]._QUANTITY -= 1;
                            wait.Wait();
                            Console.Clear();
                        }
                        else if (menu._ID == 2)
                        {
                            if (rdm.Next(0, 2) != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You Escaped");
                                wait.Wait();
                                enemy._HP = -1;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You Fail your Escape");
                                wait.Wait();
                            }
                        }
                    }  
                }
                int mrdm = rdm.Next(5, 15);
                if (player._MP < MaxMPPlayer)
                {
                    if (player._MP + mrdm < MaxMPPlayer)
                    { 
                        player._MP = MaxMPPlayer;
                    }
                    else player._MP += mrdm;
                }
                if (doPlayerDefend) player._DEF -= 5;

                if (enemy._MP < MaxMPEnemy)
                {
                    if (enemy._MP + mrdm < MaxMPEnemy)
                    {
                        enemy._MP = MaxMPEnemy;
                    }
                    else enemy._MP += mrdm;
                }
                Turn++;
                if (player._HP <= 0)
                {
                    player._ALIVE = false;
                    if (PlayerInit.PlayerList["player1"]._ALIVE == true || PlayerInit.PlayerList["player2"]._ALIVE == true || PlayerInit.PlayerList["player3"]._ALIVE == true)
                    {
                        player = ChangePlayer(menu);
                        DisplayStats(player, enemy);
                        wait.Wait();
                    }
                    else
                    {
                        //Dead
                    }
                }
            }
            player._MP = MaxMPPlayer;
            GiveItem();
            PlayerInit.PlayerList["player1"].LVLUp();
            PlayerInit.PlayerList["player2"].LVLUp();
            PlayerInit.PlayerList["player3"].LVLUp();
            music.EndMusic("Fight.wav");
            music.PlayMusic("Explore.wav");
        }
        public Player ChangePlayer(MenuManager menu)
        {
            Player player;
            menu.ChangePlayerMenu();
            player = PlayerInit.PlayerList["player1"];
            switch (menu._ID)
            {
                case 0:
                    if (PlayerInit.PlayerList["player1"]._ALIVE == true)
                    {
                        player = PlayerInit.PlayerList["player1"];
                    }
                    else ChangePlayer(menu);
                    break;
                case 1:
                    if (PlayerInit.PlayerList["player2"]._ALIVE == true)
                    {
                        player = PlayerInit.PlayerList["player2"];
                    }
                    else ChangePlayer(menu);
                    break;
                case 2:
                    if (PlayerInit.PlayerList["player3"]._ALIVE == true)
                    {
                        player = PlayerInit.PlayerList["player3"];
                    }
                    else ChangePlayer(menu);
                    break;
            }
            Console.Write("Vous avez choisi ");
            Console.Write(player._NAME);
            return player;
        }

        public void DisplayStats(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("=============== Stats ===============");
            Console.Write("Enemy = ");
            Console.Write(enemy._NAME);
            Console.SetCursorPosition(21, 1);
            Console.Write("Player = ");
            Console.WriteLine(player._NAME);
            Console.Write("Enemy LVL = ");
            Console.Write(enemy._LVL);
            Console.SetCursorPosition(21, 2);
            Console.Write("Player LVL = ");
            Console.WriteLine(player._LVL);
            Console.Write("Enemy Hp = ");
            Console.Write(enemy._HP);
            Console.SetCursorPosition(21, 3);
            Console.Write("Player HP = ");
            Console.WriteLine(player._HP);
            Console.Write("Enemy Stamina = ");
            Console.Write(enemy._MP);
            Console.SetCursorPosition(21, 4);
            Console.Write("Player Stamina = ");
            Console.WriteLine(player._MP);
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
            if (player._HP <= 0 || enemy._HP <= 0) return true;
            else return false;
        }

        public void GiveItem()
        {
            Random random = new Random();
            int result = random.Next(0, 100);
            if (result >= 1)
            {
                result = random.Next(1, 3);
                for (int a = 0; a != result; a++)
                {
                    int result2 = random.Next(1, ObjectInit.Dictionary.Count);
                    switch (result2)
                    {
                        case 1:
                            ObjectInit.Dictionary["HealP"]._QUANTITY += 1;
                            break;
                        case 2:
                            ObjectInit.Dictionary["MPP"]._QUANTITY += 1;
                            break;
                        case 3:
                            ObjectInit.Dictionary["CureP"]._QUANTITY += 1;
                            break;
                        default: break;
                    }
                   
                }
            }
        }

        public int GiveDamageToPlayer(Player player, Enemy enemy)
        {
            int mult = 1;
            if (player._TYPE == "Plant" && enemy._TYPE == "Fire") mult = 2;
            if (player._TYPE == "Fire" && enemy._TYPE == "Water") mult = 2;
            if (player._TYPE == "Water" && enemy._TYPE == "Plant") mult = 2;
            int value = (enemy._ATT) - player._DEF;
            if (value < 0)
            {
                value = 0;
                player.TakeDamage(value);
            }
            else player.TakeDamage(value);
            return value;
        }

        public bool doPlayerAttackHit(Player player, Enemy enemy)
        {
            Random random = new Random();
            if (player._ACC < enemy._SPEED)
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
