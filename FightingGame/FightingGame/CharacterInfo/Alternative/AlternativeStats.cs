using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class AlternativeStats
    {
        //[JsonProperty("Attack")]
        public int attack { get; set; }
        public int defence { get; set; }
        public int magicAttack { get; set; }
        public int magicDefense { get; set; }
        public int speed { get; set; }
        public int evasiveness { get; set; }
        public int accuracy { get; set; }

        #region tcp functions

        public string getTCPFormat()
        {
            string format = "<altcharstats>";
            format += getTCPAttack() + getTCPDefence() + getTCPMagicAttack() + getTCPMagicDefence() + getTCPSpeed() + getTCPEvasiveness() + getTCPAccuracy();
            format += "</altcharstats>";
            return format;
        }

        public string getTCPAttack()
        {
            string format = "<attack>" + attack + "</attack>";
            return format;
        }

        public string getTCPDefence()
        {
            string format = "<defence>" + defence + "</defence>";
            return format;
        }

        public string getTCPMagicAttack()
        {
            string format = "<magicattack>" + magicAttack + "</magicattack>";
            return format;
        }

        public string getTCPMagicDefence()
        {
            string format = "<magicdefence>" + magicDefense + "</magicdefence>";
            return format;
        }

        public string getTCPSpeed()
        {
            string format = "<speed>" + speed + "</speed>";
            return format;
        }

        public string getTCPEvasiveness()
        {
            string format = "<evasiveness>" + evasiveness + "</evasiveness>";
            return format;
        }

        public string getTCPAccuracy()
        {
            string format = "<accuracy>" + accuracy + "</accuracy>";
            return format;
        }

        #endregion
    }
}
