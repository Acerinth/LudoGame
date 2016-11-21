using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Player
    {
        public static List<Player> PlayerList = new List<Player>();

        public int Number { private set; get; }
        public string Nickname { private set; get; }
        public Color Color { private set; get; }
        public string Type { private set; get; }

        public Player(int n, string nick, Color c, string t)
        {
            this.Number = n;
            this.Nickname = nick;
            this.Color = c;
            this.Type = t;
        }


    }
}
