using System.Numerics;
using System.IO;

namespace Projet_7
{
    internal class MapInit
    {
        public char[,] tab = new char[9, 9];
        String linetxt;
        String line;
        String linewrite;
        string[] path;

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
                StreamReader sr = new StreamReader(path[ReturnRandomInt()]);

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

                DialogText();

                //close the file
                sr.Close();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                /*Console.WriteLine("Executing finally block.");*/
                WriteTab();
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
                path = new string[] { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };
                StreamWriter sw = new StreamWriter(path[ReturnRandomInt()]);
                sw.Write("test");
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
    }
}