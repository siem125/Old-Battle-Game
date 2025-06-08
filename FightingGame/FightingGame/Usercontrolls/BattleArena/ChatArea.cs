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
    public partial class ChatArea : UserControl
    {
        List<Control> chatList = new List<Control>();
        List<Control> turnList = new List<Control>();

        private bool isShowingTurns = true;

        BattleArena arena;

        public ChatArea(BattleArena ba, bool onlyTurns = true)
        {
            InitializeComponent();

            this.arena = ba;

            if (onlyTurns == true)
            {
                //playing against bot means no need for chat
                pnlOptions.Visible = false;
                txtMessage.Visible = false;
            }
        }

        public void addTurn(string text) //TurnState ts
        {
            //if (isShowingTurns != true)
            //{
            //    loadTurns();

            //    isShowingTurns = true;
            //}

            Label label = getLabel(turnList.Count, text);

            //add control to the list
            turnList.Add(label);

            if (isShowingTurns == true)
            {
                pnlChat.Controls.Add(label);
            }
            //Console.WriteLine("Control amount of panel is: " + pnlChat.Controls.Count);
        }

        public void addSideTurn(string text) //TurnState ts
        {
            //if (isShowingTurns != true)
            //{
            //    loadTurns();

            //    isShowingTurns = true;
            //}

            Label label = getSideLabel(turnList.Count, text);

            //add control to the list
            turnList.Add(label);

            if (isShowingTurns == true)
            {
                pnlChat.Controls.Add(label);
            }
            //Console.WriteLine("Control amount of panel is: " + pnlChat.Controls.Count);
        }

        /// <summary>
        /// adds customized turnheader control
        /// </summary>
        /// <param name="turnNumber"></param>
        public void addTurnHeader(int turnNumber)
        {
            Panel panel = getTurnHead(turnList.Count, turnNumber);
            turnList.Add(panel);

            if (isShowingTurns == true)
            {
                pnlChat.Controls.Add(panel);
            }
        }

        public void addChatMessage(string text)
        {
            Label label = getLabel(chatList.Count, text);

            //add control to the list
            chatList.Add(label);

            if (isShowingTurns == false)
            {
                pnlChat.Controls.Add(label);
            }
        }

        private void btnTurns_Click(object sender, EventArgs e)
        {
            isShowingTurns = true;
            loadTurns();
        }

        private void loadTurns()
        {
            //load turns
            pnlChat.Controls.Clear();
            pnlChat.Refresh();

            foreach (Control control in turnList)
            {
                //make labels
                //Label label = new Label();
                //label.Text = text;
                control.Visible = true;

                pnlChat.Controls.Add(control);
            }
        }

        private void loadChat()
        {
            //load turns
            pnlChat.Controls.Clear();

            foreach (Control control in chatList)
            {
                pnlChat.Controls.Add(control);
            }
        }

        private Label getLabel(int controlNumber, string text)
        {
            Label label = new Label();
            //label.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            label.Text = text;
            label.Size = new Size(this.Width, 20);
            label.Location = new Point(0 + pnlChat.AutoScrollPosition.X, 0 + (20 * controlNumber) + pnlChat.AutoScrollPosition.Y);

            return label;
        }

        private Label getSideLabel(int controlNumber, string text)
        {
            Label label = new Label();
            //label.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            label.Text = text;
            label.Size = new Size(this.Width, 20);
            label.Location = new Point(20 + pnlChat.AutoScrollPosition.X, 0 + (20 * controlNumber) + pnlChat.AutoScrollPosition.Y);

            return label;
        }

        private Panel getTurnHead(int controlNumber, int turn)
        {
            //set panel configs
            Panel panel = new Panel();
            panel.BackColor = Color.Gray;
            panel.Size = new Size(this.Width, 20);

            //controlNumber was pnlChat.Controls.Count
            //but because of 2 separate chats controls were instable henceForth giving controls of
            //specified chat so the count count will be for that specific chat
            panel.Location = new Point(0 + pnlChat.AutoScrollPosition.X, 0 + (20 * controlNumber) + pnlChat.AutoScrollPosition.Y); 

            //set label config and add it
            Label label = new Label();
            label.Text = "Turn " + turn;
            label.Size = new Size(this.Width, 20);

            panel.Controls.Add(label);

            return panel;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            //load chat
            isShowingTurns = false;
            loadChat();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //send message
                string message = "Me: " + txtMessage.Text;
                addChatMessage(message);

                //clear the textbox
                txtMessage.Text = string.Empty;
            }
        }
    }
}
