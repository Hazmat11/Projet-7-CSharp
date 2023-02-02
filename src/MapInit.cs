using System.Numerics;
using System.IO;
using Projet_7.src;
using System;
using System.Runtime.Intrinsics.Arm;
using Projet_7.Managers;
using System.Reflection.Metadata.Ecma335;
using Windows.UI.Xaml.Controls.Maps;
using static System.Net.Mime.MediaTypeNames;
using Windows.Foundation;
using Windows.UI.Xaml.Documents;

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
        public List<int> documentPos = new List<int>();
        public List<int> chestPos = new List<int>();
        public int numberLine = 0;
        public char nextChar = '.';
        public bool ingame = true;
        private bool talkedbefore = false;

        public int y = 0;
        public int x = 0;

        public int playerX = 0;
        public int playerY = 0;

        public int pnjPosX = 0;
        public int pnjPosY = 0;

        public int lastPosX = 0;
        public int lastPosY = 0;
        Map map = new Map();
        private bool acquisition = false;

        public String GameData;


        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void InitTab()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("\r\n      __  ___________  ___________   __        ______    ____  ____   _______       _______   ______   ___            __        __      _______   \r\n     /\"\"\\(\"     _   \")(\"     _   \") /\"\"\\      /    \" \\  (\"  _||_ \" | /\"     \"|     /\"     \"| /\" _  \"\\ |\"  |          /\"\"\\      |\" \\    /\"      \\  \r\n    /    \\)__/  \\\\__/  )__/  \\\\__/ /    \\    // ____  \\ |   (  ) : |(: ______)    (: ______)(: ( \\___)||  |         /    \\     ||  |  |:        | \r\n   /' /\\  \\  \\\\_ /        \\\\_ /   /' /\\  \\  /  /    )  )(:  |  | . ) \\/    |       \\/    |   \\/ \\     |:  |        /' /\\  \\    |:  |  |_____/   ) \r\n  //  __'  \\ |.  |        |.  |  //  __'  \\(: (____/ //  \\\\ \\__/ //  // ___)_      // ___)_  //  \\ _   \\  |___    //  __'  \\   |.  |   //      /  \r\n /   /  \\\\  \\\\:  |        \\:  | /   /  \\\\  \\\\         \\  /\\\\ __ //\\ (:      \"|    (:      \"|(:   _) \\ ( \\_|:  \\  /   /  \\\\  \\  /\\  |\\ |:  __   \\  \r\n(___/    \\___)\\__|         \\__|(___/    \\___)\\\"____/\\__\\(__________) \\_______)     \\_______) \\_______) \\_______)(___/    \\___)(__\\_|_)|__|  \\___) \r\n                                                                                                                                                  \r\n");
            SoldierPika();
            Thread.Sleep(2000);
            Reset();
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
                        if (tab[y,x] == 'd')
                        {
                            int documentPosX = x;
                            int documentPosY = y;
                            documentPos.Add(documentPosY);
                            documentPos.Add(documentPosX);
                        }
                        if (tab[y,x] == '¤')
                        {
                            int chestPosX = x;
                            int chestPosY = y;
                            chestPos.Add(chestPosY);
                            chestPos.Add(chestPosX);
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

        public void movePlayer(Player player, EnemyManager enemyManager)
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
                            shortMap(player, enemyManager);
                        }
                        if (nextChar == 'd')
                        {
                            nextChar = '.';
                        }
                        if (nextChar == '¤')
                        {
                            nextChar = '.';
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
                            shortMap(player, enemyManager);
                        }
                        if (nextChar == 'd')
                        {
                            nextChar = '.';
                        }
                        if (nextChar == '¤')
                        {
                            nextChar = '.';
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
                            shortMap(player, enemyManager);
                        }
                        if (nextChar == 'd')
                        {
                            nextChar = '.';
                        }
                        if (nextChar == '¤')
                        {
                            nextChar = '.';
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
                            shortMap(player, enemyManager);
                        }
                        if (nextChar == 'd')
                        {
                            nextChar = '.';
                        }
                        if (nextChar == '¤')
                        {
                            nextChar = '.';
                        }
                        break;
                    case 5:
                        SaveMap();
                        PauseMenu(player, enemyManager);
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
                Console.Write("Damn I really do hate those Pokemon, the only sh*t they can do is scream their names and only that !");
                Console.ReadKey();
                Console.SetCursorPosition(30, 55);
                Console.Write("If only there was a way to capture them and put them in a small box to use their competence for our own good...");
                Console.ReadKey();
                Console.SetCursorPosition(30, 56);
                Console.Write("Can you go kill like 5 Pokemon for my 'research' ?");
            }
            else if (playerY == pnjPos[2] && playerX == pnjPos[3])
            {
                DialogText();
                Console.SetCursorPosition(30, 54);
                if (acquisition)
                {
                    if (talkedbefore)
                    {
                        Console.Write("Thanks for finding the ultra secret confidential private classified restricted and sensitive documents that I lost");
                    }
                    else if (!talkedbefore)
                    {
                        Console.Write("Soldier !!! How the F*CK did you get those ultra secret confidential private classified restricted and sensitive documents ????!");
                        Console.ReadKey();
                        Console.SetCursorPosition(40, 55);
                        Console.Write("Sniper ! Kill him ! He's a spy !");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Dead();                       
                        ingame = false;
                    }
                }
                else
                {
                    Console.WriteLine("Welcome in living hell Soldier 76, you're here to kill 'em all, so grab your flamethrower and go burn those Lefties and Hobos.");
                    Console.ReadKey();
                    Console.SetCursorPosition(23, 55);
                    Console.WriteLine("By the way, can you go find the ultra secret confidential private classified restricted and sensitive documents that I lost on my way back to the camp ?");
                    talkedbefore = true;
                }
            }            
            if (playerY == documentPos[0] && playerX == documentPos[1])
            {
                acquisition  = true;
            }
            if (playerY == chestPos[0] && playerX == chestPos[1])
            {
                Random random = new Random();
                for (int a = 0; a != 10; a++)
                {                   
                    int result2 = random.Next(0, ObjectInit.Dictionary.Count);
                    switch (result2)
                    {
                        case 0:
                            ObjectInit.Dictionary["HealP"]._QUANTITY += 1;
                            break;
                        case 1:
                            ObjectInit.Dictionary["MPP"]._QUANTITY += 1;
                            break;
                        case 2:
                            ObjectInit.Dictionary["CureP"]._QUANTITY += 1;
                            break;
                        default: break;
                    }
                }
            }
        }

        public void randomCombat(Player player, EnemyManager enemyManager)
        {
            if (nextChar == '.')
            {
                Random rnd = new Random();
                int num = rnd.Next(0, 100);
                if (num < 5)
                {
                    Fight fight = new Fight(player, enemyManager.CreateEnemy());
                    Console.Clear();
                    WriteTab();
                }
            }
        }

        public void shortMap(Player player , EnemyManager enemyManager)
        {
            if (ingame == true)
            {
                randomCombat(player, enemyManager);

                if (ingame)
                {
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
            else if (ingame == false) {
            }
        }

        public void SaveMap()
        {
            try
            {
                path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };
                StreamWriter sw = new StreamWriter(choosenFile);
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
            }
        }

        public void PauseMenu(Player player, EnemyManager enemyManager)
        {
            Console.SetCursorPosition(0,0);
            MenuManager mi = new MenuManager();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("menu.txt");
            //Read the first line of text
            linetxt = srText.ReadLine();
            //Continue to read until you reach end of file
            while (linetxt != null)
            {
                //write the line to console window
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine(linetxt);

                //Read the next line
                linetxt = srText.ReadLine();
            };

            srText.Close();
            Reset();
            mi.PauseMenu(this,player, enemyManager);
        }

        public void SoldierPika()
        {
            Console.SetCursorPosition(0, 10);
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("soldier.txt");
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
        }

        public void Dead()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            //Pass the file path and file name to the StreamReader constructor
            StreamReader srText = new StreamReader("dead.txt");
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
            Console.SetCursorPosition(0, 0);
            Thread.Sleep(2000);
            Console.SetCursorPosition(0, 10);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(new String(' ', Console.BufferWidth));
                Thread.Sleep(100);
            }
        }
    }
}