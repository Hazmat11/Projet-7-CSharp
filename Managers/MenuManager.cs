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

        public void PauseMenu(Player player)
        {
            MapInit mi = new MapInit();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("menu.txt");
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
            mi.Save(player);
            srText.Close();
        }
    }
}