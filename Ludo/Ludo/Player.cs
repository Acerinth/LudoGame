﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class Player
    {
        public static List<Player> PlayerList = new List<Player>();

        public int ID { private set; get; }
        public string Nickname { private set; get; }
        public Color Color { private set; get; }
        public int Type { private set; get; }

        public Player(int n, string nick, Color c, int t)
        {
            this.ID = n;
            this.Nickname = nick;
            this.Color = c;
            this.Type = t;
        }


    }
}
