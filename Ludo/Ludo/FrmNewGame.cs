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
            txtP1.BackColor = Color.Blue;
            txtP2.BackColor = Color.Red;
            txtP3.BackColor = Color.Yellow;
            txtP4.BackColor = Color.Green;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {

            // dodati kreiranje igrača prema specifikacijama korisnika
            this.Close();
        }
    }
}
