﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class MenuManager
    {
        public int _ID { get; set; }
        public void MainMenu(Player player, EnemyManager manager)
        {
            string prompt = "Welcome to your menu";
            string[] Options = { "Jouer", "Options", "Exit" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run();

            if (Index == 0)
            {
                Fight fight = new Fight(player, manager.CreateEnemy());
            }
            else if (Index == 1)
            {
                Console.Clear();
                MapInit mi = new MapInit();
                mi.InitTab();
            }
            else if (Index == 2)
            {

            }
        }

        public void FightMenu()
        {
            string prompt = "Welcome to your menu";
            string[] Options = { "Fight", "Use Item", "Escape"};
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run();

            if(Index == 0) _ID = 0;
            else if(Index == 1) _ID = 1;
            else _ID = 2;
        }
    }
}
