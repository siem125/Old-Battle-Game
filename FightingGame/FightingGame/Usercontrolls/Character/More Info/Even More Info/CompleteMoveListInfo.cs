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
    public partial class CompleteMoveListInfo : Form
    {
        private MoveList moveList;
        private bool isEditable;
        private bool EditableState = false;

        public CompleteMoveListInfo(MoveList moveList, bool isEditable = false)
        {
            InitializeComponent();

            this.moveList = moveList;
            this.isEditable = isEditable;

            loadMoveSets();
        }

        private void loadMoveSets()
        {
            //
            int teller = 0;

            foreach (Move move in moveList.getMoves())
            {
                //load the data
                MoveInfoItems mii = new MoveInfoItems(move, EditableState);

                if (teller == 0)
                {
                    mii.Location = new Point(0, 0);
                }
                else
                {
                    mii.Location = new Point(0, teller * 82);
                }

                pnlMoveSet.Controls.Add(mii);

                teller++;
            }
        }

        private void dissabler()
        {
            try
            {
                tbName.Enabled = false;
                tbSeries.Enabled = false;
                tbToLearnFromLevel.Enabled = false;
                tbAmount.Enabled = true;
                cbElements.Enabled = false;

                //dgvMoves.Enabled = false;
                foreach (MoveInfoItems mii in pnlMoveSet.Controls)
                {
                    mii.changeEditState(false);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void enabler()
        {
            tbName.Enabled = true;
            tbSeries.Enabled = true;
            tbToLearnFromLevel.Enabled = true;
            tbAmount.Enabled = true;
            cbElements.Enabled = true;

            //dgvMoves.Enabled = true;
            foreach (MoveInfoItems mii in pnlMoveSet.Controls)
            {
                mii.changeEditState(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditableState == false)
            {
                EditableState = true;
                enabler();
            }
            else
            {
                EditableState = false;
                dissabler();
            }
        }
    }
}
