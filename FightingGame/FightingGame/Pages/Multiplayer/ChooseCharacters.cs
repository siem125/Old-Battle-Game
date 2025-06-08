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
    public partial class ChooseCharacters : Form
    {
        List<List<Character>> teams; //team list

        public ChooseCharacters()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the list from the file where teams are stored, in this file the character paths from ownedCharacter folder are stored
        /// </summary>
        public void loadTeams()
        {

        }

        public void loadCharacters()
        {
            //in this function the characters are loaded based on the filters and or all them
        }
    }
}
