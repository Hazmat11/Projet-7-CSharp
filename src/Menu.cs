using Projet_7.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    class Menu : MenuManager
    {

        private int Index;
        private string Prompt;
        private string[] Options;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            Index = 0;
        }

        private void Display()
        {
            int origWidth = Console.WindowWidth;
            int origHeight = Console.WindowHeight;
            if (MenuManager.optionMenu)
            {
                Console.SetCursorPosition(20, 0);
            }
            Console.WriteLine(Prompt);
            Console.WriteLine("");
            for (int i = 0; i < Options.Length; i++) 
            {
                string Option = Options[i];

                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (MenuManager.optionMenu)
                {
                    Console.SetCursorPosition(10, 5 * i + 10);
                }
                Console.WriteLine($"<< {Option} >>");
            }
            Console.ResetColor();
        }
        public int Run(int x,int y)
        {
            ConsoleKey keyPressed;
            do
            {
                Display();
                Console.SetCursorPosition(x,y);
                ConsoleKeyInfo keyInfo= Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;
                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                    if (Index == -1)
                    {
                        Index = Options.Length -1;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
    }
}
