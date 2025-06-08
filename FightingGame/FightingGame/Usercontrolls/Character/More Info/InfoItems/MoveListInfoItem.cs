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
    public partial class MoveListInfoItem : UserControl
    {
        private MoveList move;

        public MoveListInfoItem(MoveList move)
        {
            InitializeComponent();

            this.move = move;
            loadInfo();
        }

        private void loadInfo()
        {
            lblName.Text = move.getName();
            lblPP.Text = move.getCurrentAmount().ToString();
            lblPPMax.Text = move.getMaxAmount().ToString();

            this.BackColor = Functions.getColorFromElementType(move.getElement());
        }

        private void Clicker(object sender, EventArgs e)
        {
            Functions.getMainForm(this).openChildForm(new CompleteMoveListInfo(move));
        }
    }
}
