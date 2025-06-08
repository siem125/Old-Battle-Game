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
    public partial class Settings : Form
    {
        private SettingsValues settings; //will be singleton

        public Settings()
        {
            InitializeComponent();

            settings = SettingsValues.Instance;
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            //set the singleton settingvalues ip to the textbox values
            //settings.IP = tbIP.Text;
        }
    }
}
