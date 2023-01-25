﻿using System.Numerics;
using System.IO;
using Projet_7.src;
using System;

namespace Projet_7
{
    internal class MapInit
    {
        public char[,] tab = new char[49,191];
        String linetxt;
        String line;
        char letters;
        StreamReader sr;
        string[] path;
        List<int> pnjPos = new List<int>();
        int numberLine = 0;
        char nextChar = '.';

        public int y = 0;
        public int x = 0;

        public int playerX = 0;
        public int playerY = 0;

        public int pnjPosX = 0;
        public int pnjPosY = 0;

        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void InitTab()
        {                     
            try
            {
                path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };

                //Pass the file path and file name to the StreamReader constructor
                sr = new StreamReader("1.txt");

                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        letters = line[i];
                        tab[numberLine, i] = letters;                      
                    }
                    numberLine++;
                    //write the line to console window

                    //Read the next line
                    line = sr.ReadLine();                  
                }
                //close the file
                sr.Close();
                WriteTab();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                /*Console.WriteLine("Executing finally block.");*/
            }
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
                Console.Clear();
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
                /*Console.WriteLine("Executing finally block.");*/
            }
        }
    
        public int ReturnRandomInt()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 5);
            return num;
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
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Reset();
                    break;
            }
        }

        public void movePlayer(Player player)
        {
            while (true)
            {
                player.detectKey();

                switch (player.keyValue)
                {
                    case 1:
                        tab[playerY, playerX] = nextChar;
                        nextChar = tab[playerY - 1, playerX];
                        tab[playerY -= 1, playerX] = '&';
                        WriteTab();
                        break;
                    case 2:
                        tab[playerY, playerX] = nextChar;
                        nextChar = tab[playerY, playerX - 1];
                        tab[playerY, playerX -= 1] = '&';
                        WriteTab();
                        break;
                    case 3:
                        tab[playerY, playerX] = nextChar;
                        nextChar = tab[playerY + 1, playerX];
                        tab[playerY += 1, playerX] = '&';
                        WriteTab();
                        break;
                    case 4:
                        tab[playerY, playerX] = nextChar;
                        nextChar = tab[playerY, playerX + 1];
                        tab[playerY, playerX += 1] = '&';
                        WriteTab();
                        break;
                    default:
                        break;
                }
                PNJ();
            }
        }

        public void PNJ()
        {
            if (playerY == pnjPos[0] && playerX == pnjPos[1])
            {
                Console.Write("ta gueule");
            }
            else if(playerY == pnjPos[2] && playerX == pnjPos[3])
            {
                Console.Write("ta grosse gueule");
            }
        }
    }
}