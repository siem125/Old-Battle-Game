using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class AlternativeEffects
    {
        [JsonProperty("ailments", ItemConverterType = typeof(StringEnumConverter))]
        public List<Ailments> ailments { get; set; }
        public int buffHealth { get; set; }
        public int buffAttackLevel { get; set; }
        public int buffDefenceLevel { get; set; }
        public int buffMagicAttackLevel { get; set; }
        public int buffMagicDefenceLevel { get; set; }
        public int buffSpeed { get; set; }
        public int buffEvasiveness { get; set; }
        public int clonesAmount { get; set; }


        #region tcp functions

        public string getTCPFormat()
        {
            string format = "<altchareffects>";
            format += getTCPAilments() + getTCPBuffHealth() + getTCPBuffAttack() + getTCPBuffDefence() + getTCPBuffMagicAttack() + getTCPBuffMagicDefence() + getTCPBuffSpeed() + getTCPBuffEvasiveness() + getTCPClonesAmount();
            format += "</altchareffects>";
            return format;
        }

        private string getTCPAilments()
        {
            string format = "<ailments>";

            if (ailments != null)
            {
                foreach (Ailments ailment in ailments)
                {
                    format += "<option>" + ailment + "</option>";
                }
            }

            format += "</ailments>";

            return format;
        }

        private string getTCPBuffHealth()
        {
            string format = "<buffHealth>" + buffHealth + "</buffHealth>";
            return format;
        }

        private string getTCPBuffAttack()
        {
            string format = "<buffAttack>" + buffAttackLevel + "</buffAttack>";
            return format;
        }

        private string getTCPBuffDefence()
        {
            string format = "<buffDefence>" + buffDefenceLevel + "</buffDefence>";
            return format;
        }

        private string getTCPBuffMagicAttack()
        {
            string format = "<buffMagicAttack>" + buffMagicAttackLevel + "</buffMagicAttack>";
            return format;
        }

        private string getTCPBuffMagicDefence()
        {
            string format = "<buffMagicDefence>" + buffMagicDefenceLevel + "</buffMagicDefence>";
            return format;
        }

        private string getTCPBuffSpeed()
        {
            string format = "<buffSpeed>" + buffSpeed + "</buffSpeed>";
            return format;
        }

        private string getTCPBuffEvasiveness()
        {
            string format = "<buffEvasiveness>" + buffEvasiveness + "</buffEvasiveness>";
            return format;
        }

        private string getTCPClonesAmount()
        {
            string format = "<ClonesAmount>" + clonesAmount + "</ClonesAmount>";
            return format;
        }

        #endregion
    }
}
