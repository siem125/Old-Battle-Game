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
    public partial class CharacterItem : UserControl
    {
        Character character;
        Form parent;

        public CharacterItem(Character character, Form parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.character = character;
        }

        public void loadInfo()
        {

        }

        public void changeColor()
        {
            
        }

        private void Clicker(object sender, MouseEventArgs e)
        {
            //checks which mousebutton was pressed
            if (e.Button == MouseButtons.Left)
            {
                //check if parent form gets sended and is saved instead of being destroyed,
                //in that case create a new parent form from the parent form and give the new one along
                Functions.getMainForm(this).openChildForm(new FullInfoPage(character, parent, false));
            }
            else if (e.Button == MouseButtons.Right)
            {
                //add to temporary team
            }
        }
    }
}
