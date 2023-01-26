using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    class Menu
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
            Console.WriteLine(Prompt);
            Console.WriteLine("");
            for (int i = 0; i < Options.Length; i++) 
            {
                string Option = Options[i];
                string Choice;

                if (i == Index)
                {
                    Choice = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Choice = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"<< {Option} >>");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Display();

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
