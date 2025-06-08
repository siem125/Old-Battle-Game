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
    public partial class TypeBox : UserControl
    {
        public TypeBox(string name, Color col)
        {
            InitializeComponent();

            lblName.Text = name;
            this.BackColor = col;
        }
    }
}
