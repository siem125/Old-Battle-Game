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
    public partial class ChangeCharacter : UserControl
    {
        Character character;
        BattleArena arena;
        int index;
        public ChangeCharacter(BattleArena ba, Character character, int index)
        {
            InitializeComponent();

            this.index = index;
            this.character = character;
            this.arena = ba;

            //load all elements
            pbImage.Image = Image.FromFile(character.getBaseCharacterPath() + "front.png");
            lblName.Text = character.getName();
            lblCurrentHealth.Text = character.getHealth().ToString();
            lblMaxHealth.Text = character.getMaxHealth().ToString();

            //checks if can be clicked upon
            checkClickability();
        }

        private void checkClickability()
        {
            //checks health, if dead then don't get allowed to be clicked upon
            if (character != null)
            {
                if (character.getHealth() <= 0)
                {
                    //dissable all
                    this.Enabled = false;
                }
                else
                {
                    //enable all
                    this.Enabled = true;
                }
            }
        }

        private void Clicker(object sender, EventArgs e)
        {
            //change event with index number of the party
            //MessageBox.Show("PartyNumber: " + index);
            arena.changeOwnCharacterUsesMove(index);
        }
    }
}
