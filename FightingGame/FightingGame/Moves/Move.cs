using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    //Move is the linking of move and actions
    public class Move
    {
        MoveType type;
        TargetType target;
        Elements element;
        string number;
        string chosen;
        string isBuildUpTurns;
        int turns;
        int amount;

        //animation stuff
        string series;
        string animationName;
        AnimationBoxes animationBox;

        public Move(MoveType type, TargetType target, Elements element, string number, string chosen, string isBuildUpTurns, int turns, int amount, string series = null, string animationName = null, AnimationBoxes animationBox = AnimationBoxes.none) //string accuracy,
        {
            //buff - self - defence - 100000
            this.type = type;
            this.target = target;
            this.element = element; //new
            this.number = number;
            this.chosen = chosen;
            this.isBuildUpTurns = isBuildUpTurns;
            this.turns = turns;
            this.amount = amount;

            //animation stuff
            this.series = series;
            this.animationName = animationName;
            this.animationBox = animationBox;
        }

        #region normal functions

        public MoveType getType()
        {
            return type;
        }

        public TargetType getTarget()
        {
            return target;
        }

        public string getNumber()
        {
            return number;
        }

        public string getChosen()
        {
            if (chosen != null && chosen != "")
            {
                return chosen;
            }
            else
            {
                return null;
            }
        }

        public string getBuidUpBoolean()
        {
            return isBuildUpTurns;
        }

        public int getTurns()
        {
            return turns;
        }

        public Elements getElement()
        {
            return element;
        }

        /// <summary>
        /// gets the amount of repeating times of this move
        /// </summary>
        /// <returns></returns>
        public int getAmount()
        {
            return amount;
        }

        #endregion

        #region tcp functions

        public string getTCPFormat()
        {
            string format = "<move>";
            format += getTCPType() + getTCPTarget() + getTCPElement() + getTCPNumber() + getTCPChosen() + getTCPIsBuildUpTurns() + getTCPTurns() + getTCPAmount();
            format += "</move>";
            return format;
        }

        private string getTCPType()
        {
            string format = "<type>" + type + "</type>";
            return format;
        }

        private string getTCPTarget()
        {
            string format = "<target>" + target + "</target>";
            return format;
        }

        private string getTCPElement()
        {
            string format = "<element>" + element + "</element>";
            return format;
        }

        private string getTCPNumber()
        {
            string format = "<number>" + number + "</number>";
            return format;
        }

        private string getTCPChosen()
        {
            string format = "<chosen>" + chosen + "</chosen>";
            return format;
        }

        private string getTCPIsBuildUpTurns()
        {
            string format = "<isbuildupturns>" + isBuildUpTurns + "</isbuildupturns>";
            return format;
        }

        private string getTCPTurns()
        {
            string format = "<turns>" + turns + "</turns>";
            return format;
        }

        private string getTCPAmount()
        {
            string format = "<amount>" + amount + "</amount>";
            return format;
        }

        #endregion
    }
}
