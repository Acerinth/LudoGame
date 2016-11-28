using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ludo
{
    public partial class Token : UserControl
    {
        public int ID { private set; get; }
        public Player Player { private set; get; }
        

        public Token()
        {
            InitializeComponent();
        }

        private void Token_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(Player.Color);
            Pen p = new Pen(Color.Black);
            p.Width = 3;

            e.Graphics.FillEllipse(b, 10, 10, 30, 30);
            e.Graphics.DrawEllipse(p, 10, 10, 30, 30);
        }

        private void Token_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(Token_Paint);
        }

        public void GenerateToken(int id, Player p)
        {
            this.ID = id;
            this.Player = p;
            setHousesLocation(id, p.Color);

            //azurirati bazu znanja --> postaviti tokene u kucice
        }

        private void setHousesLocation(int id, Color c)
        {
            Point startPoint = new Point();
            if (c == Color.Red)
            {
                startPoint.X = 20;
                startPoint.Y = 20;
            }
            if (c == Color.Blue)
            {
                startPoint.X = 520;
                startPoint.Y = 20;
            }
            if (c == Color.Green)
            {
                startPoint.X = 520;
                startPoint.Y = 520;
            }
            if (c == Color.Yellow)
            {
                startPoint.X = 20;
                startPoint.Y = 520;
            }

            Point currentPoint = new Point();
            switch (id)
            {
                case 1:
                    currentPoint = startPoint;
                    break;
                case 2:
                    currentPoint.X = startPoint.X + 60;
                    currentPoint.Y = startPoint.Y;
                    break;
                case 3:
                    currentPoint.X = startPoint.X;
                    currentPoint.Y = startPoint.Y + 60;
                    break;
                case 4:
                    currentPoint.X = startPoint.X + 60;
                    currentPoint.Y = startPoint.Y + 60;
                    break;
            }

            Location = currentPoint;
        }
    }
}
