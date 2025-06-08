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
    public partial class InfoInfo : UserControl
    {
        private bool isEditable;
        private bool inEditState = false;

        public InfoInfo(Info info, bool isEditable = false)
        {
            InitializeComponent();

            //make tb transparent, save isEditable and load the info
            transParentTextboxes();
            this.isEditable = isEditable;
            loadInfo(info);
        }

        private void transParentTextboxes()
        {
            tbName.BackColor = this.BackColor;
            tbLevel.BackColor = this.BackColor;
            tbEvolutionLvl.BackColor = this.BackColor;
            tbSeries.BackColor = this.BackColor;
            tbOfficialName.BackColor = this.BackColor;
            tbHealth.BackColor = this.BackColor;
        }

        private void loadInfo(Info info)
        {
            //use the info class to load the info and show it in here
            tbName.Text = info.name;
            tbLevel.Text = info.level.ToString();
            tbEvolutionLvl.Text = info.evolutionLevel.ToString();
            tbHealth.Text = info.maxHealth.ToString();
            tbSeries.Text = info.series;
            tbOfficialName.Text = info.uniqueName;

            loadElements(info.elements);

            if (isEditable == true)
            {
                //step 1 enable edit functions
                btnEdit.Enabled = true;
                btnEdit.Visible = true;

                //step 2 load the elements editor button
                btnEditElements.Enabled = true;
                btnEditElements.Visible = true;
            }
        }

        private void loadElements(List<Elements> elements)
        {
            foreach (Elements element in elements)
            {
                //find element control

                //add it to the pnl
            }
        }

        private bool getEditStatus()
        {
            return isEditable;
        }

        private void ennabler()
        {
            //enable
            tbName.Enabled = true;
            tbLevel.Enabled = true;
            tbEvolutionLvl.Enabled = true;
            tbSeries.Enabled = true;
            tbOfficialName.Enabled = true;
            tbHealth.Enabled = true;

            //set style
            tbName.BorderStyle = BorderStyle.FixedSingle;
            tbLevel.BorderStyle = BorderStyle.FixedSingle;
            tbEvolutionLvl.BorderStyle = BorderStyle.FixedSingle;
            tbSeries.BorderStyle = BorderStyle.FixedSingle;
            tbOfficialName.BorderStyle = BorderStyle.FixedSingle;
            tbHealth.BorderStyle = BorderStyle.FixedSingle;
        }

        private void dissabler()
        {
            //dissable
            tbName.Enabled = false;
            tbLevel.Enabled = false;
            tbEvolutionLvl.Enabled = false;
            tbSeries.Enabled = false;
            tbOfficialName.Enabled = false;
            tbHealth.Enabled = false;

            //remove style
            tbName.BorderStyle = BorderStyle.None;
            tbLevel.BorderStyle = BorderStyle.None;
            tbEvolutionLvl.BorderStyle = BorderStyle.None;
            tbSeries.BorderStyle = BorderStyle.None;
            tbOfficialName.BorderStyle = BorderStyle.None;
            tbHealth.BorderStyle = BorderStyle.None;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (inEditState == true)
            {
                inEditState = false;
                ennabler();
            }
            else
            {
                inEditState = true;
                dissabler();
            }
        }

        private void btnEditElements_Click(object sender, EventArgs e)
        {
            //load button for showdialog screen where elements can be added, edited or removed using
            //a customized form with panel and choice elements for the elements

        }
    }
}
