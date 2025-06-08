using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class Effects
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
        public int clonesAmount { get; set; } //amount of times attack will be repeated((finalAttackValue * clones) + (1 * finalAttackValue))

        //public Effects(List<Ailments> ailments, int buffHealth, int buffAttackLevel, int buffDefenceLevel, int buffMagicAttackLevel, int buffMagicDefenceLevel, int buffSpeed, int buffEvasiveness, int clonesAmount)
        //{
        //    if (ailments != null)
        //    {
        //        this.ailments = ailments;
        //    }
        //    else
        //    {
        //        this.ailments = new List<Ailments>();
        //    }

        //    this.buffHealth = buffHealth;
        //    this.buffAttackLevel = buffAttackLevel;
        //    this.buffDefenceLevel = buffDefenceLevel;
        //    this.buffMagicAttackLevel = buffMagicAttackLevel;
        //    this.buffMagicDefenceLevel = buffMagicDefenceLevel;
        //    this.buffSpeed = buffSpeed;
        //    this.buffEvasiveness = buffEvasiveness;
        //    this.clonesAmount = clonesAmount;
        //}

        public string getTCPFormat()
        {
            string format = "<chareffects>";
            format += getTCPAilments() + getTCPBuffHealth() + getTCPBuffAttack() + getTCPBuffDefence() +  getTCPBuffMagicAttack() + getTCPBuffMagicDefence() + getTCPBuffSpeed() + getTCPBuffEvasiveness() + getTCPClonesAmount();
            format += "</chareffects>";
            return format;
        }

        private string getTCPAilments()
        {
            string format = "<ailments>";

            if (ailments != null)
            {
                foreach (Ailments ailment in ailments)
                {
                    format += "<option>" + ailment.ToString() + "</option>";
                }
            }

            format += "</ailments>";

            return format;
        }

        private string getTCPBuffHealth()
        {
            string format = "<buffhealth>" + buffHealth + "</buffhealth>";
            return format;
        }

        private string getTCPBuffAttack()
        {
            string format = "<buffattack>" + buffAttackLevel + "</buffattack>";
            return format;
        }

        private string getTCPBuffDefence()
        {
            string format = "<buffdefence>" + buffDefenceLevel + "</buffdefence>";
            return format;
        }

        private string getTCPBuffMagicAttack()
        {
            string format = "<buffmagicattack>" + buffMagicAttackLevel + "</buffmagicattack>";
            return format;
        }

        private string getTCPBuffMagicDefence()
        {
            string format = "<buffmagicdefence>" + buffMagicDefenceLevel + "</buffmagicdefence>";
            return format;
        }

        private string getTCPBuffSpeed()
        {
            string format = "<buffspeed>" + buffSpeed + "</buffspeed>";
            return format;
        }

        private string getTCPBuffEvasiveness()
        {
            string format = "<buffevasiveness>" + buffEvasiveness + "</buffevasiveness>";
            return format;
        }

        private string getTCPClonesAmount()
        {
            string format = "<clonesamount>" + clonesAmount + "</clonesamount>";
            return format;
        }
    }
}
