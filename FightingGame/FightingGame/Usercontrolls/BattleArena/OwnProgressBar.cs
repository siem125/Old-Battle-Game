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
    public partial class OwnProgressBar : UserControl
    {
        float maxValue;

        public OwnProgressBar(float maxValue, float currentValue)
        {
            InitializeComponent();

            this.maxValue = maxValue;

            changePB(currentValue);
        }

        public void changePB(float currentValue)
        {
            if (currentValue <= maxValue)
            {
                float progress = (currentValue / maxValue) * 100; //percentage formula
                int percentage = (int)progress;//percentage int
                float percWidth = (float)this.Width / (float)100; //1 percent of width
                float formula = percWidth * percentage;
                int newWidth = (int)formula; //1 percent times percentage
                pbProgress.Width = newWidth;
            }
            else
            {
                pbProgress.Width = 0;
            }

            this.Refresh();
        }
    }
}
