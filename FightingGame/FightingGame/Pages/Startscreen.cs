using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightingGame
{
    public partial class Startscreen : Form
    {
        public Startscreen()
        {
            InitializeComponent();
        }

        private void btnHomescreen_Click(object sender, EventArgs e)
        {
            Functions.getMainForm(this).openChildForm(new Homescreen());
        }
    }
}
