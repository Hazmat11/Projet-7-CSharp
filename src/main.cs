using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Projet_7.Managers;

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



        public static void Main()
        {
            while (true)
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                ShowWindow(ThisConsole, MAXIMIZE);
                Console.Clear();
                EnemyManager manager = new EnemyManager();
                MenuManager mainMenu = new MenuManager();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                PlayerInit.PlayerList["player1"].LVLUp();
                PlayerInit.PlayerList["player2"].LVLUp();
                PlayerInit.PlayerList["player3"].LVLUp();
                mainMenu.MainMenu(PlayerInit.PlayerList["player1"], manager);
            }
        }
    }
}