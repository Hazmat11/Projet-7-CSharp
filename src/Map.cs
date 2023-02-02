using System.IO;
using System;
using System.Security.Cryptography;

namespace Projet_7.src
{


    public class RandomNumberGenerator
    {
        private static int _randomNumber;
        private static readonly Random _random = new Random();

        static RandomNumberGenerator()
        {
            _randomNumber = _random.Next(0, 5);
        }

        public static int RandomNumber
        {
            get { return _randomNumber; }
        }
    }

    public class Map
    {
        public char[,] tab = new char[49, 192];
        string line;
        string line2;
        char letters;
        StreamReader sr;
        StreamReader sr2;
        public static string[] path;
        int numberLine = 0;
        public static string choosenFile;

        public Map()
        {

        }

        public void Write()
        {
            path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };

            Read();

            if (choosenFile == null)
            {
                choosenFile = path[RandomNumberGenerator.RandomNumber];
            }

            //Pass the file path and file name to the StreamReader constructor
            sr = new StreamReader(choosenFile);
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
        }

        public void Read()
        {
            sr2 = new StreamReader("save.txt");

            line2 = sr2.ReadLine();
            //Continue to read until you reach end of file
            while (line2 != null)
            {
                for (int i = 0; i < path.Length; i++)
                {
                    if (line2.Equals(path[i]))
                    {
                        choosenFile = path[i];
                        break;
                    };
                };
                line2 = sr2.ReadLine();
            }
            sr2.Close();
        }
    }
}