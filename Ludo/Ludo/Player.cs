using System;
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

        public List<Token> TokenList = new List<Token>();

        public Player(int n, string nick, Color c, int t)
        {
            this.ID = n;
            this.Nickname = nick;
            this.Color = c;
            this.Type = t;
            setTokens();
        }

        private void setTokens()
        {
            int n = getFirstTokenId();
            if (n > 0)
            {
                for (int i = n; i < n+4; i++)
                {
                    Token t = new Token();
                    t.GenerateToken(i, this);
                    TokenList.Add(t);
                }
            }
            
        }

        private int getFirstTokenId()
        {
            if (Color == Color.Red)
            {
                return 1;
            }
            if (Color == Color.Blue)
            {
                return 5;
            }
            if (Color == Color.Green)
            {
                return 9;
            }
            if (Color == Color.Yellow)
            {
                return 13;
            }
            return -1;
        }

        


    }
}
