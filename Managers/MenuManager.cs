using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;

namespace Projet_7.Managers
{
    internal class MenuManager
    {
        public int _ID { get; set; }
        String linetxt;
        public static bool optionMenu = false;
        public static bool menuPos = false;
        private bool inventoryLoop = true;
        public void MainMenu(Player player, EnemyManager manager)
        {
            string prompt = "Welcome to your menu";
            string[] Options = { "Jouer", "Options", "Exit" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run(0, 0);

            if (Index == 0)
            {
                Console.Clear();
                MapInit mi = new MapInit();
                mi.InitTab();
                mi.movePlayer(player, manager);
            }
            else if (Index == 1)
            {
                Console.Clear();
                Option();
                Console.ReadKey();
                Console.Clear();
                Index = 0;
                MainMenu(player, manager);
            }
            else if (Index == 2)
            {
                Environment.Exit(0);
            }
        }

        public void FightMenu()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, 5+i);
                Console.Write("                                     ");
            }
            Console.SetCursorPosition(0, 5);
            string prompt = "=====================================";
            string[] Options = { "Fight", "Use Item", "Escape" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run(0, 5);

            if (Index == 0) _ID = 0;
            else if (Index == 1) _ID = 1;
            else _ID = 2;
        }

        public void PauseMenu(MapInit map, Player player, EnemyManager enemyManager)
        {
            while (inventoryLoop)
            {
                string prompt = "\r\n  __  __                  \r\n |  \\/  |                 \r\n | \\  / | ___ _ __  _   _ \r\n | |\\/| |/ _ \\ '_ \\| | | |\r\n | |  | |  __/ | | | |_| |\r\n |_|  |_|\\___|_| |_|\\__,_|\r\n                          \r\n                          \r\n";
                string[] Options = { "Inventaire", "Team", "Resume", "Save and Quit" };
                Menu menu = new Menu(prompt, Options);
                optionMenu = true;
                int Index = menu.Run(0, 0);

                if (Index == 0)
                {
                    Inventory();
                }
                else if (Index == 2)
                {
                    inventoryLoop= false;
                    map.ingame = true;
                    Console.Clear();
                    map.WriteTab();
                    map.movePlayer(player, enemyManager);
                }
                else if (Index == 1)
                {
                    Equipment(player);
                }
                else if (Index == 3)
                {
                    player.SavePlayer();
                    Environment.Exit(0);
                }
            }
        }
        public void choosePlayer()
        {
            string prompt = "";
            string[] Options = { "Hazmat", "Mastrum", "Pandouille" };
            Menu menu = new Menu(prompt, Options);
            optionMenu = true;
            menuPos = true;

            int Index = menu.Run(0, 0);

            if (Index == 0)
            {
                playerStats(PlayerInit.PlayerList["player1"]);
            }
            else if (Index == 1)
            {
                playerStats(PlayerInit.PlayerList["player2"]);
            }
            else if (Index == 2)
            {
                playerStats(PlayerInit.PlayerList["player3"]);
            }
        }

