using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class Info
    {
        //[JsonProperty("Information")]
        [JsonProperty("Level")]
        public int level { get; set; }
        [JsonProperty("evolutionLevel")]
        public int evolutionLevel { get; set; }
        public string uniqueName { get; set; } //the name of the character that is unique and'isn't able to change
        public string series { get; set; }
        public string name { get; set; }
        public int maxHealth { get; set; }
        public int currentHealth { get; set; }

        [JsonProperty("elements", ItemConverterType = typeof(StringEnumConverter))]
        public List<Elements> elements { get; set; }


        //public Info(int level, int evolutionLevel, string uniqueName, string series, string name, int maxHealth, List<Elements> elements)
        //{
        //    //set characters values
        //    this.level = level;
        //    this.evolutionLevel = evolutionLevel;
        //    this.uniqueName = uniqueName;
        //    this.series = series;
        //    this.name = name;
        //    this.maxHealth = maxHealth;
        //    this.currentHealth = maxHealth;
        //    this.elements = elements;
        //    //this.imagePath = imagePath;
        //}

        public string getTCPFormat()
        {
            string format = "<charinfo>";
            format += getTCPLevel() + getTCPEvolutionLevel() + getTCPUniqueName() + getTCPSeries() + getTCPName() + getTCPMaxHealth() + getTCPCurrentHealth() + getTCPElements();
            format += "</charinfo>";
            return format;
        }

        private string getTCPLevel()
        {
            string format = "<level>" + level + "</level>";
            return format;
        }

        private string getTCPEvolutionLevel()
        {
            string format = "<evolutionlevel>" + evolutionLevel + "</evolutionlevel>";
            return format;
        }

        private string getTCPUniqueName()
        {
            string format = "<uniquename>" + uniqueName + "</uniquename>";
            return format;
        }

        private string getTCPSeries()
        {
            string format = "<series>" + series + "</series>";
            return format;
        }

        private string getTCPName()
        {
            string format = "<name>" + name + "</name>";
            return format;
        }

        private string getTCPMaxHealth()
        {
            string format = "<maxhealth>" + maxHealth + "</maxhealth>";
            return format;
        }

        private string getTCPCurrentHealth()
        {
            string format = "<currenthealth>" + currentHealth + "</currenthealth>";
            return format;
        }

        private string getTCPElements()
        {
            string format = "<elements>";

            foreach (Elements element in elements)
            {
                format += "<option>" + element.ToString() + "</option>";
            }

            format += "</elements>";

            return format;
        }
    }
}
