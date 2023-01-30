using System.Numerics;
using System.IO;
using Projet_7.src;
using System;
using System.Runtime.Intrinsics.Arm;
using Projet_7.Managers;

namespace Projet_7
{
    internal class MapInit : Map
    {
        public char[,] tab = new char[49, 191];
        public String linetxt;
        public String line;
        public char letters;
        public StreamReader sr;
        public string[] path;
        public List<int> pnjPos = new List<int>();
        public int numberLine = 0;
        public char nextChar = '.';
        bool ingame = true;

        public int y = 0;
        public int x = 0;

        public int playerX = 0;
        public int playerY = 0;

        public int pnjPosX = 0;
        public int pnjPosY = 0;

        public int lastPosX = 0;
        public int lastPosY = 0;
        Map map = new Map();

        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void InitTab()
        {
            Console.Write("\r\n      __  ___________  ___________   __        ______    ____  ____   _______       _______   ______   ___            __        __      _______   \r\n     /\"\"\\(\"     _   \")(\"     _   \") /\"\"\\      /    \" \\  (\"  _||_ \" | /\"     \"|     /\"     \"| /\" _  \"\\ |\"  |          /\"\"\\      |\" \\    /\"      \\  \r\n    /    \\)__/  \\\\__/  )__/  \\\\__/ /    \\    // ____  \\ |   (  ) : |(: ______)    (: ______)(: ( \\___)||  |         /    \\     ||  |  |:        | \r\n   /' /\\  \\  \\\\_ /        \\\\_ /   /' /\\  \\  /  /    )  )(:  |  | . ) \\/    |       \\/    |   \\/ \\     |:  |        /' /\\  \\    |:  |  |_____/   ) \r\n  //  __'  \\ |.  |        |.  |  //  __'  \\(: (____/ //  \\\\ \\__/ //  // ___)_      // ___)_  //  \\ _   \\  |___    //  __'  \\   |.  |   //      /  \r\n /   /  \\\\  \\\\:  |        \\:  | /   /  \\\\  \\\\         \\  /\\\\ __ //\\ (:      \"|    (:      \"|(:   _) \\ ( \\_|:  \\  /   /  \\\\  \\  /\\  |\\ |:  __   \\  \r\n(___/    \\___)\\__|         \\__|(___/    \\___)\\\"____/\\__\\(__________) \\_______)     \\_______) \\_______) \\_______)(___/    \\___)(__\\_|_)|__|  \\___) \r\n                                                                                                                                                  \r\n");
            Thread.Sleep(1000);
            Console.Clear();
            map.Write();
            tab = map.tab;
            WriteTab();
        }

        public void DialogText()
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("dialog.txt");
            //Read the first line of text
            linetxt = srText.ReadLine();
            //Continue to read until you reach end of file
            while (linetxt != null)
            {
                //write the line to console window
                Console.WriteLine(linetxt);

                //Read the next line
                linetxt = srText.ReadLine();
            }
            srText.Close();
        }

        public void WriteTab()
        {
            try
            {
                for (y = 0; y < tab.GetLength(0); y++)
                {
                    for (x = 0; x < tab.GetLength(1); x++)
                    {
                        letters = tab[y, x];
                        if (tab[y, x] == '&')
                        {
                            playerX = x;
                            playerY = y;
                        }
                        if (tab[y, x] == 'p')
                        {
                            pnjPosX = x;
                            pnjPosY = y;
                            pnjPos.Add(pnjPosY);
                            pnjPos.Add(pnjPosX);
                        }
                        Recolor();
                        Console.Write(tab[y, x]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.SetCursorPosition(playerX, playerY);
                /*Console.WriteLine("Executing finally block.");*/
            }
        }

        public void Recolor()
        {
            switch (letters)
            {
                case '#':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case '-':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case ',':
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case '/' or '_' or '|' or '\u005c':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case '.':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'p':
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case '&':
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Reset();
                    break;
            }
        }

        public void movePlayer(Player player)
        {
            while (ingame)
            {
                player.detectKey(player);

                switch (player.keyValue)
                {
                    case 1:
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX] = nextChar;
                            lastPosX = playerX;
                            lastPosY = playerY;

                        }
                        nextChar = tab[playerY - 1, playerX];
                        if (nextChar != '~')
                        {
                            tab[playerY -= 1, playerX] = '&';
                            shortMap();
                        }
                        break;
                    case 2:
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX] = nextChar;
                            lastPosX = playerX;
                            lastPosY = playerY;
                        }
                        nextChar = tab[playerY, playerX - 1];
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX -= 1] = '&';
                            shortMap();
                        }
                        break;
                    case 3:
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX] = nextChar;
                            lastPosX = playerX;
                            lastPosY = playerY;
                        }
                        nextChar = tab[playerY + 1, playerX];
                        if (nextChar != '~')
                        {
                            tab[playerY += 1, playerX] = '&';
                            shortMap();
                        }
                        break;
                    case 4:
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX] = nextChar;
                            lastPosX = playerX;
                            lastPosY = playerY;
                        }
                        nextChar = tab[playerY, playerX + 1];
                        if (nextChar != '~')
                        {
                            tab[playerY, playerX += 1] = '&';
                            shortMap();
                        }
                        break;
                    case 5:
                        PauseMenu(player);
                        ingame = false;
                        break;
                    default:
                        break;
                }
                PNJ();
            }
        }

        public void PNJ()
        {
            Console.WriteLine();
            Reset();
            Console.SetCursorPosition(0, 49);
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine(new String(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, 49);
            if (playerY == pnjPos[0] && playerX == pnjPos[1])
            {
                DialogText();
                Console.SetCursorPosition(30, 54);
                Console.Write("ta gueule");
            }
            else if (playerY == pnjPos[2] && playerX == pnjPos[3])
            {
                DialogText();
                Console.SetCursorPosition(30, 54);
                Console.Write("ta grosse gueule");
            }
        }

        public void randomCombat()
        {
            if (nextChar == '.')
            {
                Random rnd = new Random();
                int num = rnd.Next(0, 100);
                if (num < 5)
                {
                    //Combat
                }
            }
        }

        public void shortMap()
        {
            if (ingame)
            {
                randomCombat();

                Console.CursorVisible = false;
                Console.SetCursorPosition(playerX, playerY);
                letters = tab[playerY, playerX];
                Recolor();
                Console.Write(tab[playerY, playerX]);

                Console.SetCursorPosition(lastPosX, lastPosY);
                letters = tab[lastPosY, lastPosX];
                Recolor();
                Console.Write(tab[lastPosY, lastPosX]);

                Recolor();
            }
        }

        public void Save(Player player)
        {
            try
            {
                StreamWriter sw = new StreamWriter("save.txt");
                sw.Write(player._LVL);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.SetCursorPosition(0, 0);
            }

            try
            {
                path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };
                StreamWriter sw = new StreamWriter(path[RandomNumberGenerator.RandomNumber]);
                for (y = 0; y < tab.GetLength(0); y++)
                {
                    for (x = 0; x < tab.GetLength(1); x++)
                    {
                        letters = tab[y, x];
                        sw.Write(tab[y, x]);
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.SetCursorPosition(0, 0);
                /*Console.WriteLine("Executing finally block.");*/
            }
        }

        public void PauseMenu(Player player)
        {
            Console.SetCursorPosition(0,0);
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
            Save(player);
            srText.Close();
        }
    }
}