        public void AttackMenu()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, 5 + i);
                Console.Write("                                     ");
            }
            Console.SetCursorPosition(0, 5);
            string prompt = "=====================================";
            string[] Options = { "Fight", "Defend", "Change Character"};
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run(0, 5);

            if (Index == 0) _ID = 0;
            else if (Index == 1) _ID = 1;
            else _ID = 2;
        }

        public string[] SkillMenu()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, 3 + i);
                Console.Write("                                     ");
            }
            Console.SetCursorPosition(0, 5);

            string prompt = "=====================================";
            List<string> OptionsList = new List<string>();
            string[] Options = { };

            foreach (KeyValuePair<string,Attacks> c in AttacksInit.Dictionary)
            {
                if (c.Value._FOR != "Enemy")
                {
                    OptionsList.Add(c.Key);
                }
                Options = OptionsList.ToArray();
            }

            Menu menu = new Menu(prompt, Options);

            int Index = menu.Run(0, 5);
            _ID = Index;
            return Options;
        }

        public void Inventory()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(90, 1);
            Console.WriteLine("  _____                      _                   ");
            Console.SetCursorPosition(90,2); Console.WriteLine(" |_   _|                    | |                  ");
            Console.SetCursorPosition(90,3); Console.WriteLine("   | |  _ ____   _____ _ __ | |_ ___  _ __ _   _ ");
            Console.SetCursorPosition(90,4); Console.WriteLine("   | | | '_ \\ \\ / / _ \\ '_ \\| __/ _ \\| '__| | | |");
            Console.SetCursorPosition(90,5); Console.WriteLine("  _| |_| | | \\ V /  __/ | | | || (_) | |  | |_| |");
            Console.SetCursorPosition(90,6); Console.WriteLine(" |_____|_| |_|\\_/ \\___|_| |_|\\__\\___/|_|   \\__, |");
            Console.SetCursorPosition(90,7); Console.WriteLine("                                            __/ |");
            Console.SetCursorPosition(90,8); Console.WriteLine("                                           |___/ ");
            Console.SetCursorPosition(90,9); Console.WriteLine("");
        }

        public void Equipment(Player player)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(90, 1);
            Console.WriteLine("  ______            _                            _   ");
            Console.SetCursorPosition(90, 2); Console.WriteLine(" |  ____|          (_)                          | |  ");
            Console.SetCursorPosition(90, 3); Console.WriteLine(" | |__   __ _ _   _ _ _ __  _ __ ___   ___ _ __ | |_ ");
            Console.SetCursorPosition(90, 4); Console.WriteLine(" |  __| / _` | | | | | '_ \\| '_ ` _ \\ / _ \\ '_ \\| __|");
            Console.SetCursorPosition(90, 5); Console.WriteLine(" | |___| (_| | |_| | | |_) | | | | | |  __/ | | | |_ ");
            Console.SetCursorPosition(90, 6); Console.WriteLine(" |______\\__, |\\__,_|_| .__/|_| |_| |_|\\___|_| |_|\\__|");
            Console.SetCursorPosition(90, 7); Console.WriteLine("           | |       | |                             ");
            Console.SetCursorPosition(90, 8); Console.WriteLine("           |_|       |_|                             ");
            Console.SetCursorPosition(90, 9); Console.WriteLine("");
            choosePlayer();
        }

        public void playerStats(Player player)
        {
            ClearMenu(30, 190);

            Console.SetCursorPosition(90, 15);
            Console.Write("Level: ");
            Console.SetCursorPosition(100, 15);
            Console.WriteLine(player._LVL);

            Console.SetCursorPosition(90, 16);
            Console.Write("Health: ");
            Console.SetCursorPosition(100,16);
            Console.WriteLine(player._HP);

            Console.SetCursorPosition(90, 17);
            Console.Write("Stamina: ");
            Console.SetCursorPosition(100,17);
            Console.WriteLine(player._MP);

            Console.SetCursorPosition(90, 18);
            Console.Write("Attack: ");
            Console.SetCursorPosition(100,18);
            Console.WriteLine(player._ATT);

            Console.SetCursorPosition(90, 19);
            Console.Write("Accuracy: ");
            Console.SetCursorPosition(100,19);
            Console.WriteLine(player._ACC);

            Console.SetCursorPosition(90, 20);
            Console.Write("Speed: ");
            Console.SetCursorPosition(100,20);
            Console.WriteLine(player._SPEED);

            Console.SetCursorPosition(90, 21);
            Console.Write("Defense: ");
            Console.SetCursorPosition(100,21);
            Console.WriteLine(player._DEF);

            Console.ReadKey();
            menuPos = false;
            ClearMenu(47,190);
        }

        public void ClearMenu(int j, int p)
        {
            Console.CursorVisible= false;
            for (int i = 1; i < j; i++)
            {
                for (int a = 54; a < p; a++)
                {
                    Console.SetCursorPosition(a,i);
                    Console.Write(' ');
                }
            }
        }

        public void Option()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("option.txt");
            //Read the first line of text
            linetxt = srText.ReadLine();
            //Continue to read until you reach end of file
            while (linetxt != null)
            {
                //write the line to console window
                Console.WriteLine(linetxt);

                //Read the next line
                linetxt = srText.ReadLine();
            };
            Console.SetCursorPosition(0, 0);
        }
    }
}