﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Projet_7.src;
using Projet_7.Managers;

namespace Projet_7.src
{
    public class Player
    {
        public int _LVL { get; set; }
        public int _HP { get; set; }
        public int _MP { get; set; }
        public int _ATT { get; set; }
        public int _ACC { get; set; }
        public int _SPEED { get; set; }
        public int _DEF { get; set; }
        public Effects _EFCT { get; set; }
        public int _X { get; set; }
        public int _Y { get; set; }
        public string _TYPE { get; set; }

        public int keyValue = 0;

        public bool ingame = true;

        public Player(int lvlBase, int hpBase, int mpBase, int attBase, int accBase, int speedBase, int defBase, string type)
        {
            _LVL = lvlBase;
            _HP = hpBase;
            _MP = mpBase;
            _ATT = attBase;
            _ACC = accBase;
            _SPEED = speedBase;
            _DEF = defBase;
            _TYPE = type;
            _EFCT = EffectInit.Dictionary["None"];
            _X = 0;
            _Y = 0;

        }

        public void LVLUp()
        {
            _LVL++;
            _ATT = _ATT + (_ATT * _LVL) / 100;
            _ACC = _ACC + (_ACC * _LVL) / 100;
            _SPEED = _SPEED + (_SPEED * _LVL / 2) / 100;
            _DEF = _DEF + (_DEF * _LVL) / 100;
            _HP = _HP + (_HP * _LVL) / 100;
        }

        public void TakeDamage(int value)
        {
            _HP = _HP - value;
        }

        public void Heal(int value)
        {
            _HP = _HP + value;
        }

        public void UseMP(int value)
        {
            _MP = _MP - value;
        }

        public void RegenMP(int value)
        {
            _MP++;
        }

        public void detectKey(Player player)
        {  
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Z or ConsoleKey.UpArrow:
                    keyValue = 1;
                    break;
                case ConsoleKey.Q or ConsoleKey.LeftArrow:
                    keyValue = 2;
                    break;
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    keyValue = 3;
                    break;
                case ConsoleKey.D or ConsoleKey.RightArrow:
                    keyValue = 4;
                    break;
                case ConsoleKey.Escape:
                    keyValue= 5;
                    break;
                default:
                    keyValue = 6;
                    break;
            }
        }
        public void SavePlayer()
        {
            try
            {
                StreamWriter sw = new StreamWriter("save.txt");
                string[] lines = File.ReadAllLines("save.txt");

                List<int> saves = new List<int>();
                saves.Add(0);
                saves.Add(21);
                saves.Add(42);

                Console.WriteLine("Which save do you save? ( 1 , 2 , 3 )");
                string input = Console.ReadLine();

                int data = 0;

                if (int.Parse(input) == 0) 
                {
                    data = PlayerInit.PlayerList["Player1"]._LVL;
                    data = int.Parse(lines[saves[0]]);
                    File.WriteAllLines("save.txt", lines);
                }
                else if (int.Parse(input) == 1)
                {
                    data = int.Parse(lines[saves[1]]);
                }
                else 
                {
                    data = int.Parse(lines[saves[2]]);
                }

                sw.WriteLine(PlayerInit.PlayerList["Player1"]._LVL);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._HP);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._MP);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._ATT);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._ACC);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._SPEED);
                sw.WriteLine(PlayerInit.PlayerList["Player1"]._DEF);

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
           /* StreamWriter sw = new StreamWriter("save.txt");
            sw.WriteLine(_LVL);
            sw.WriteLine(_HP);
            sw.WriteLine(_MP);
            sw.WriteLine(_ATT);
            sw.WriteLine(_ACC);
            sw.WriteLine(_SPEED);
            sw.WriteLine(_DEF);
            sw.WriteLine(Map.choosenFile);
            sw.Close();*/
        }
        public void LoadPlayer()
        {
            if (File.Exists("save.txt"))
            {
                FileInfo info = new FileInfo("save.txt");

                Console.WriteLine("Which save do you load? ( 1 , 2 , 3 )");
                string input = Console.ReadLine();
                int i = 1;
                if (int.Parse(input) == 0)
                    i = 0;
                else
                    i = i * int.Parse(input);

                //int i = 7 * int.Parse(input);
                /*string[] PlayerData = File.ReadAllLines("save.txt");
                Player player = new Player(
                    int.Parse(PlayerData[i]),
                    int.Parse(PlayerData[i++]),
                    int.Parse(PlayerData[i++]),
                    int.Parse(PlayerData[i++]),
                    int.Parse(PlayerData[i++]),
                    int.Parse(PlayerData[i++]),
                    int.Parse(PlayerData[i++]));
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine(PlayerData[j]);
                }
                    int.Parse(PlayerData[i++]),
                    "");*/

                /*  if (info.Length != 0)
                  {

                  }
                  else
                  {
                      Console.WriteLine("Any game saved");
                  }*/
            }
            else
            {
                Console.WriteLine("Any data file");
            }
        }
    }
}