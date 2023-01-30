using System.IO;
using Projet_7.src;
using System;
using System.Security.Cryptography;

namespace Projet_7
{


    public class RandomNumberGenerator
    {
        private static int _randomNumber;
        private static readonly Random _random = new Random();

        static RandomNumberGenerator()
        {
            _randomNumber = _random.Next(0,5);
        }

        public static int RandomNumber
        {
            get { return _randomNumber; }
        }
    }

    internal class Map
    {
        public char[,] tab = new char[49, 192];
        String line;
        char letters;
        StreamReader sr;
        string[] path;
        int numberLine = 0;

        public Map()
        {

        }

        public void Write()
        {
            path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };

            //Pass the file path and file name to the StreamReader constructor
            sr = new StreamReader(path[RandomNumberGenerator.RandomNumber]);

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
    }
}