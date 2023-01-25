using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;
namespace Projet_7.src
{
    static class main
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.Clear();
            EnemyManager manager = new EnemyManager();
            MenuManager mainMenu= new MenuManager();
            Player player = new Player(50, 100, 100, 30, 3, 8, 3);
            player.LVLUp();
            mainMenu.MainMenu();

            //player.Move();


/*            EnemyManager manager = new EnemyManager();
            Player player = new Player(50, 100, 100, 30, 3, 8, 3);
            player.LVLUp();

            Fight fight = new Fight(player, manager.CreateEnemy());*/
            string prompt = "Welcome to your menu";
            string[] Options = {"Team","Objects","Options" };
            Menu menu = new Menu(prompt, Options);
            int Index = menu.Run();

/*            MapInit mi = new MapInit();
            Player player = new Player(1,100,100,10,40,10,0);
            mi.InitTab();
            mi.movePlayer(player);*/
        }
    }
}