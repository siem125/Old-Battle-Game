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
    public partial class MoveInfoItems : UserControl
    {
        private Move move;
        private bool isEditing;

        public MoveInfoItems(Move move = null, bool isEditing = false)
        {
            InitializeComponent();

            this.move = move;
            this.isEditing = isEditing;

            //loads the available options
            loadOptions();

            //loads info from move if move exists else create new move from defaults
            chooseOptionsFromMove();

            //checks if editor mode is on
            checkEditState();
        }

        private void chooseOptionsFromMove()
        {
            if (move != null)
            {
                //load all options using the move information
                loadInfoFromMove();
            }
            else
            {
                //do nothing, this way the defaults are loaded
                //maybe create new move based on the default values
                MoveType mt = (MoveType)Enum.Parse(typeof(MoveType), cbType.Text);
                TargetType tt = (TargetType)Enum.Parse(typeof(TargetType), cbTarget.Text);
                Elements element = (Elements)Enum.Parse(typeof(Elements), cbElement.Text);
                int turns = Convert.ToInt32(tbTurns.Text);
                int amount = Convert.ToInt32(tbAmount.Text);
                AnimationBoxes box = (AnimationBoxes)Enum.Parse(typeof(AnimationBoxes), cbAnimationBox.Text);

                this.move = new Move(mt, tt, element, tbNumber.Text, cbChosen.Text, cbBuildUp.Text, turns, amount, tbSeries.Text, cbAnimationName.Text, box);
            }
        }

        private void loadInfoFromMove()
        {
            //load options from move and select/update the data using the values stored in move
            //set Type
            cbType.Text = move.getType().ToString();

            //set Target
            loadTargetOptions();
            cbTarget.Text = move.getTarget().ToString();

            //set element
            cbElement.Text = move.getElement().ToString();

            //set number
            tbNumber.Text = move.getNumber().ToString();

            //set chosen
            loadChosenOptions();
            cbChosen.Text = move.getChosen().ToString();

            //set buildup
            cbBuildUp.Checked = Convert.ToBoolean(move.getBuidUpBoolean());

            //set turns
            tbTurns.Text = move.getTurns().ToString();

            //set amount
            tbAmount.Text = move.getAmount().ToString();

            //TODO
            //first load series, then search the folder for all the files and display those
            //then lastly load selected animationbox
        }

        private void loadOptions()
        {
            //load type
            loadTypeOptions();
            cbType.SelectedIndex = 0;

            //load target
            loadTargetOptions();
            cbTarget.SelectedIndex = 0;

            //load elements
            loadElementOptions();
            cbElement.SelectedIndex = 0;

            //set default number
            tbNumber.Text = "null";

            //load chosen
            loadChosenOptions();
            cbChosen.SelectedIndex = 0;

            //load buildup
            cbBuildUp.Checked = false;

            //load turns
            tbTurns.Text = "0";

            //load amount
            tbAmount.Text = "1";

            //load series default value
            tbSeries.Text = "none";

            //load animation name + extentions from the series file if exists
            loadAnimationNames();
            cbAnimationName.SelectedIndex = 0;

            //load animation boxes
            loadAnimationBoxes();
            cbAnimationBox.SelectedIndex = 0;
        }

        #region loadDefaults

        private void loadTypeOptions()
        {
            foreach (MoveType mt in Enum.GetValues(typeof(MoveType)))
            {
                cbType.Items.Add(mt);
            }  
        }

        private void loadTargetOptions()
        {
            //clear checkbox
            cbTarget.Items.Clear();

            //add standard
            cbTarget.Items.Add(TargetType.none);

            //check the type and give corresponding targets
            MoveType type = (MoveType)Enum.Parse(typeof(MoveType), cbType.Text);
            
            //TODO add the other target types
            if (type == MoveType.give || type == MoveType.take)
            {
                cbTarget.Items.Add(TargetType.single);
                cbTarget.Items.Add(TargetType.self);
                cbTarget.Items.Add(TargetType.all);
            }
            else if (type == MoveType.buff || type == MoveType.debuff)
            {
                cbTarget.Items.Add(TargetType.single);
                cbTarget.Items.Add(TargetType.self);
                cbTarget.Items.Add(TargetType.all);
            }
            else if (type == MoveType.attack || type == MoveType.defence || type == MoveType.magicattack | type == MoveType.magicdefence || type == MoveType.heal)
            {
                cbTarget.Items.Add(TargetType.single);
                cbTarget.Items.Add(TargetType.self);
                cbTarget.Items.Add(TargetType.all);
            }
        }

        private void loadElementOptions()
        {
            foreach (Elements element in Enum.GetValues(typeof(Elements)))
            {
                cbElement.Items.Add(element);
            }
        }

        private void loadChosenOptions()
        {
            //clear the items
            cbChosen.Items.Clear();

            //add all the options
            cbChosen.Items.Add("null");

            //to check the type to give correct options
            MoveType type = (MoveType)Enum.Parse(typeof(MoveType), cbType.Text);

            //detect options to add
            if (type == MoveType.buff || type == MoveType.debuff)
            {
                //load stats
                cbChosen.Items.Add("attack");
                cbChosen.Items.Add("defence");
                cbChosen.Items.Add("magicAttack");
                cbChosen.Items.Add("magicDefence");
                cbChosen.Items.Add("speed");
                cbChosen.Items.Add("evasiveness");
                cbChosen.Items.Add("accuracy");

            }
            else if (type == MoveType.give || type == MoveType.take)
            {
                //load ailments
                foreach (Ailments ailment in Enum.GetValues(typeof(Ailments)))
                {
                    cbChosen.Items.Add(ailment);
                }
            }
            else if (type == MoveType.weather)
            {
                //load weather effects
                //TODO
            }
        }

        private void loadAnimationNames()
        {
            //TODO

            //load default
            cbAnimationName.Items.Add("none");

            //load all the animations saved from series path using the series name and the gamefolder
            //like: gamefolderpath + tbSeries.text + "\\Animations\\";
            //then load all the files saved in this location and loop through those to load
            //all the files in cbAnimationName
        }

        private void loadAnimationBoxes()
        {
            foreach (AnimationBoxes box in Enum.GetValues(typeof(AnimationBoxes)))
            {
                cbAnimationBox.Items.Add(box);
            }
        }

        #endregion

        public Move getMoveBack()
        {
            //check correctness of new information compared to move saved info
            if (!move.GetType().Equals((MoveType)Enum.Parse(typeof(MoveType), cbType.Text)))
            {
                //if yes use info and edit the move then give move back

            }

            return move;
        }

        public void changeEditState(bool newState)
        {
            this.isEditing = newState;

            checkEditState();
        }

        public void checkEditState()
        {
            if (this.isEditing == true)
            {
                enabler();
            }
            else
            {
                dissabler();
            }
        }

        private void enabler()
        {
            cbType.Enabled = true;
            cbTarget.Enabled = true;
            cbElement.Enabled = true;
            tbNumber.Enabled = true;
            cbChosen.Enabled = true;
            cbBuildUp.Enabled = true;
            tbTurns.Enabled = true;
            tbAmount.Enabled = true;

            //TODO
            //animation readings
            //tbSeries.Enabled = true;
            //cbAnimationName.Enabled = true;
            //cbAnimationBox.Enabled = true;
        }

        private void dissabler()
        {
            cbType.Enabled = false;
            cbTarget.Enabled = false;
            cbElement.Enabled = false;
            tbNumber.Enabled = false;
            cbChosen.Enabled = false;
            cbBuildUp.Enabled = false;
            tbTurns.Enabled = false;
            tbAmount.Enabled = false;

            //animation readings
            tbSeries.Enabled = false;
            cbAnimationName.Enabled = false;
            cbAnimationBox.Enabled = false;
        }
    }
}
