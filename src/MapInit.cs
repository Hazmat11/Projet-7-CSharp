using System.Numerics;

namespace Projet_7
{
    internal class MapInit
    {
        public char[,] tab = new char[9, 9];

        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void InitTab()
        {
            for (var i = 0; i < tab.GetLength(0); i++)
            {
                for (var a = 0; a < tab.GetLength(1); a++)
                {
                    tab[i, a] = 'o';
                }
            }
        }

        public void PrintTab()
        {         
            tab[7,4] = 'x';

            for (var l = 0; l < tab.GetLength(0); l++)
            {
                for (var c = 0; c < tab.GetLength(1); c++)
                {
                    if (tab[l, c] == 'x')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    Console.Write(tab[l, c]);
                    Reset();
                }
                Console.WriteLine("t");
            }
        }
    }
}