using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
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
                Fight fight = new Fight(player, manager.CreateEnemy());
            }
            else if (Index == 1)
            {
                Console.Clear();
                MapInit mi = new MapInit();
                mi.InitTab();
                mi.movePlayer(player);
            }
            else if (Index == 2)
            {
                Environment.Exit(0);
            }
        }

        public void FightMenu()
        {
            string prompt = "=====================================";
            string[] Options = { "Fight", "Use Item", "Escape" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run(0, 3);

            if (Index == 0) _ID = 0;
            else if (Index == 1) _ID = 1;
            else _ID = 2;
        }  
        
        public void PauseMenu(MapInit map, Player player)
        {
            string prompt = "\r\n  __  __                  \r\n |  \\/  |                 \r\n | \\  / | ___ _ __  _   _ \r\n | |\\/| |/ _ \\ '_ \\| | | |\r\n | |  | |  __/ | | | |_| |\r\n |_|  |_|\\___|_| |_|\\__,_|\r\n                          \r\n                          \r\n";
            string[] Options = { "Inventaire", "Resume", "Save and Quit" };
            Menu menu = new Menu(prompt, Options);
            optionMenu = true;
            int Index = menu.Run(0, 0);

            if (Index == 0)
            {
                Inventory();
            }
            else if (Index == 2)
            {
                map.Save(player);
                Environment.Exit(0);
            }
            else if (Index == 1)
            {               
                map.ingame = true;
                Console.Clear();
                map.WriteTab();
                map.movePlayer(player);
            }
        }

        public void Inventory()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(50, 0);
            Console.Write("\r\n  _____                                           \r\n |_   _|                                          \r\n   | |  _ ____   _____ _ __  _ __ ___  _ __ _   _ \r\n   | | | '_ \\ \\ / / _ \\ '_ \\| '__/ _ \\| '__| | | |\r\n  _| |_| | | \\ V /  __/ | | | | | (_) | |  | |_| |\r\n |_____|_| |_|\\_/ \\___|_| |_|_|  \\___/|_|   \\__, |\r\n                                             __/ |\r\n                                            |___/ \r\n");
        }
    }
}