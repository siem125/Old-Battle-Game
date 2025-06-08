using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class AlternativeInfo
    {
        public string uniqueName { get; set; } //the name of the character that is unique and'isn't able to change
        public string series { get; set; }
        public int maxHealth { get; set; }

        [JsonProperty("elements", ItemConverterType = typeof(StringEnumConverter))]
        public List<Elements> elements { get; set; }

        #region tcp functions

        public string getTCPFormat()
        {
            string format = "<altcharinfo>";
            format += getTCPUniqueName() + getTCPSeries() + getTCPMaxHealth() + getTCPElements();
            format += "</altcharinfo>";
            return format;
        }

        private string getTCPUniqueName()
        {
            string format = "<uniquename>" + uniqueName + "</uniquename>";
            return format;
        }

        private string getTCPSeries()
        {
            string format = "<series>" + series + "</serues>";
            return format;
        }

        private string getTCPMaxHealth()
        {
            string format = "<maxhealth>" + maxHealth + "</maxhealth>";
            return format;
        }

        private string getTCPElements()
        {
            string format = "<elements>";

            if (elements != null)
            {
                foreach (Elements element in elements)
                {
                    format += "<option>" + element.ToString() + "</option>";
                }
            }

            format += "</elements>";

            return format;
        }

        #endregion
    }
}
