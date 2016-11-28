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
            //nacrtat zeton
        }
    }
}
