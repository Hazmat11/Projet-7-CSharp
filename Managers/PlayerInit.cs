using Projet_7.src;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_7.Managers
{
    public class PlayerInit
    {
        static Dictionary<string, Player> _playerlist;
        public static Dictionary<string, Player> PlayerList { get => _playerlist; }

        static PlayerInit()
        {
            _playerlist = new Dictionary<string, Player>()
            {
                { "player1", new Player(50, 100, 100, 30, 3, 8, 3, "Fire") },
                { "player2", new Player(50, 100, 100, 30, 3, 8, 3, "Fire") },
                { "player3", new Player(50, 100, 100, 30, 3, 8, 3, "Fire") },
            };
        }
    }
}
