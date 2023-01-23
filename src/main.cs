using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_7.src;
namespace Projet_7.src
{
    public class main
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            MapInit mi = new MapInit();
            Player player = new Player(1,100,100,10,40,10,0);
            mi.InitTab();
            mi.PrintTab();
        }
    }
}