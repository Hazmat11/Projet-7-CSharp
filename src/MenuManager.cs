using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    internal class MenuManager
    {
        public void MainMenu()
        {
            string prompt = "Welcome to your menu";
            string[] Options = { "Fight", "Options", "Exit" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run();

            if (Index == 0)
            {

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
    }
}
