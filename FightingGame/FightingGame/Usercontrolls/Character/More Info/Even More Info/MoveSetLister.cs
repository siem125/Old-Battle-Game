using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightingGame.Usercontrolls.Character.More_Info.Even_More_Info
{
    public partial class MoveSetLister : UserControl
    {
        private bool isEditing;

        public MoveSetLister(Move move, bool isEditing = false)
        {
            InitializeComponent();

            this.isEditing = isEditing;

            pnlContainer.Controls.Add(new MoveInfoItems(move, isEditing));
        }

        public void changeEditState()
        {
            try
            {
                if (isEditing == false)
                {
                    isEditing = true;
                    pnlContainer.Controls[0].Enabled = false;
                }
                else
                {
                    isEditing = false;
                    pnlContainer.Controls[0].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Move getMoveBack()
        {
            MoveSetLister lister = (MoveSetLister)pnlContainer.Controls[0];
            return lister.getMoveBack();
        }
    }
}
