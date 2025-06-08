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
    public partial class StatInfo : UserControl
    {
        private bool isEditable;
        private bool inEditState = false;

        public StatInfo(Stats stats, bool isEditable = false)
        {
            InitializeComponent();

            transParentTextboxes();
            this.isEditable = isEditable;
            loadStats(stats);
        }


        private void transParentTextboxes()
        {
            tbAttack.BackColor = this.BackColor;
            tbDefence.BackColor = this.BackColor;
            tbMagicAttack.BackColor = this.BackColor;
            tbMagicDefence.BackColor = this.BackColor;
            tbSpeed.BackColor = this.BackColor;
            tbEvasiveness.BackColor = this.BackColor;
            tbAccuracy.BackColor = this.BackColor;
        }

        private void ennabler()
        {
            //enable
            tbAttack.Enabled = true;
            tbDefence.Enabled = true;
            tbMagicAttack.Enabled = true;
            tbMagicDefence.Enabled = true;
            tbSpeed.Enabled = true;
            tbEvasiveness.Enabled = true;
            tbAccuracy.Enabled = true;

            //set style
            tbAttack.BorderStyle = BorderStyle.FixedSingle;
            tbDefence.BorderStyle = BorderStyle.FixedSingle;
            tbMagicAttack.BorderStyle = BorderStyle.FixedSingle;
            tbMagicDefence.BorderStyle = BorderStyle.FixedSingle;
            tbSpeed.BorderStyle = BorderStyle.FixedSingle;
            tbEvasiveness.BorderStyle = BorderStyle.FixedSingle;
            tbAccuracy.Enabled = true;
        }

        private void dissabler()
        {
            //dissable
            tbAttack.Enabled = false;
            tbDefence.Enabled = false;
            tbMagicAttack.Enabled = false;
            tbMagicDefence.Enabled = false;
            tbSpeed.Enabled = false;
            tbEvasiveness.Enabled = false;
            tbAccuracy.Enabled = false;

            //remove style
            tbAttack.BorderStyle = BorderStyle.None;
            tbDefence.BorderStyle = BorderStyle.None;
            tbMagicAttack.BorderStyle = BorderStyle.None;
            tbMagicDefence.BorderStyle = BorderStyle.None;
            tbSpeed.BorderStyle = BorderStyle.None;
            tbEvasiveness.BorderStyle = BorderStyle.None;
            tbAccuracy.BorderStyle = BorderStyle.None;
        }

        private void loadStats(Stats stats)
        {
            //load info
            tbAttack.Text = stats.attack.ToString();
            tbDefence.Text = stats.defence.ToString();
            tbMagicAttack.Text = stats.magicAttack.ToString();
            tbMagicDefence.Text = stats.magicDefense.ToString();
            tbSpeed.Text = stats.speed.ToString();
            tbEvasiveness.Text = stats.evasiveness.ToString();
            tbAccuracy.Text = stats.accuracy.ToString();

            //check if is editable
            if (isEditable == true)
            {
                btnEdit.Visible = true;
                btnEdit.Enabled = true;
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
