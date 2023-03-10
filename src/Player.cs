using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Projet_7.src;
using Projet_7.Managers;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using static Uno.CompositionConfiguration;

namespace Projet_7.src
{
    public class Player
    {
        public string _NAME { get; set; }
        public int _LVL { get; set; }
        public int _HPMAX { get; set; }
        public int _HP { get; set; }
        public int _MP { get; set; }
        public int _ATT { get; set; }
        public int _ACC { get; set; }
        public int _SPEED { get; set; }
        public int _DEF { get; set; }

        [JsonIgnore]
        public Effects _EFCT { get; set; }
        public int _X { get; set; }
        public int _Y { get; set; }
        public string _TYPE { get; set; }
        public bool _ALIVE { get; set; }


        [JsonIgnore]
        public int keyValue = 0;

        [JsonIgnore]
        public bool ingame = true;

        public Player(string name, int lvlBase, int hpBase, int mpBase, int attBase, int accBase, int speedBase, int defBase, string type)
        {
            _NAME = name;
            _LVL = lvlBase;
            _HPMAX = hpBase;
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
            _ALIVE = true;
        }

#if true
        /* Use to load player */
        [JsonConstructor]
        public Player(int _LVL, int _HP, int _MP, int _ATT, int _ACC, int _SPEED, int _DEF, int _X, int _Y, string _TYPE)
        {
            this._LVL = _LVL;
            this._HP = _HP;
            this._MP = _MP;
            this._ATT = _ATT;
            this._ACC = _ACC;
            this._SPEED = _SPEED;
            this._DEF = _DEF;
            this._X = _X;
            this._Y = _Y;
            this._TYPE = _TYPE;
        }
        /* Use to load player */
#endif
        public void LVLUp()
        {
            _LVL++;
            _ATT = _ATT + (_ATT * _LVL) / 100;
            _ACC = _ACC + (_ACC * _LVL) / 100;
            _SPEED = _SPEED + (_SPEED * _LVL / 2) / 100;
            _DEF = _DEF + (_DEF * _LVL) / 100;
            _HPMAX = _HPMAX + (_HPMAX * _LVL) / 100;
        }

        public void TakeDamage(int value)
        {
            _HP = _HP - value;
        }

        public void Heal(int value)
        {
            if (_HP + value > _HPMAX)
            {
                _HP = _HPMAX;
            } else _HP = _HP + value;
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

        public void Save(string key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(key).Append(".json");

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, PropertyNameCaseInsensitive = true, IncludeFields = true };

            string path = Path.Combine(Environment.CurrentDirectory, "Save", sb.ToString());
            string json = JsonSerializer.Serialize(this, options);

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Save"))) Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Save"));

            File.WriteAllText(path, json);

        }

        public void Load(string key)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, PropertyNameCaseInsensitive = true, IncludeFields = true };
            foreach (var p in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Save")))
            {
                string fileName = Path.Combine(Environment.CurrentDirectory, "Save", p.ToString());
                string jsonString = File.ReadAllText(fileName);
                Player weatherForecast = JsonSerializer.Deserialize<Player>(jsonString, options)!;
            }
        }

        public void LoadMap()
        {
            StreamWriter sw = new StreamWriter("save.txt");
            sw.WriteLine(Map.choosenFile);
            sw.Close();
        }
    }
}