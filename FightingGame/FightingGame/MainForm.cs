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
    public enum screenMode
    {
        Maximum,
        Normal
    }

    public partial class MainForm : Form
    {
        private screenMode sm { get; set; }
        public MainForm()
        {
            InitializeComponent();

            sm = screenMode.Normal;
            loadPage();
        }

        private void loadPage()
        {
            //load navigation
            loadNav();

            //load the page
            openChildForm(new Startscreen());
        }

        private void loadNav()
        {
            List<PageItem> pagers = new List<PageItem>();
            pagers.Add(new PageItem(new Form1()));
            pagers.Add(new PageItem(new Homescreen()));
            //pagers.Add(new PageItem(new SettingsPage()));
            //pagers.Add(new PageItem(new MyList()));
            //pagers.Add(new PageItem(new AddSeries()));

            //add these forms to the navigation panel
            foreach (PageItem pi in pagers)
            {
                if (!flpNav.Controls.Contains(pi))
                {
                    //add these forms to the navigation panel
                    flpNav.Controls.Add(pi);
                }
            }
        }

        public void clearNav(PageItem pi)
        {
            //TODO only reload the specific pageitem instead of them all
            flpNav.Controls.Clear();
            loadNav();
        }

        public screenMode changeFormState()
        {
            if (sm == screenMode.Normal)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.sm = screenMode.Maximum;
            }
            else if (sm == screenMode.Maximum)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.sm = screenMode.Normal;
            }

            return this.sm;
        }

        public screenMode getScreenMode()
        {
            return this.sm;
        }

        public void closeNav()
        {
            flpNav.Enabled = false;
            flpNav.Visible = false;
        }

        public void openNav()
        {
            //show nav
            flpNav.Enabled = true;
            flpNav.Visible = true;

            //load nav options
        }

        //tracker of active form in the panel
        private Form activeform = null;
        public void openChildForm(Form childForm)
        {
            try
            {
                //checks if there is a form active, if so close it and then set it to the new one
                if (activeform != null)
                {
                    activeform.Close();
                    activeform = null;
                }
                activeform = childForm;

                //declares that the new form isn't the main form
                activeform.TopLevel = false;

                //styling childform definition
                activeform.FormBorderStyle = FormBorderStyle.None;
                activeform.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                activeform.Dock = DockStyle.Fill;

                //adding childform to the panel, then bringing it to the front and show it in the panel
                pnlChild.Controls.Add(activeform);
                pnlChild.Tag = activeform;

                //showing the form as the newest element on top of the panel insted of behind it
                activeform.BringToFront();
                activeform.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
