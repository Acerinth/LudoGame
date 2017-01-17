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
        public int BrojNaKocki { set; get; }
        private int brojacKocka = 0;
        private Player playerOnMove;

        public FrmMain()
        {
            InitializeComponent();
            InitializePlayerTypeList();
            PlEngine.Initialize(p);
        }

        private void InitializePlayerTypeList()
        {
            PlayerTypeList.Add("Human");
            PlayerTypeList.Add("CPU");
            PlayerTypeList.Add("Not playing");
        }

        private void createBoardFieldList()
        {
            BoardField.BoardFieldList.Add(new BoardField(40, 0, 300, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(30, 300, 600, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(10, 300, 0, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(20, 600, 300, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(1, 0, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(2, 59, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(3, 118, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(4, 177, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(5, 241, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(39, 0, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(38, 59, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(37, 118, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(36, 177, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(35, 241, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(15, 359, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(16, 423, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(17, 482, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(18, 541, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(19, 600, 241, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(25, 359, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(24, 423, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(23, 482, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(22, 541, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(21, 600, 359, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(9, 241, 0, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(8, 241, 59, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(7, 241, 118, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(6, 241, 177, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(11, 359, 0, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(12, 359, 59, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(13, 359, 118, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(14, 359, 177, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(34, 241, 423, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(33, 241, 482, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(32, 241, 541, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(31, 241, 600, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(26, 359, 423, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(27, 359, 482, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(28, 359, 541, Color.White));
            BoardField.BoardFieldList.Add(new BoardField(29, 359, 600, Color.White));

            BoardField.BoardFieldList.Add(new BoardField(41, 64, 300, Color.Red));
            BoardField.BoardFieldList.Add(new BoardField(42, 123, 300, Color.Red));
            BoardField.BoardFieldList.Add(new BoardField(43, 182, 300, Color.Red));
            BoardField.BoardFieldList.Add(new BoardField(44, 241, 300, Color.Red));

            BoardField.BoardFieldList.Add(new BoardField(41, 300, 64, Color.Blue));
            BoardField.BoardFieldList.Add(new BoardField(42, 300, 123, Color.Blue));
            BoardField.BoardFieldList.Add(new BoardField(43, 300, 182, Color.Blue));
            BoardField.BoardFieldList.Add(new BoardField(44, 300, 241, Color.Blue));

            BoardField.BoardFieldList.Add(new BoardField(41, 359, 300, Color.Green));
            BoardField.BoardFieldList.Add(new BoardField(42, 418, 300, Color.Green));
            BoardField.BoardFieldList.Add(new BoardField(43, 477, 300, Color.Green));
            BoardField.BoardFieldList.Add(new BoardField(44, 536, 300, Color.Green));

            BoardField.BoardFieldList.Add(new BoardField(41, 300, 359, Color.Yellow));
            BoardField.BoardFieldList.Add(new BoardField(42, 300, 418, Color.Yellow));
            BoardField.BoardFieldList.Add(new BoardField(43, 300, 477, Color.Yellow));
            BoardField.BoardFieldList.Add(new BoardField(44, 300, 536, Color.Yellow));

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
                    t.LocationChanged += new EventHandler<EventArgs>(token_LocationChanged);
                }
            }
            FrmFirstPlay firstPlay = new FrmFirstPlay();
            firstPlay.ShowDialog();

            PlTerm term = PlTerm.PlVar();
            PlQuery q = new PlQuery("na_redu", new PlTermV(term));
            q.NextSolution();
            int idPlayer = int.Parse(term.ToString());
            q.Dispose();

            playerOnMove = Player.PlayerList.Find(x => x.ID == idPlayer);
            lblPlayerOnTheMove.Text = playerOnMove.Nickname;
            btnColor.BackColor = playerOnMove.Color;

            btnRollDice.Enabled = true;

            lblStatus.Text = "Roll the dice!";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PlEngine.IsInitialized)
            {
                PlEngine.PlCleanup();
            }
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
            panelControls.BackColor = Color.LightSteelBlue;
            btnRollDice.Enabled = false;
            createBoardFieldList();
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            
            BrojNaKocki = baciKockicu();        

            brojacKocka++;
            btnRollDice.Enabled = false;
            playerOnMove.NumberRolledDice = brojacKocka;
            playerOnMove.DiceNumber = BrojNaKocki;
            string boja = vratiBoju(playerOnMove.Color);

            if (PlQuery.PlCall("ima_zeton_na_ploci(" + playerOnMove.ID + ")")) // AKO IMA ŽETON NA PLOČI
            {
                if (BrojNaKocki == 6)
                {
                    if (PlQuery.PlCall("provjeri_zeton_start(" + boja + ")"))
                    {
                        foreach (Token t in playerOnMove.TokenList)
                        {
                            if (t.Status == 0)
                            {
                                DialogResult dr = MessageBox.Show("Imate neaktivnih žetona. Želite li izvaditi novog na ploču?", "Novi žeton", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    postaviZetonNaStart(t);
                                }

                                break;
                            }
                        }
                    }
                    else
                    {
                        PlTerm term = PlTerm.PlVar();
                        PlQuery q = new PlQuery("zeton", new PlTermV(term));
                        q.NextSolution();
                        int zetonID = int.Parse(term.ToString());
                        Token tudjiToken = null;
                        foreach (Player p in Player.PlayerList)
                        {
                            foreach (Token t in p.TokenList)
                            {
                                if (t.ID == zetonID && p != playerOnMove)
                                {
                                    tudjiToken = t;
                                    break;
                                }
                            }
                        }

                        if (tudjiToken != null)
                        {
                            foreach (Token t in playerOnMove.TokenList)
                            {
                                if (t.Status == 0)
                                {
                                    DialogResult dr = MessageBox.Show("Možete izvaditi novi žeton i pritom srušiti tuđeg. Vaš izbor?", "Novi žeton", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dr == DialogResult.Yes)
                                    {
                                        string b = vratiBoju(tudjiToken.Player.Color);
                                        if (PlQuery.PlCall("vrati_zeton_u_kucicu(" + zetonID + ", " + b + ")"))
                                        {
                                            tudjiToken.setHousesLocation(zetonID, tudjiToken.Player.Color);
                                            int boardFieldId = getStartBoardFieldId(playerOnMove.Color);
                                            //BoardField bf = BoardField.BoardFieldList.Find(x => x.ID == boardFieldId);
                                            //bf.removeTokenFromField();
                                        }
                                        postaviZetonNaStart(t);
                                        
                                    }
                                }
                            }
                        }
                    }
                                        
                }

                lblStatus.Text = "Klikni na žeton na ploči kako bi ga pomaknuo.";
                


            }
            else     //AKO NEMA ŽETON NA PLOČI
            {
                if (BrojNaKocki == 6)
                {
                    if (PlQuery.PlCall("provjeri_zeton_start(" + boja + ")"))
                    {
                        foreach (Token t in playerOnMove.TokenList)
                        {
                            if (t.Status == 0)
                            {
                                postaviZetonNaStart(t);
                                break;
                            }
                        }
                    }
                    else
                    {
                        PlTerm term = PlTerm.PlVar();
                        PlQuery q = new PlQuery("zeton", new PlTermV(term));
                        q.NextSolution();
                        int zetonID = int.Parse(term.ToString());
                        Token tudjiToken = null;
                        foreach (Player p in Player.PlayerList)
                        {
                            foreach (Token t in p.TokenList)
                            {
                                if (t.ID == zetonID)
                                {
                                    tudjiToken = t;
                                    break;
                                }
                            }
                        }
                        foreach (Token t in playerOnMove.TokenList)
                        {
                            if (t.Status == 0)
                            {
                                string b = vratiBoju(tudjiToken.Player.Color);
                                if (PlQuery.PlCall("vrati_zeton_u_kucicu(" + zetonID + ", " + b + ")"))
                                {
                                    tudjiToken.setHousesLocation(zetonID, tudjiToken.Player.Color);
                                }
                                postaviZetonNaStart(t);
                                break;
                            }
                        }
                    }
                    

                }

                if (brojacKocka < 3)
                {
                    btnRollDice.Enabled = true;
                    lblStatus.Text = "Bacao si kocku " + brojacKocka + " puta. Možeš bacati ponovno.";
                }
                else
                {
                    lblStatus.Text = "Bacao si kocku " + brojacKocka + " puta. Na redu je sljedeći igrač.";
                    playerOnMove = iduciIgrac(playerOnMove);
                    btnRollDice.Enabled = true;
                }



            }

            bool gotovo = true;
            foreach (Token t in playerOnMove.TokenList)
            {
                if (t.Status < 3)
                {
                    gotovo = false;
                }
            }
            if (gotovo)
            {
                MessageBox.Show("Igra je završila! Pobijedio/la je " + playerOnMove.Nickname + Environment.NewLine + "Čestitamo!", "Igra završena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRollDice.Enabled = false;
                lblStatus.Text = "Igra završena.";
            }



        }

        private Player iduciIgrac(Player trenutniIgrac)
        {
            PlQuery.PlCall("iduci_igrac(" + trenutniIgrac.ID + ")");
            
            PlTerm term = PlTerm.PlVar();
            PlQuery q = new PlQuery("na_redu", new PlTermV(term));
            q.NextSolution();
            int idPlayer = int.Parse(term.ToString());
            q.Dispose();

            Player noviIgrac = Player.PlayerList.Find(x => x.ID == idPlayer);
            lblPlayerOnTheMove.Text = noviIgrac.Nickname;
            btnColor.BackColor = noviIgrac.Color;
            brojacKocka = 0;
            noviIgrac.NumberRolledDice = 0;

            return noviIgrac;
        }

        private int baciKockicu()
        {
            PlQuery.PlCall("baci_kocku().");

            PlTerm t = PlTerm.PlVar();
            PlQuery q = new PlQuery("kocka", new PlTermV(t));
            q.NextSolution();
            lblDice.Text = t.ToString();
            int broj = int.Parse(t.ToString());
            q.Dispose();

            return broj;
        }

        private void postaviZetonNaStart(Token t)
        {
            PlQuery.PlCall("postavi_zeton_na_start(" + t.ID + "," + playerOnMove.ID + ").");
            BoardField bf;

            if (playerOnMove.Color == Color.Red)
            {
                bf = BoardField.BoardFieldList.Find(x => x.ID == 1);
                bf.addTokenToField(t);
                //t.Location = new Point(0, 241);
            }
            if (playerOnMove.Color == Color.Blue)
            {
                bf = BoardField.BoardFieldList.Find(x => x.ID == 11);
                bf.addTokenToField(t);
                //t.Location = new Point(359, 0);
            }
            if (playerOnMove.Color == Color.Green)
            {
                bf = BoardField.BoardFieldList.Find(x => x.ID == 21);
                bf.addTokenToField(t);
                //t.Location = new Point(600, 359);
            }
            if (playerOnMove.Color == Color.Yellow)
            {
                bf = BoardField.BoardFieldList.Find(x => x.ID == 31);
                bf.addTokenToField(t);
                //t.Location = new Point(241, 600);
            }
            t.Status = 1;
        }

        private void token_LocationChanged(object sender, EventArgs e)
        {
            if (playerOnMove.DiceNumber == 6)
            {
                if (playerOnMove.NumberRolledDice < 3)
                {
                    lblStatus.Text = "Bacao si kocku " + playerOnMove.NumberRolledDice + " puta. Možeš bacati ponovno.";
                    btnRollDice.Enabled = true;
                }
                else
                {
                    lblStatus.Text = "Bacao si kocku 3 puta. Sljedeći igrač je na redu.";
                    playerOnMove = iduciIgrac(playerOnMove);
                    btnRollDice.Enabled = true;
                }
            }
            else
            {
                lblStatus.Text = "Na redu je sljedeći igrač.";
                playerOnMove = iduciIgrac(playerOnMove);
                btnRollDice.Enabled = true;
            }
        }

        private string vratiBoju(Color c)
        {
            if (c == Color.Red) return "red";
            if (c == Color.Blue) return "blue";
            if (c == Color.Green) return "green";
            if (c == Color.Yellow) return "yellow";
            else return "";
        }

        private int getStartBoardFieldId(Color c)
        {
            if (c == Color.Red) return 1;
            if (c == Color.Blue) return 11;
            if (c == Color.Green) return 21;
            if (c == Color.Yellow) return 31;
            else return -1;
        }

    }
}
