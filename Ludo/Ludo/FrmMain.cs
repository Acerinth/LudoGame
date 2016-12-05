using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ludo
{
    public partial class FrmMain : Form
    {
        public static List<string> PlayerTypeList { get; private set; } = new List<string>();
        public static string[] p = { "-q", "-f", @"F:\OneDrive\FOI\2. DS - BPBZ\1. semestar\LP\Projekt\LudoGame\Ludo\Ludo\covjece.pl" };

        public FrmMain()
        {
            InitializeComponent();
            InitializePlayerTypeList();
            PlEngine.Initialize(p);
            //PlQuery consult = new PlQuery("consult(covjece.pl)");
            //consult.NextSolution();
        }

        private void InitializePlayerTypeList()
        {
            PlayerTypeList.Add("Human");
            PlayerTypeList.Add("CPU");
            PlayerTypeList.Add("Not playing");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewGame newGame = new FrmNewGame();
            newGame.ShowDialog();
            foreach (Player p in Player.PlayerList)
            {
                foreach (Token t in p.TokenList)
                {
                    panelBoard.Controls.Add(t);
                }
            }
            FrmFirstPlay firstPlay = new FrmFirstPlay();
            firstPlay.ShowDialog();

            //begin game

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            p.Width = 2;

            //crte - horizontalne
            e.Graphics.DrawLine(p, 25, 266, 266, 266);
            e.Graphics.DrawLine(p, 25, 384, 266, 384);

            e.Graphics.DrawLine(p, 384, 266, 625, 266);
            e.Graphics.DrawLine(p, 384, 384, 625, 384);

            e.Graphics.DrawLine(p, 266, 25, 384, 25);
            e.Graphics.DrawLine(p, 266, 625, 384, 625);

            //crte - vertikalne
            e.Graphics.DrawLine(p, 266, 25, 266, 266);
            e.Graphics.DrawLine(p, 266, 384, 266, 625);

            e.Graphics.DrawLine(p, 384, 25, 384, 266);
            e.Graphics.DrawLine(p, 384, 384, 384, 625);

            e.Graphics.DrawLine(p, 25, 266, 25, 384);
            e.Graphics.DrawLine(p, 625, 266, 625, 384);

            //crte - do kucice
            e.Graphics.DrawLine(p, 25, 325, 266, 325);
            e.Graphics.DrawLine(p, 384, 325, 625, 325);
            e.Graphics.DrawLine(p, 325, 25, 325, 266);
            e.Graphics.DrawLine(p, 325, 384, 325, 625);


            e.Graphics.FillEllipse(Brushes.White, 0, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 0, 300, 50, 50);

            //crveni cilj
            e.Graphics.FillEllipse(Brushes.Red, 64, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 64, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 123, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 123, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 182, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 182, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 241, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 300, 50, 50);

            //zeleni cilj
            e.Graphics.FillEllipse(Brushes.Green, 359, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 418, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 418, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 477, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 477, 300, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 536, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 536, 300, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 600, 300, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 600, 300, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 300, 0, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 0, 50, 50);

            //plavi cilj
            e.Graphics.FillEllipse(Brushes.Blue, 300, 64, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 64, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 300, 123, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 123, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 300, 182, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 182, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 300, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 241, 50, 50);

            //zuti cilj
            e.Graphics.FillEllipse(Brushes.Yellow, 300, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 300, 418, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 418, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 300, 477, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 477, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 300, 536, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 536, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 300, 600, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 300, 600, 50, 50);


            //put-lijevo
            e.Graphics.FillEllipse(Brushes.IndianRed, 0, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 0, 241, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 59, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 59, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 118, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 118, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 177, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 177, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 241, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 0, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 0, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 59, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 59, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 118, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 118, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 177, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 177, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 359, 50, 50);

            //put-desno
            e.Graphics.FillEllipse(Brushes.White, 359, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 423, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 423, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 482, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 482, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 541, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 541, 241, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 600, 241, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 600, 241, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 359, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 423, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 423, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 482, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 482, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 541, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 541, 359, 50, 50);
            e.Graphics.FillEllipse(Brushes.LightGreen, 600, 359, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 600, 359, 50, 50);

            //put-gore
            e.Graphics.FillEllipse(Brushes.White, 241, 0, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 0, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 59, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 59, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 118, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 118, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 177, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 177, 50, 50);

            e.Graphics.FillEllipse(Brushes.SkyBlue, 359, 0, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 0, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 59, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 59, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 118, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 118, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 177, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 177, 50, 50);

            //put-dolje
            
            e.Graphics.FillEllipse(Brushes.White, 241, 423, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 423, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 482, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 482, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 241, 541, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 541, 50, 50);
            e.Graphics.FillEllipse(Brushes.Goldenrod, 241, 600, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 241, 600, 50, 50);

            e.Graphics.FillEllipse(Brushes.White, 359, 423, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 423, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 482, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 482, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 541, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 541, 50, 50);
            e.Graphics.FillEllipse(Brushes.White, 359, 600, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 359, 600, 50, 50);

            //crvena kucica
            e.Graphics.FillEllipse(Brushes.Red, 20, 20, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 20, 20, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 80, 20, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 80, 20, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 20, 80, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 20, 80, 50, 50);
            e.Graphics.FillEllipse(Brushes.Red, 80, 80, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 80, 80, 50, 50);

            //plava kucica
            e.Graphics.FillEllipse(Brushes.Blue, 520, 20, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 520, 20, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 580, 20, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 580, 20, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 520, 80, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 520, 80, 50, 50);
            e.Graphics.FillEllipse(Brushes.Blue, 580, 80, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 580, 80, 50, 50);

            //zuta kucica
            e.Graphics.FillEllipse(Brushes.Yellow, 20, 520, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 20, 520, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 80, 520, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 80, 520, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 20, 580, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 20, 580, 50, 50);
            e.Graphics.FillEllipse(Brushes.Yellow, 80, 580, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 80, 580, 50, 50);

            //zelena kucica
            e.Graphics.FillEllipse(Brushes.Green, 520, 520, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 520, 520, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 580, 520, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 580, 520, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 520, 580, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 520, 580, 50, 50);
            e.Graphics.FillEllipse(Brushes.Green, 580, 580, 50, 50);
            e.Graphics.DrawEllipse(Pens.Black, 580, 580, 50, 50);

            //strelice
            List<Point> arrow = new List<Point>();
            arrow.Add(new Point(84, 200));
            arrow.Add(new Point(84, 220));
            arrow.Add(new Point(118, 210));
            e.Graphics.FillPolygon(Brushes.Black, arrow.ToArray());
            Pen p2 = new Pen(Color.Black);
            p2.Width = 3;
            e.Graphics.DrawLine(p2, 25, 210, 84, 210);

            List<Point> arrow2 = new List<Point>();
            arrow2.Add(new Point(430, 84));
            arrow2.Add(new Point(450, 84));
            arrow2.Add(new Point(440, 118));
            e.Graphics.FillPolygon(Brushes.Black, arrow2.ToArray());
            e.Graphics.DrawLine(p2, 440, 25, 440, 84);

            List<Point> arrow3 = new List<Point>();
            arrow3.Add(new Point(561, 430));
            arrow3.Add(new Point(561, 450));
            arrow3.Add(new Point(527, 440));
            e.Graphics.FillPolygon(Brushes.Black, arrow3.ToArray());
            e.Graphics.DrawLine(p2, 561, 440, 625, 440);

            List<Point> arrow4 = new List<Point>();
            arrow4.Add(new Point(200, 561));
            arrow4.Add(new Point(220, 561));
            arrow4.Add(new Point(210, 527));
            e.Graphics.FillPolygon(Brushes.Black, arrow4.ToArray());
            e.Graphics.DrawLine(p2, 210, 561, 210, 625);



        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
        }
    }
}
