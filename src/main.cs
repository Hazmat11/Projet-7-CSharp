using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;

{
    public class main
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            MapInit mi = new MapInit();
            mi.InitTab();
            mi.PrintTab();
        }
    }
}