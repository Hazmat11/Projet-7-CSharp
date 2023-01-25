using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.src
{
    class SaveManager
    {



        public SaveManager(Player player) 
        {
            DirectoryInfo[] save = new DirectoryInfo(@"C:\Users\agouveia\Documents\GitHub\Projet - 7 - CSharp\ressources").GetDirectories();

            using (StreamWriter sw = new StreamWriter("save.txt"))
            {
                foreach (DirectoryInfo dir in save)
                {
                    sw.WriteLine(player);
                }
            }









        }
    }
}
