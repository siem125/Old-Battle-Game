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
    public partial class CharacterList : Form
    {
        List<Character> characters;

        public CharacterList()
        {
            InitializeComponent();

            characters = Functions.getAllOwnedCharacters();

            loadCharacters();
        }

        private void loadCharacters()
        {
            //load all characters into characteritems
            if (characters.Count() > 0)
            {
                foreach (Character character in characters)
                {
                    CharacterItem ci = new CharacterItem(character, this);
                    pnlCharacters.Controls.Add(ci);
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            //search the list
        }
    }
}
