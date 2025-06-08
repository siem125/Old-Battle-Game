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
    public partial class AlternativesListInfo : UserControl
    {
        private bool isEditable;
        private bool inEditState = false;

        public AlternativesListInfo(List<AlternativeCharacter> alternatives, bool isEditable)
        {
            InitializeComponent();

            this.isEditable = isEditable;

            if (isEditable == true)
            {
                btnEdit.Visible = true;
                btnEdit.Enabled = true;
            }

            loadAlternatives(alternatives);
        }

        private void loadAlternatives(List<AlternativeCharacter> alternatives)
        {
            foreach (AlternativeCharacter ac in alternatives)
            {
                AltCharInfoItem acii = new AltCharInfoItem(ac);
                pnlAlternatives.Controls.Add(acii);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
