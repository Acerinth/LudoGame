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
    public partial class FrmFirstPlay : Form
    {
        public FrmFirstPlay()
        {
            InitializeComponent();
        }

        private void FrmFirstPlay_Load(object sender, EventArgs e)
        {
            createComboBoxItems();
        }

        private void createComboBoxItems()
        {
            cBoxPlayers.DataSource = Player.PlayerList;
            cBoxPlayers.ValueMember = "ID";
            cBoxPlayers.DisplayMember = "Nickname";
        }

        private void rBPlayer_CheckedChanged(object sender, EventArgs e)
        {
            cBoxPlayers.Enabled = true;
        }

        private void rBRandom_CheckedChanged(object sender, EventArgs e)
        {
            cBoxPlayers.Enabled = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (rBPlayer.Checked == true)
            {
                int chosenPlayer = (int)cBoxPlayers.SelectedValue;
                //upisat u prolog ko je na redu

            }
            else if (rBRandom.Checked == true)
            {
                //pozvat funkciju iz prologa
            }
            this.Close();
        }
    }
}
