using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class AlternativeCharacter
    {
        private string baseAlternativePath;
        private Effects effects;
        private AlternativeInfo info;
        private Moves moves;
        private Stats stats;

        public AlternativeCharacter(Effects effects, AlternativeInfo info, Moves moves, Stats stats, string BaseAlternativePath = "")
        {
            this.effects = effects;
            this.info = info;
            this.moves = moves;
            this.stats = stats;

            //find string based on info else
            if (baseAlternativePath != "")
            {
                this.baseAlternativePath = BaseAlternativePath; //base alternative path
            }
            else
            {
                //search if path based on info exists if not then hidden smash character
            }
        }

        public AlternativeCharacter(AlternativeCharacter character) : this(character.getEffects(), character.getInfo(), character.getMoves(), character.getStats(), character.getBaseAlternativePath())
        {
            Console.WriteLine("Alternative character copied from original");
        }

        public string getTCPFormat()
        {
            string format = "<altcharacter>";
            format += effects.getTCPFormat() + info.getTCPFormat() + moves.getTCPFormat() + stats.getTCPFormat();
            format += "</altcharacter>";
            return format;
        }

        public string getBaseAlternativePath()
        {
            return baseAlternativePath;
        }

        public Effects getEffects()
        {
            return effects;
        }

        public AlternativeInfo getInfo()
        {
            return info;
        }

        public Moves getMoves()
        {
            return moves;
        }
        
        public Stats getStats()
        {
            return stats;
        }
    }
}
