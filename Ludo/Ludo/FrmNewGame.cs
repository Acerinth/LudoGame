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
    public partial class FrmNewGame : Form
    {
        private List<ComboBox> ComboBoxList = new List<ComboBox>();

        public FrmNewGame()
        {
            InitializeComponent();
            CreateBoxes();
            SetColors();
            if (!PlEngine.IsInitialized)
            {
                PlEngine.Initialize(FrmMain.p);
            }
        }

        private void CreateBoxes()
        {
            cBox1.DataSource = FrmMain.PlayerTypeList;
            cBox1.SelectedIndex = 0;
            ComboBoxList.Add(cBox1);

            cBox2.BindingContext = new BindingContext();
            cBox2.DataSource = FrmMain.PlayerTypeList;
            cBox2.SelectedIndex = 0;
            ComboBoxList.Add(cBox2);

            cBox3.BindingContext = new BindingContext();
            cBox3.DataSource = FrmMain.PlayerTypeList;
            cBox3.SelectedIndex = 2;
            ComboBoxList.Add(cBox3);

            cBox4.BindingContext = new BindingContext();
            cBox4.DataSource = FrmMain.PlayerTypeList;
            cBox4.SelectedIndex = 2;
            ComboBoxList.Add(cBox4);
        }

        private void SetColors()
        {
            txtP1.BackColor = Color.Red;
            txtP2.BackColor = Color.Blue;
            txtP3.BackColor = Color.Green;
            txtP4.BackColor = Color.Yellow;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (cBox1.SelectedIndex < 2)
            {
                Player p = new Player(1, txtNick1.Text, Color.Red, cBox1.SelectedIndex);
                Player.PlayerList.Add(p);
                
                bool jelValja = PlQuery.PlCall("spremi_igraca(1,'" + txtNick1.Text + "',red," + cBox1.SelectedIndex + ")");
                
                
            }

            // dodati kreiranje igrača prema specifikacijama korisnika
            this.Close();
        }

        private void cBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox1.SelectedIndex==2)
            {
                txtNick1.Enabled = false;
            }
            else
            {
                txtNick1.Enabled = true;
            }
        }

        private void cBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox2.SelectedIndex == 2)
            {
                txtNick2.Enabled = false;
            }
            else
            {
                txtNick2.Enabled = true;
            }
        }

        private void cBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox3.SelectedIndex == 2)
            {
                txtNick3.Enabled = false;
            }
            else
            {
                txtNick3.Enabled = true;
            }
        }

        private void cBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox4.SelectedIndex == 2)
            {
                txtNick4.Enabled = false;
            }
            else
            {
                txtNick4.Enabled = true;
            }
        }
    }
}
