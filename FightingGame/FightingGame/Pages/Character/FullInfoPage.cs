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
    public partial class FullInfoPage : Form
    {
        private Form parent;
        private Character character;
        private bool isEditable;

        public FullInfoPage(Character character, Form parent, bool isEditable = false)
        {
            InitializeComponent();

            //save character and editable state(allows character editing, BEWARE!!!
            //WITH GREAT POWER COMES GREAT RESPONSIBILITY)
            this.character = character;
            this.parent = parent;
            this.isEditable = isEditable;

            if (isEditable == true)
            {
                btnSave.Visible = true;
                btnSave.Enabled = true;
            }

            //load the image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(399, 239);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            pictureBox.Name = "pbImage";
            pictureBox.Image = Image.FromFile(character.getBaseFrontImage());
            pnlContainer.Controls.Add(pictureBox);

            //load the information
            fillContainer();
        }

        public void fillContainer()
        {
            string name = "";

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    //set info
                    InfoInfo info = new InfoInfo(character.charInfo, isEditable);
                    name = "charInfo";

                    loopContainer(info, name);
                }
                else if (i == 1)
                {
                    //set stats
                    StatInfo stat = new StatInfo(character.baseStats, isEditable);
                    name = "charStat";

                    loopContainer(stat, name);
                }
                else if (i == 2)
                {
                    //set effects
                    EffectsInfo effect = new EffectsInfo(character.effects, isEditable);
                    name = "charEffect";

                    loopContainer(effect, name);
                }
                else if (i == 3)
                {

                    //set moves
                    MoveListInfo moves = new MoveListInfo(character.moves, isEditable);
                    name = "charMoves";

                    loopContainer(moves, name);
                }
                else if (i == 4)
                {
                    //set alternatives
                    AlternativesListInfo alternative = new AlternativesListInfo(character.getAlternatives(), isEditable);
                    name = "charAlternative";

                    loopContainer(alternative, name);
                }
            }
        }

        private void loopContainer(Control control, string name)
        {
            //panel default conditions
            Panel panel = new Panel();
            panel.Size = new Size(399, 239); //set size
            panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel.AutoScroll = true;

            panel.Name = name;
            panel.Controls.Add(control);

            //add the panel to the container
            pnlContainer.Controls.Add(panel);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //go back to the parent form
            Functions.getMainForm(this).openChildForm(parent);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //get all the info from all the tabs, and update the local saved character
            //for alternative characters and moves retrieve the list from those components
            //and set those as the characters lists

            //example(prob): character.moves = charMoves.controls[0].getList();
        }
    }
}
