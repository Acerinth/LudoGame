using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ludo
{
    class BoardField
    {
        public static List<BoardField> BoardFieldList = new List<BoardField>();

        public int ID { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public Token Token { set; get; }
        public Color Color { set; get; }

        public BoardField(int id, int x, int y, Color c)
        {
            this.ID = id;
            this.X = x;
            this.Y = y;
            Token = null;
            this.Color = c;
        }

        public void addTokenToField(Token t)
        {
            this.Token = t;
            t.Location = new System.Drawing.Point(X, Y);
        }
        
        public void removeTokenFromField()
        {
            this.Token = null;
        }

    }
}
