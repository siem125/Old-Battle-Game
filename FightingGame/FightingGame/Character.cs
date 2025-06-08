using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public enum Elements
    {
        [EnumMember(Value = "Elements.Normal")]
        Normal,
        [EnumMember(Value = "Elements.Fighting")]
        Fighting,
        [EnumMember(Value = "Elements.Ki")]
        Ki,
        [EnumMember(Value = "Elements.Fire")]
        Fire,
        [EnumMember(Value = "Elements.Water")]
        Water,
        [EnumMember(Value = "Elements.Wind")]
        Wind,
        [EnumMember(Value = "Elements.Grass")]
        Grass,
        [EnumMember(Value = "Elements.Poison")]
        Poison,
        [EnumMember(Value = "Elements.Electric")]
        Electric,
        [EnumMember(Value = "Elements.Ground")]
        Ground,
        [EnumMember(Value = "Elements.Rock")]
        Rock,
        [EnumMember(Value = "Elements.Psycic")]
        Psycic,
        [EnumMember(Value = "Elements.Nuclear")]
        Nuclear,
        [EnumMember(Value = "Elements.Almighty")]
        Almighty,
        [EnumMember(Value = "Elements.Ice")]
        ice,
        [EnumMember(Value = "Elements.Bug")]
        Bug,
        [EnumMember(Value = "Elements.Spirit")]
        Spirit,
        [EnumMember(Value = "Elements.Steel")]
        Steel,
        [EnumMember(Value = "Elements.Dragon")]
        Dragon,
        [EnumMember(Value = "Elements.Light")]
        Light,
        [EnumMember(Value = "Elements.Dark")]
        Dark,
        [EnumMember(Value = "Elements.Fairy")]
        Fairy,
        [EnumMember(Value = "Elements.Angelic")]
        Angelic,
        [EnumMember(Value = "Elements.Demonic")]
        Demonic,
        [EnumMember(Value = "Elements.Fallen")]
        Fallen
    }

    public enum Ailments
    {
        [EnumMember(Value = "Ailments.Poisoned")]
        Poisoned,
        [EnumMember(Value = "Ailments.Bleeding")]
        Bleeding,
        [EnumMember(Value = "Ailments.Burning")]
        Burning,
        [EnumMember(Value = "Ailments.Frozen")]
        Frozen,
        [EnumMember(Value = "Ailments.Confused")]
        Confused,
        [EnumMember(Value = "Ailments.Asleep")]
        Asleep,
        [EnumMember(Value = "Ailments.Paralysed")]
        Paralysed,
        [EnumMember(Value = "Ailments.Taunt")]
        Taunt
    }

    public enum blockTypes
    {
        [EnumMember(Value = "blockTypes.None")]
        None,
        [EnumMember(Value = "blockTypes.Block")]
        Block,
        [EnumMember(Value = "blockTypes.Reversal")]
        Reversal
    }

    public class Character
    {
        #region Variables

        //effect tracker
        #region effects

        public List<Ailments> ailments;
        private int buffHealth; //Only buffed at spawn of future characters
        private int buffAttackLevel;
        private int buffDefenceLevel;
        private int buffMagicAttackLevel;
        private int buffMagicDefenceLevel;
        private int buffSpeed;
        private int buffEvasiveness;
        private int buffAccuracy;
        private int clonesAmount; //amount of times attack will be repeated((finalAttackValue * clones) + (1 * finalAttackValue))

        #endregion

        //character stuff
        #region character

        private int level;
        private string officialName; //the name of the character that is unique and'isn't able to change
        private string name;
        private int maxHealth;
        private int currentHealth;
        private List<Elements> elements;
        public string baseCharacterPath; //path where image is stored

        #endregion

        //base stats
        #region base stats
        private int attack;
        private int defence;
        private int magicAttack;
        private int magicDefense;
        private int speed;
        private int evasiveness;
        private int accuracy;

        #endregion

        //Evolution options and alternate form\
        #region forms
        private int ableToEvolveFromThisLevel; //this is the level from which the character is able to evolve into next character

        //alternative forms
        private List<AlternativeCharacter> alternativeForms; //list of alternative forms
        private AlternativeCharacter alternative = null; //selected alternative form
        #endregion

        //Moves
        #region moves

        //private List<Moves> ableMoveSet; //moves this character can learn
        private List<MoveList> learntMoves; //character's current moves

        #endregion

        //other
        private bool reverseDamageAndHealing; //reverses taking damage and healing
        private int autoHealPercentage; //percentage of maxhealth that will be recovered each turn
        //private string characterPath;
        private string currentCharacterImagePath;

        //blocking damage
        private bool blockDamageOnce; //used as indicator for if damage is blocked for one turn if so then look if reversal or blockdamage
        private bool reversal; //blocks attack and return amount

        //auto heal once
        public bool healOnceAfter0 { get; set; }
        public int healPercentageAfter0 { get; set; }

        public bool createdFromTCP;

        #region copyFrom variables

        //official constructor copyFrom values
        public Info charInfo;
        public Stats baseStats;
        public Moves moves;
        public Effects effects;

        #endregion

        #endregion

        //split the variable collections into multiple classes and make a second constructor using these classes
        public Character(Info charInfo, Stats baseStats, Moves moves, Effects effects, List<AlternativeCharacter> alternatives, bool createdFromTCP, string baseCharacterPath = "")
        {
            //load info variables
            #region info values 

            this.charInfo = charInfo;
            this.baseStats = baseStats;
            this.moves = moves;
            this.effects = effects;

            //characters values
            this.level = charInfo.level;
            this.officialName = charInfo.uniqueName;
            this.name = charInfo.name;
            this.maxHealth = charInfo.maxHealth;
            this.currentHealth = charInfo.maxHealth;
            this.elements = charInfo.elements;
            this.ableToEvolveFromThisLevel = charInfo.evolutionLevel;
            //this.imagePath = charInfo.imagePath;

            //stats
            this.attack = baseStats.attack;
            this.defence = baseStats.defence;
            this.magicAttack = baseStats.magicAttack;
            this.magicDefense = baseStats.magicDefense;
            this.speed = baseStats.speed;
            this.evasiveness = baseStats.evasiveness;
            this.accuracy = baseStats.accuracy;

            //moves
            learntMoves = moves.moves;

            //effects
            if (effects != null)
            {
                this.ailments = effects.ailments;
                this.buffHealth = effects.buffHealth;
                this.buffAttackLevel = effects.buffAttackLevel;
                this.buffDefenceLevel = effects.buffDefenceLevel;
                this.buffMagicAttackLevel = effects.buffMagicAttackLevel;
                this.buffMagicDefenceLevel = effects.buffMagicDefenceLevel;
                this.buffSpeed = effects.buffSpeed;
                this.buffEvasiveness = effects.buffEvasiveness;
                this.clonesAmount = effects.clonesAmount;
            }
            else
            {
                this.ailments = new List<Ailments>();
                this.buffHealth = 0;
                this.buffAttackLevel = 0;
                this.buffDefenceLevel = 0;
                this.buffMagicAttackLevel = 0;
                this.buffMagicDefenceLevel = 0;
                this.buffSpeed = 0;
                this.buffEvasiveness = 0;
                this.clonesAmount = 0;
            }

            //other 
            this.reverseDamageAndHealing = false;
            this.autoHealPercentage = 0;

            //block damage
            this.blockDamageOnce = false;
            this.reversal = false;

            //auto heal
            this.healOnceAfter0 = true;
            this.healPercentageAfter0 = 20;

            this.alternativeForms = alternatives;

            #endregion

            //tcp check
            this.createdFromTCP = createdFromTCP;

            //if on local machine/created from this pc insted of from tcp
            if (createdFromTCP == false && baseCharacterPath != string.Empty)
            {
                //character values
                //this.characterPath = characterPath; //owned character path
                this.baseCharacterPath = baseCharacterPath; //base character path
                this.currentCharacterImagePath = baseCharacterPath;              
            }
            else
            {
                //if not load the default (smash hidden character) folder and load the images from here
                string storyCharPath = Functions.getStoriesFolder() + charInfo.series + "\\Characters\\" + charInfo.uniqueName + "\\"; //path where base info is stored

                if (Directory.Exists(storyCharPath))
                {
                    this.baseCharacterPath = storyCharPath;
                    this.currentCharacterImagePath = baseCharacterPath;
                }
                else
                {
                    //load the hidden character folder
                    this.baseCharacterPath = Functions.getHiddenCharacterFolder();
                    this.currentCharacterImagePath = this.baseCharacterPath;
                }
            }
        }

        /// <summary>
        /// Copy from given oldClass into a new class
        /// </summary>
        /// <param name="copyFrom"></param>
        public Character(Character copyFrom) : this(copyFrom.charInfo, copyFrom.baseStats, copyFrom.moves, copyFrom.effects, copyFrom.alternativeForms, copyFrom.createdFromTCP, copyFrom.baseCharacterPath)
        {
            Console.WriteLine("Copied character");
        }

        //remove this and CharacterForms class since it is not gonna be used
        public void addAlternativeForms(CharacterForms forms)
        {
            //forms
            if (forms != null)
            {
                this.ableToEvolveFromThisLevel = forms.ableToEvolveFromThisLevel;
            }
            else
            {

            }
        }

        public string getName()
        {
            return name;
        }

        public int getLevel()
        {
            return level;
        }

        public int getHealth()
        {
            return this.currentHealth;
        }

        public int getMaxHealth()
        {
            return this.maxHealth;
        }

        public List<Elements> getElements()
        {
            return this.elements;
        }

        public string getCurrentCharacterPath()
        {
            return currentCharacterImagePath;
        }

        public string getBaseCharacterPath()
        {
            return this.baseCharacterPath;
        }

        public string getBaseBackImage()
        {
            string text = getCurrentCharacterPath() + "back.png";

            if (text == "back.png")
            {
                return Functions.getHiddenCharacterFolder() + "back.png";
            }
            else
            {
                return text;
            }
        }

        public string getBaseFrontImage()
        {
            string text = getCurrentCharacterPath() + "front.png";

            if (text == "front.png")
            {
                return Functions.getHiddenCharacterFolder() + "front.png";
            }
            else
            {
                return text;
            }
        }

        public List<MoveList> getMoves()
        {
            return learntMoves;
        }

        public List<Ailments> getAilments()
        {
            return ailments;
        }

        /// <summary>
        /// Heals the current health with the autoHealPercentage if it is bigger than 0
        /// </summary>
        public void autoHealTurnBased()
        {
            if (autoHealPercentage > 0)
            {
                this.currentHealth = currentHealth + (autoHealPercentage * currentHealth);
            }
        }

        public void changeAutoHeal(int percentage)
        {
            this.autoHealPercentage = percentage;
        }

        public void heal(int number)
        {
            this.currentHealth = currentHealth + number;
        }

        /// <summary>
        /// returns blockType if there is one
        /// </summary>
        /// <returns></returns>
        public blockTypes checkBlockDamageTypeAndActive()
        {
            if (blockDamageOnce == true)
            {
                this.blockDamageOnce = false;

                if (reversal == true)
                {
                    reversal = false;

                    return blockTypes.Reversal;
                }
                else
                {
                    return blockTypes.Block;
                }
            }
            else
            {
                return blockTypes.None;
            }
        }

        public void setBlockDamageType(blockTypes bt)
        {
            this.blockDamageOnce = true;

            if (bt == blockTypes.Reversal)
            {
                reversal = true;
            }
            else
            {
                reversal = false;
            }
        }
        
        //Taking damage
        #region Take damage events

        /// <summary>
        /// take physical damage event
        /// </summary>
        /// <param name="damage"></param>
        public void getAttackedWithPhysicalDamage(int damage)
        {
            if (blockDamageOnce == false)
            {
                int attackNumber = (damage - defence);

                if (attackNumber <= 0)
                {
                    attackNumber = 1;
                }

                currentHealth = currentHealth - attackNumber;

                //check health
                if (currentHealth <= 0)
                {
                    //set health to 0
                    currentHealth = 0;
                }
            }
            else
            {
                //take no damage
            }
        }

        /// <summary>
        /// Take magical damage event
        /// </summary>
        /// <param name="damage"></param>
        public void getAttackedWithMagicalDamage(int damage)
        {
            if (blockDamageOnce == false)
            {
                currentHealth = currentHealth - (damage - magicDefense);

                //check health
                if (currentHealth <= 0)
                {
                    //set health to 0
                    currentHealth = 0;

                    //check ability
                    if (healOnceAfter0 == true)
                    {
                        //if health is lower or equal to 0 then activate healPercentage and falsefy healOnceAfter0
                        healOnceAfter0 = false;
                        currentHealth = currentHealth + healPercentageAfter0;
                    }
                }
            }
            else
            {
                //take no damage
            }
        }
        
        #endregion

        //Ailments
        #region ailments

        public void addAilment(Ailments ailment)
        {
            bool alreadyAilmented = false;

            //loop through ailments list
            foreach (Ailments ail in ailments)
            {
                if (ail == ailment)
                {
                    alreadyAilmented = true;
                }
            }

            //if not already in add it
            if (!alreadyAilmented)
            {
                ailments.Add(ailment);
            }
        }

        public void removeAilment(Ailments ailment)
        {
            List<int> indexes = new List<int>();

            //get indexes of all matching ailments
            for(int i = 0; i <= ailments.Count(); i++)
            {
                Ailments ail = ailments[i];
                if (ail == ailment)
                {
                    indexes.Add(i);
                }
            }


            //remove ailments at index
            foreach (int index in indexes)
            {
                ailments.RemoveAt(index);
            }
        }

        #endregion

        //Get stats with buff/debuff values
        #region Get stats values with buff/debuff

        public int getAttackValue()
        {
            if (buffAttackLevel >= 0)
            {
                //do calculation
                int trueAttack = attack + buffAttackLevel;
                return trueAttack;
            }
            else
            {
                int trueAttack = attack - buffAttackLevel;

                if (trueAttack > 0)
                {
                    return trueAttack;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getDefenceValue()
        {
            if (buffDefenceLevel >= 0)
            {
                //do calculation
                int trueDefence = defence + buffDefenceLevel;
                return trueDefence;
            }
            else
            {
                int trueDefence = defence - buffDefenceLevel;

                if (trueDefence > 0)
                {
                    return trueDefence;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getMagicAttack()
        {
            if (buffMagicAttackLevel >= 0)
            {
                //do calculation
                int trueMagicAttack = magicAttack + buffMagicAttackLevel;
                return trueMagicAttack;
            }
            else
            {
                int trueMagicAttack = magicAttack - buffMagicAttackLevel;

                if (trueMagicAttack > 0)
                {
                    return trueMagicAttack;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getMagicDefence()
        {
            if (buffDefenceLevel >= 0)
            {
                //do calculation
                int trueMagicDef = magicDefense + buffMagicDefenceLevel;
                return trueMagicDef;
            }
            else
            {
                int trueMagicDef = magicDefense - buffMagicDefenceLevel;

                if (trueMagicDef > 0)
                {
                    return trueMagicDef;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getSpeed()
        {
            if (buffSpeed >= 0)
            {
                //do calculation
                int trueSpeed = speed + buffSpeed;
                return trueSpeed;
            }
            else
            {
                int trueSpeed = speed - buffSpeed;

                if (trueSpeed > 0)
                {
                    return trueSpeed;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getEvasiveness()
        {
            if (buffEvasiveness >= 0)
            {
                //do calculation
                int trueEvasiveness = evasiveness + buffEvasiveness;
                return trueEvasiveness;
            }
            else
            {
                int trueEvasiveness = evasiveness - buffEvasiveness;

                if (trueEvasiveness > 0)
                {
                    return trueEvasiveness;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int getAccuracy()
        {
            if (buffAccuracy >= 0)
            {
                //do calculation
                int trueAccuracy = accuracy + buffAccuracy;
                return trueAccuracy;
            }
            else
            {
                int trueAccuracy = accuracy - buffAccuracy;

                if (trueAccuracy > 0)
                {
                    return trueAccuracy;
                }
                else
                {
                    return 5;
                }
            }
        }

        #endregion

        //Buff/Debuff adding
        #region Buff/Debuff events

        public void buffAttack(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffAttackLevel += buff;
            }
            else
            {
                buffAttackLevel -= buff;
            }
        }

        public void debuffAttack(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffAttackLevel -= debuff;
            }
            else
            {
                buffAttackLevel += debuff;
            }
        }

        public void buffDefence(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffDefenceLevel += buff;
            }
            else
            {
                buffDefenceLevel -= buff;
            }
        }

        public void debuffDefence(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffDefenceLevel -= debuff;
            }
            else
            {
                buffDefenceLevel += debuff;
            }
        }

        public void buffMagicAttack(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffMagicAttackLevel += buff;
            }
            else
            {
                buffMagicAttackLevel -= buff;
            }
        }

        public void debuffMagicAttack(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffMagicAttackLevel -= debuff;
            }
            else
            {
                buffMagicAttackLevel += debuff;
            }
        }

        public void buffMagicDefence(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffMagicDefenceLevel += buff;
            }
            else
            {
                buffMagicDefenceLevel -= buff;
            }
        }

        public void debuffMagicDefence(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffMagicDefenceLevel -= debuff;
            }
            else
            {
                buffMagicDefenceLevel += debuff;
            }
        }

        public void buffSpeedLevel(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffSpeed += buff;
            }
            else
            {
                buffSpeed -= buff;
            }
        }

        public void debuffSpeedLevel(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffSpeed -= debuff;
            }
            else
            {
                buffSpeed += debuff;
            }
        }

        public void buffEvasivenessLevel(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffEvasiveness += buff;
            }
            else
            {
                buffEvasiveness -= buff;
            }
        }

        public void debuffEvasivenessLevel(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffEvasiveness -= debuff;
            }
            else
            {
                buffEvasiveness += debuff;
            }
        }

        public void buffAccuracyLevel(int buff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffAccuracy += buff;
            }
            else
            {
                buffAccuracy -= buff;
            }
        }

        public void debuffAccuracyLevel(int debuff)
        {
            if (reverseDamageAndHealing == false)
            {
                buffAccuracy -= debuff;
            }
            else
            {
                buffAccuracy += debuff;
            }
        }

        #endregion

        public void addClones(int amount)
        {
            this.clonesAmount = clonesAmount + amount;
        }

        public void removeClones(int amount)
        {
            if (clonesAmount - amount >= 0)
            {
                clonesAmount = clonesAmount - amount;
            }
            else
            {
                clonesAmount = 0;
            }
        }

        #region Alternative

        public List<AlternativeCharacter> getAlternatives()
        {
            return alternativeForms;
        }

        public bool checkIfIsAlternative()
        {
            if (alternative != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void switchToAlternative(AlternativeCharacter alternativeChar)
        {
            //select alternative
            alternative = alternativeChar;

            //set the new image path
            currentCharacterImagePath = alternative.getBaseAlternativePath();

            //use the stats to alter the current stats
            this.learntMoves = alternative.getMoves().moves;
        }

        public void switchToNormalFromAlternative()
        {
            if (alternative != null)
            {
                //set info back to normal using the current - alternative stats
                currentCharacterImagePath = baseCharacterPath;

                //reset the alternative variable
                this.alternative = null;
                this.learntMoves = moves.moves;

                //use
                //Info charInfo;
                //Stats baseStats;
                //Moves moves;
                //Effects effects;
    }
            else
            {
                //no alt found
            }
        }

        #endregion

        //tcp message string of the character
        public string getTCPFormat()
        {     
            //add user in front of it like:
            //<Siem125>
            //  <character>
            //      ...
            //  </character>
            //</Siem125>
            string format = "<character>" + effects.getTCPFormat() + charInfo.getTCPFormat() + baseStats.getTCPFormat() + moves.getTCPFormat() + getAlternativesTCP() + "</character>";

            return format;
        }

        public string getAlternativesTCP()
        {
            string format = "<altlist>";

            if (alternativeForms != null)
            {
                foreach (AlternativeCharacter alt in alternativeForms)
                {
                    format += alt.getTCPFormat();
                }
            }

            format += "</altlist>";
            return format;
        }

        public override string ToString()
        {
            //the character as a tcp sender
            string message = "";

            return message;
            //return base.ToString();
        }
    }
}
