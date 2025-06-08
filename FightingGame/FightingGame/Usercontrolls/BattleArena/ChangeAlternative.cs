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
    public partial class ChangeAlternative : UserControl
    {
        AlternativeCharacter ac;
        BattleArena arena;
        int index;

        public ChangeAlternative(AlternativeCharacter ac, BattleArena arena, int index)
        {
            InitializeComponent();

            this.ac = ac;
            this.arena = arena;
            this.index = index;

            //load all elements
            pbImage.Image = Image.FromFile(ac.getBaseAlternativePath() + "\\front.png");
            lblName.Text = ac.getInfo().uniqueName;
            lblMaxHealth.Text = ac.getInfo().maxHealth.ToString();

            //checks if can be clicked upon
            checkClickability();
        }

        private void checkClickability()
        {
            //checks health, if dead then don't get allowed to be clicked upon
            if (ac != null)
            {
                if (arena.getOwnCharacterHealth() <= 0)
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
            arena.changeOwnAlternativeUsesMove(index);
        }
    }
}
