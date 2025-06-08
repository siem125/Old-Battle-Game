using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public enum MoveType
    {
        [EnumMember(Value = "MoveType.none")]
        none,
        [EnumMember(Value = "MoveType.attack")]
        attack,
        [EnumMember(Value = "MoveType.magic")]
        magicattack,
        [EnumMember(Value = "MoveType.defence")]
        defence,
        [EnumMember(Value = "MoveType.magicdefence")]
        magicdefence,
        [EnumMember(Value = "MoveType.buff")]
        buff,
        [EnumMember(Value = "MoveType.debuff")]
        debuff,
        [EnumMember(Value = "MoveType.give")]
        give,
        [EnumMember(Value = "MoveType.take")]
        take,
        [EnumMember(Value = "MoveType.heal")]
        heal,
        [EnumMember(Value = "MoveType.timetravel")]
        timetravel,
        [EnumMember(Value = "MoveType.weather")]
        weather
    }

    public enum TargetType
    {
        [EnumMember(Value = "TargetType.none")]
        none,
        [EnumMember(Value = "TargetType.self")]
        self,
        [EnumMember(Value = "TargetType.single")]
        single,
        [EnumMember(Value = "TargetType.allies")]
        allies,
        [EnumMember(Value = "TargetType.enemies")]
        enemies,
        [EnumMember(Value = "TargetType.all")]
        all,
        [EnumMember(Value = "TargetType.friendlyParty")]
        friendlyParty,
        [EnumMember(Value = "TargetType.enemyParty")]
        enemyParty
    }

    public class MoveList
    {
        //link of a specific moveset to multiple move functions
        private string name;
        private int maxAmount;
        private int currentAmount;
        private int accuracy;
        private int priority;
        //[JsonProperty("elements", ItemConverterType = typeof(StringEnumConverter))]
        //private List<Elements> elements { get; set; }
        //[JsonProperty("moves", ItemConverterType = typeof(StringEnumConverter))]
        private Elements element;
        private List<Move> moves;

        public MoveList(string name, int amount, int priority, int accuracy, Elements elements, List<Move> moves) //List<Elements> elements
        {
            this.name = name;
            this.maxAmount = amount;
            this.currentAmount = amount;
            this.priority = priority;
            this.accuracy = accuracy;
            this.element = elements;
            this.moves = moves;
        }

        #region normal functions

        public string getName()
        {
            return name;
        }

        public int getMaxAmount()
        {
            return maxAmount;
        }

        public int getCurrentAmount()
        {
            return currentAmount;
        }

        public int getPriority()
        {
            return priority;
        }

        public int getAccuracy()
        {
            return accuracy;
        }

        public void playedOnce()
        {
            if (currentAmount > 0)
            {
                currentAmount--;
            }
        }

        public List<Move> getMoves()
        {
            return moves;
        }

        public Elements getElement()
        {
            return element;
        }

        #endregion

        #region tcp functions

        public string getTCPFormat()
        {
            string format = "<movelist>";
            format += getTCPName() + getTCPMaxAmount() + getTCPCurrentAmount() + getTCPPriority() + getTCPAccuracy() + getTCPElement() + getTCPMoves();
            format += "</movelist>";
            return format;
        }

        private string getTCPName()
        {
            string format = "<name>" + name + "</name>";
            return format;
        }

        private string getTCPMaxAmount()
        {
            string format = "<maxamount>" + maxAmount + "</maxamount>";
            return format;
        }

        private string getTCPCurrentAmount()
        {
            string format = "<currentamount>" + currentAmount + "</currentamount>";
            return format;
        }

        private string getTCPPriority()
        {
            string format = "<priority>" + priority + "</priority>";
            return format;
        }

        private string getTCPAccuracy()
        {
            string format = "<accuracy>" + accuracy + "</accuracy>";
            return format;
        }

        private string getTCPElement()
        {
            string format = "<element>" + element + "</element>";
            return format;
        }

        private string getTCPMoves()
        {
            string format = "<moves>";

            foreach (Move move in moves)
            {
                format += move.getTCPFormat();
            }

            format += "</moves>";

            return format;
        }

        #endregion
    }
}
