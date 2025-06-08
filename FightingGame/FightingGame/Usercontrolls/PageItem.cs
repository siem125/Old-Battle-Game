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
    public partial class PageItem : UserControl
    {
        private Form page;

        public PageItem(Form form)
        {
            InitializeComponent();

            this.page = form;

            switch (form.Name)
            {
                case "SettingsPage":
                    lblName.Text = "Settings";
                    break;

                default:
                    lblName.Text = form.Name;
                    break;
            }
        }

        private void Clicker(object sender, EventArgs e)
        {
            Form f2 = page;
            Functions.getMainForm(this).openChildForm(f2);
            Functions.getMainForm(this).clearNav(this); //clearing because once form on main was closed this page directs to closed form which doesn't work.
        }
    }
}
