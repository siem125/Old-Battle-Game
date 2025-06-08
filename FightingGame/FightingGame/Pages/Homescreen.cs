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
    public partial class Homescreen : Form
    {
        public Homescreen()
        {
            InitializeComponent();
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            Functions.getMainForm(this).openChildForm(new Lobby());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Functions.getMainForm(this).openChildForm(new Settings());
        }

        private void btnSingleplayer_Click(object sender, EventArgs e)
        {
            Functions.getMainForm(this).openChildForm(new CharacterList());
        }
    }
}
