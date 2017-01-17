using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace Ludo
{
    public partial class Token : UserControl
    {
        public int ID { private set; get; }
        public Player Player { private set; get; }
        public int Status { set; get; } //0 - u početnoj kućici, 1 - na putu, 2 - u završnoj kućici
        public event EventHandler<EventArgs> LocationChanged;

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
            this.Status = 0;
            setHousesLocation(id, p.Color);

            PlQuery.PlCall("postavi_zeton_u_kucicu(" + id + "," + p.ID + ").");
            
        }

        public void setHousesLocation(int id, Color c)
        {
            Point startPoint = new Point();
            int correction = 0;
            if (c == Color.Red)
            {
                startPoint.X = 20;
                startPoint.Y = 20;
            }
            if (c == Color.Blue)
            {
                startPoint.X = 520;
                startPoint.Y = 20;
                correction = 4;
            }
            if (c == Color.Green)
            {
                startPoint.X = 520;
                startPoint.Y = 520;
                correction = 8;
            }
            if (c == Color.Yellow)
            {
                startPoint.X = 20;
                startPoint.Y = 520;
                correction = 12;
            }

            Point currentPoint = new Point();
            int locationId = id - correction;
            switch (locationId)
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
            this.Status = 0;
        }

        private void Token_MouseClick(object sender, MouseEventArgs e)
        {
            string boja = vratiBoju(this.Player.Color);
                        
            if (PlQuery.PlCall("provjeri_polje(" + this.ID + ", " + boja + ")" ))
            {
                PlTerm t1 = PlTerm.PlVar();
                PlQuery q2 = new PlQuery("novo_polje", new PlTermV(t1));
                q2.NextSolution();
                int novoPolje = int.Parse(t1.ToString());
                q2.Dispose();

                PlQuery.PlCall("pomakni_zeton(" + this.ID + ", " + novoPolje + ")");
                BoardField bf;

                if (novoPolje > 40)
                {
                    bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje && x.Color==this.Player.Color);
                    this.Status = 3;
                }
                else
                {
                    bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje);
                }

                bf.addTokenToField(this);
                //bf = BoardField.BoardFieldList.Find(x => x.Token == this);
                //bf.removeTokenFromField();
            }
            else
            {
                PlTerm var = PlTerm.PlVar();
                PlQuery q = new PlQuery("zeton", new PlTermV(var));
                q.NextSolution();
                int zetonID = int.Parse(var.ToString());
                q.Dispose();

                foreach (Player p in Player.PlayerList)
                {
                    foreach (Token t in p.TokenList)
                    {
                        if (t.ID == zetonID)
                        {
                            PlTerm t1 = PlTerm.PlVar();
                            PlQuery q2 = new PlQuery("novo_polje", new PlTermV(t1));
                            q2.NextSolution();
                            int novoPolje = int.Parse(t1.ToString());
                            q2.Dispose();

                            if (p.ID == Player.ID) // radi se o "mom" žetonu
                            {
                                novoPolje++;
                                preskociZetone(novoPolje);
                                BoardField bf;
                                if (novoPolje > 40)
                                {
                                    bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje && x.Color == this.Player.Color);
                                    this.Status = 3;
                                }
                                else
                                {
                                    bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje);
                                }
                                bf.addTokenToField(this);
                                bf = BoardField.BoardFieldList.Find(x => x.Token == this);
                                bf.removeTokenFromField();
                            }
                            else // radi se o tuđem žetonu
                            {
                                DialogResult dr = MessageBox.Show("Zelite li srušiti tuđi žeton?", "Rušenje žetona", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    BoardField bf;
                                    string b = vratiBoju(p.Color);
                                    if (PlQuery.PlCall("vrati_zeton_u_kucicu(" + zetonID + ", " + b + ")"))
                                    {                                        
                                        //bf = BoardField.BoardFieldList.Find(x => x.Token == t);
                                        //bf.removeTokenFromField();

                                        t.setHousesLocation(zetonID, p.Color);
                                    }

                                    preskociZetone(novoPolje);
                                    
                                    if (novoPolje > 40)
                                    {
                                        bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje && x.Color == this.Player.Color);
                                        this.Status = 3;
                                    }
                                    else
                                    {
                                        bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje);
                                    }
                                    bf.addTokenToField(this);
                                }
                                else //ne želim rušiti žeton
                                {
                                    novoPolje++;
                                    preskociZetone(novoPolje);
                                    BoardField bf;
                                    if (novoPolje > 40)
                                    {
                                        bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje && x.Color == this.Player.Color);
                                        this.Status = 3;
                                    }
                                    else
                                    {
                                        bf = BoardField.BoardFieldList.Find(x => x.ID == novoPolje);
                                    }
                                    bf.addTokenToField(this);
                                }
                            }
                            break;
                        }
                    }
                }

            }


        }

        private void preskociZetone(int novoPolje)
        {
            while (PlQuery.PlCall("provjeri_tocno_polje("+novoPolje+")") == false) {
                novoPolje++;
            }
            PlQuery.PlCall("pomakni_zeton(" + this.ID + ", " + novoPolje + ")");
        }

        private string vratiBoju(Color c)
        {
            if (c == Color.Red) return "red";
            if (c == Color.Blue) return "blue";
            if (c == Color.Green) return "green";
            if (c == Color.Yellow) return "yellow";
            else return "";
        }

        private void Token_MouseHover(object sender, EventArgs e)
        {
            
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            LocationChanged?.Invoke(this, new EventArgs());
        }
    }
}
