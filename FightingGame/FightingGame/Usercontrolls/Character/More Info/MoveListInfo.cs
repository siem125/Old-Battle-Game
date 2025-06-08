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
    public partial class MoveListInfo : UserControl
    {
        private bool isEditable;
        private bool inEditState = false;

        public MoveListInfo(Moves moves, bool isEditable = false)
        {
            InitializeComponent();

            this.isEditable = isEditable;
            
            if (isEditable == true)
            {
                btnEdit.Visible = true;
                btnEdit.Enabled = true;
            }

            loadMoves(moves);
        }

        private void loadMoves(Moves moves)
        {
            foreach (MoveList move in moves.moves)
            {
                //movelist is list of moves so movelist contrains one or move move(s)
                MoveListInfoItem mlii = new MoveListInfoItem(move);
                pnlMoves.Controls.Add(mlii);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //edits the moveset of the saved character
        }
    }
}
