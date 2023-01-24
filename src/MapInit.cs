using System.Numerics;
using System.IO;

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
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("3.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        char letters = line[i];
                        switch (letters)
                        {
                            case '#': 
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case '~':
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case '-':
                                Console.ForegroundColor= ConsoleColor.Yellow;
                                break;
                            case '/' or '_' or '|' or '\u005c':
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case '.':
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;                           
                            default:
                                Reset();
                                break;                            
                        }
                        Console.Write(line[i]);
                    }

                    //write the line to console window
                    
                    //Read the next line
                    line = sr.ReadLine();
                    Console.WriteLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }     
    }
}