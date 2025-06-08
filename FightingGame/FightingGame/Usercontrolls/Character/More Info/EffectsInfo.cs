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
    public partial class EffectsInfo : UserControl
    {
        private bool isEditable;
        private bool inEditState = false;

        public EffectsInfo(Effects effects, bool isEditable = false)
        {
            InitializeComponent();

            transParentTextboxes();
            this.isEditable = isEditable;
            loadEffects(effects);
        }

        private void transParentTextboxes()
        {
            tbBuffHealth.BackColor = this.BackColor;
            tbBuffAttack.BackColor = this.BackColor;
            tbBuffDefence.BackColor = this.BackColor;
            tbBuffMagicAttack.BackColor = this.BackColor;
            tbBuffMagicDefence.BackColor = this.BackColor;
            tbBuffSpeed.BackColor = this.BackColor;
            tbBuffEvasiveness.BackColor = this.BackColor;
            tbClonesAmount.BackColor = this.BackColor;
        }

        private void ennabler()
        {
            //ennable
            tbBuffHealth.Enabled = true;
            tbBuffAttack.Enabled = true;
            tbBuffDefence.Enabled = true;
            tbBuffMagicAttack.Enabled = true;
            tbBuffMagicDefence.Enabled = true;
            tbBuffSpeed.Enabled = true;
            tbBuffEvasiveness.Enabled = true;
            tbClonesAmount.Enabled = true;

            //set style
            tbBuffHealth.BorderStyle = BorderStyle.FixedSingle;
            tbBuffAttack.BorderStyle = BorderStyle.FixedSingle;
            tbBuffDefence.BorderStyle = BorderStyle.FixedSingle;
            tbBuffMagicAttack.BorderStyle = BorderStyle.FixedSingle;
            tbBuffMagicDefence.BorderStyle = BorderStyle.FixedSingle;
            tbBuffSpeed.BorderStyle = BorderStyle.FixedSingle;
            tbBuffEvasiveness.BorderStyle = BorderStyle.FixedSingle;
            tbClonesAmount.BorderStyle = BorderStyle.FixedSingle;
        }

        private void dissabler()
        {
            //dissable
            tbBuffHealth.Enabled = false;
            tbBuffAttack.Enabled = false;
            tbBuffDefence.Enabled = false;
            tbBuffMagicAttack.Enabled = false;
            tbBuffMagicDefence.Enabled = false;
            tbBuffSpeed.Enabled = false;
            tbBuffEvasiveness.Enabled = false;
            tbClonesAmount.Enabled = false;

            //remove style
            tbBuffHealth.BorderStyle = BorderStyle.None;
            tbBuffAttack.BorderStyle = BorderStyle.None;
            tbBuffDefence.BorderStyle = BorderStyle.None;
            tbBuffMagicAttack.BorderStyle = BorderStyle.None;
            tbBuffMagicDefence.BorderStyle = BorderStyle.None;
            tbBuffSpeed.BorderStyle = BorderStyle.None;
            tbBuffEvasiveness.BorderStyle = BorderStyle.None;
            tbClonesAmount.BorderStyle = BorderStyle.None;
        }

        private void loadEffects(Effects effects)
        {
            //load effects
            tbBuffHealth.Text = effects.buffHealth.ToString();
            tbBuffAttack.Text = effects.buffAttackLevel.ToString();
            tbBuffDefence.Text = effects.buffDefenceLevel.ToString();
            tbBuffMagicAttack.Text = effects.buffMagicAttackLevel.ToString();
            tbBuffMagicDefence.Text = effects.buffMagicDefenceLevel.ToString();
            tbBuffSpeed.Text = effects.buffSpeed.ToString();
            tbBuffEvasiveness.Text = effects.buffEvasiveness.ToString();
            tbClonesAmount.Text = effects.clonesAmount.ToString();

            loadAilments(effects.ailments);

            if (isEditable == true)
            {
                btnEdit.Enabled = true;
                btnEdit.Visible = true;

                btnEditAilments.Enabled = true;
                btnEditAilments.Visible = true;
            }
        }

        private void loadAilments(List<Ailments> ailments)
        {
            foreach (Ailments ailment in ailments)
            {
                //load in the panel
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (inEditState == true)
            {
                inEditState = false;
                ennabler();
            }
            else
            {
                inEditState = true;
                dissabler();
            }
        }
    }
}
