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
                Index = 0;
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
            string prompt = "\r\n  __  __                  \r\n |  \\/  |                 \r\n | \\  / | ___ _ __  _   _ \r\n | |\\/| |/ _ \\ '_ \\| | | |\r\n | |  | |  __/ | | | |_| |\r\n |_|  |_|\\___|_| |_|\\__,_|\r\n                          \r\n                          \r\n";
            string[] Options = { "Inventaire", "Resume", "Save and Quit" };
            Menu menu = new Menu(prompt, Options);
            optionMenu = true;
            int Index = menu.Run(0, 0);

            if (Index == 0)
            {
                //Inventory();
            }
            else if (Index == 2)
            {
                //map.Save(player);
                Environment.Exit(0);
            }
            else if (Index == 1)
            {               
                map.ingame = true;
                Console.Clear();
                map.WriteTab();
                map.movePlayer(player, enemyManager);
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

        public void PauseMenu(Player player)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("  _____                      _                   ");
            Console.SetCursorPosition(80,4); Console.WriteLine(" |_   _|                    | |                  ");
            Console.SetCursorPosition(80,5); Console.WriteLine("   | |  _ ____   _____ _ __ | |_ ___  _ __ _   _ ");
            Console.SetCursorPosition(80,6); Console.WriteLine("   | | | '_ \\ \\ / / _ \\ '_ \\| __/ _ \\| '__| | | |");
            Console.SetCursorPosition(80,7); Console.WriteLine("  _| |_| | | \\ V /  __/ | | | || (_) | |  | |_| |");
            Console.SetCursorPosition(80,8); Console.WriteLine(" |_____|_| |_|\\_/ \\___|_| |_|\\__\\___/|_|   \\__, |");
            Console.SetCursorPosition(80,9); Console.WriteLine("                                            __/ |");
            Console.SetCursorPosition(80,10); Console.WriteLine("                                           |___/ ");
            Console.SetCursorPosition(80,11); Console.WriteLine("");
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