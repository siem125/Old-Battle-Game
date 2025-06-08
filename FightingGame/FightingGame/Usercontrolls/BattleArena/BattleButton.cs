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
    public partial class BattleButton : UserControl
    {
        private MoveList move;
        private int currentAmount;
        private  BattleArena arena;

        public BattleButton(BattleArena ba, MoveList move)
        {
            InitializeComponent();

            //save variable
            this.move = move;

            //
            lblCurrentAmount.Text = move.getCurrentAmount().ToString();
            currentAmount = move.getCurrentAmount();
            lblMaxAmount.Text = move.getMaxAmount().ToString();
            lblName.Text = move.getName();
            arena = ba;

            //sets the background color to movelist element type
            getTypeBackColor();
        }

        private void getTypeBackColor()
        {
            switch (move.getElement())
            {
                case Elements.Normal:
                    //
                    this.BackColor = Color.Gray;
                    break;

                case Elements.Fighting:
                    //
                    this.BackColor = Color.Brown;
                    break;

                default:
                    //
                    this.BackColor = Color.White;
                    break;
            }
        }

        public void dissabler()
        {
            this.Enabled = false;
            lblName.Enabled = false;
            lblCurrentAmount.Enabled = false;
            lblMaxAmount.Enabled = false;
        }

        public void enabler()
        {
            if (currentAmount > 0)
            {
                this.Enabled = true;
                lblName.Enabled = true;
                lblCurrentAmount.Enabled = true;
                lblMaxAmount.Enabled = true;
            }
        }

        private void Clicker(object sender, EventArgs e)
        {
            //minus amount
            //currentAmount--;
            move.playedOnce();

            //do calculation for doesHit bool
            bool doesHit = false;

            arena.setownMove(move, doesHit);

            //update info
            this.lblCurrentAmount.Text = move.getCurrentAmount().ToString();

            //dissable all buttons until next turn
            //(event within the battlearena that loops through all battlebuttons and calls dissabler)
            arena.dissabler();
        }
    }
}
