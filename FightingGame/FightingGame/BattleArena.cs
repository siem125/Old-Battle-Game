using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightingGame
{
    public enum AnimationBoxes
    {
        none,
        self,
        selfLeft,
        selfRight,
        center,
        enemy,
        enemyLeft,
        enemyRight
    }

    public enum ailmentHandlings
    {
        BeforeMove,
        AfterMove,
        DuringMove,
        StartTurn,
        EndTurn,
        ChoosingMove
    }

    public partial class BattleArena : Form
    {
        //party character variables
        private List<Character> enemyParty = new List<Character>();
        private List<Character> ownParty = new List<Character>();

        //tcp server connection
        private static TcpClient client = null;
        private static string sendedMessage = ""; //message that will be sended

        //field character variables
        private Character ownChosen;
        private Character enemyChosen;

        //move variables
        private MoveList enemyMove;
        private MoveList ownMove;
        private bool enemyMoveHits;
        private bool ownMoveHits;    

        //Random random = new Random();
        //battle indicator values
        private int turnCount;
        private bool isBot;

        //change event variables
        private bool enemyHasChanged = false;
        private bool ownHasChanged = false;

        TypeAdvantagesCalculations tac = new TypeAdvantagesCalculations();
        ChatArea chat;

        Random random = new Random();

        public BattleArena(List<Character> ownParty, List<Character> enemyParty, TcpClient clienter = null)
        {
            InitializeComponent();

            //check if there is a server, if so then 
            //we play against player. if not then against bot
            if (client != null)
            {
                isBot = false;
                client = clienter;

                //backgroundworker setup stuff

                //set reporting progress for ui updating and cancellation support and run the async functions
                BackgroundWorkerReceiver.RunWorkerAsync();
                BackgroundWorkerReceiver.WorkerReportsProgress = true;
                backgroundWorkerSender.WorkerSupportsCancellation = true;
            }
            else
            {
                isBot = true;
            }

            //party's setup
            this.ownParty = ownParty;
            this.enemyParty = enemyParty;

            turnCount = 0;

            //set first of party
            //ownChosen = ownParty[0];
            enemyChosen = enemyParty[0];

            //
            changeOwnCharacter(0);
            changeEnemyCharacter(0);

            //load the chat
            getChat();

            //set chat variable as chatarea
            chat = (ChatArea)pnlChat.Controls[0];

            timer.Start();
        }

        private void getChat()
        {
            pnlChat.Controls.Clear();

            ChatArea ca = new ChatArea(this, false);
            ca.Dock = DockStyle.Fill;
            pnlChat.Controls.Add(ca);
        }

        #region own functions

        public int getOwnCharacterHealth()
        {
            return ownChosen.getHealth();
        }

        /// <summary>
        /// changes character from party number and loads the attacks and updates the info
        /// </summary>
        /// <param name="index"></param>
        public void changeOwnCharacter(int index)
        {
            //update the own values from character
            ownChosen = ownParty[index];

            ownHasChanged = true;

            flpAttacks.Controls.Clear();

            //checks the alternatives
            if (ownChosen.getAlternatives().Count() > 0)
            {
                btnAlternatives.Enabled = true;
            }
            else
            {
                btnAlternatives.Enabled = false;
            }

            //load attack options
            loadAttacks();

            updateOwnCharacterInfo();
        }

        /// <summary>
        /// uses the changeowncharacter method and then dissable buttons and set usedmove to used
        /// </summary>
        /// <param name="index"></param>
        public void changeOwnCharacterUsesMove(int index)
        {
            changeOwnCharacter(index);

            //dissable attacks and buttons
            dissabler();

            //set ownMove to true
            settedOwn = true;
        }

        public void updateOwnCharacterInfo()
        {
            //updates own health and lvl from character   
            lblOwnName.Text = ownChosen.getName();
            lblOwnLevel.Text = ownChosen.getLevel().ToString();

            //health
            lblOwnMaxHealth.Text = ownChosen.getMaxHealth().ToString();
            lblOwnCurrentHealth.Text = ownChosen.getHealth().ToString();

            if (pnlOwnhealth.Controls.Count == 0 || ownHasChanged == true)
            {
                pnlOwnhealth.Controls.Clear();
                pnlOwnhealth.Controls.Add(new OwnProgressBar(ownChosen.getMaxHealth(), ownChosen.getHealth()));
                ownHasChanged = false;
            }
            else
            {
                OwnProgressBar opb = (OwnProgressBar)pnlOwnhealth.Controls[0];
                opb.changePB(ownChosen.getHealth());
            }

            //load image\
            pbOwnCharacterImage.Image = Image.FromFile(ownChosen.getBaseBackImage());
        }

        public void checkOwnAilments()
        {
            //load ailments into flpEnemyAilments
            foreach (Ailments ailment in ownChosen.ailments)
            {
                TypeBox ab = getAilmentBoxFromAilment(ailment);

                //check if it already is within the flowlayoutpanel
                if (!flpEnemyAilments.Controls.Contains(ab) && ab != null)
                {
                    flpOwnAilments.Controls.Add(ab);
                }
            }
        }

        #endregion

        #region enemy functions

        private void changeEnemyCharacter(int index)
        {
            //update the enemy values from changed
            enemyChosen = enemyParty[index];

            //reset enemy progressbar
            enemyHasChanged = true;

            updateEnemyCharacterInfo();
        }

        public void updateEnemyCharacterInfo()
        {
            //updates enemy health and lvl from character
            //updates own health and lvl from character   
            lblEnemyName.Text = enemyChosen.getName();
            lblEnemyLevel.Text = enemyChosen.getLevel().ToString();

            //health
            lblEnemyMaxHealth.Text = enemyChosen.getMaxHealth().ToString();
            lblEnemyCurrentHealth.Text = enemyChosen.getHealth().ToString();

            if (pnlEnemyHealth.Controls.Count == 0 || enemyHasChanged == true)
            {
                pnlEnemyHealth.Controls.Clear();
                pnlEnemyHealth.Controls.Add(new OwnProgressBar(enemyChosen.getMaxHealth(), enemyChosen.getHealth()));
                enemyHasChanged = false;
            }
            else
            {
                OwnProgressBar opb = (OwnProgressBar)pnlEnemyHealth.Controls[0];
                opb.changePB(enemyChosen.getHealth());
            }

            //check ailments
            checkEnemyAilments();

            //load image
            pbEnemyCharacterImage.Image = Image.FromFile(enemyChosen.getBaseFrontImage());
        }

        public void checkEnemyAilments()
        {
            //load ailments into flpEnemyAilments
            if (enemyChosen.ailments != null)
            {
                foreach (Ailments ailment in enemyChosen.ailments)
                {
                    TypeBox ab = getAilmentBoxFromAilment(ailment);

                    //check if it already is within the flowlayoutpanel
                    if (!flpEnemyAilments.Controls.Contains(ab) && ab != null)
                    {
                        flpEnemyAilments.Controls.Add(ab);
                    }
                }
            }
        }

        #endregion

        #region ailment/element typebox functions

        public TypeBox getAilmentBoxFromAilment(Ailments ailment)
        {
            TypeBox ab = null;

            //check ailment
            if (ailment == Ailments.Poisoned)
            {
                ab = new TypeBox(ailment.ToString(), Color.Purple);
            }
            else if (ailment == Ailments.Bleeding)
            {
                ab = new TypeBox(ailment.ToString(), Color.Red);
            }

            //return value
            if (ab != null)
            {
                return ab;
            }
            else
            {
                return null;
            }
        }

        public TypeBox getAilmentBoxFromElement(Elements element)
        {
            TypeBox ab = null;

            //check ailment
            if (element == Elements.Normal)
            {
                ab = new TypeBox(element.ToString(), Color.LightGray);
            }
            else if (element == Elements.Fighting)
            {
                ab = new TypeBox(element.ToString(), Color.Brown);
            }

            //return value
            if (ab != null)
            {
                return ab;
            }
            else
            {
                return null;
            }
        }

        #endregion

        private void loadAttacks()
        {
            flpAttacks.Controls.Clear();

            foreach (MoveList move in ownChosen.getMoves())
            {
                BattleButton ba = new BattleButton(this, move);
                flpAttacks.Controls.Add(ba);
            }
        }

        #region set moves
        public void setEnemyMove(MoveList move, bool doesHit)
        {
            //set move
            this.enemyMove = move;

            //set if the move hits
            this.enemyMoveHits = doesHit;
        }

        public void setownMove(MoveList move, bool doesHit)
        {
            //set Own Move
            this.ownMove = move;

            //set the indicator if move hits

            //calculation stuff
            int enemyEvasion = enemyChosen.getEvasiveness();
            int moveAcc = move.getAccuracy() * ownChosen.getAccuracy();

            //if acc is higher or equal to 100 then move always hits
            if (moveAcc > enemyEvasion || moveAcc == 100)
            {
                doesHit = true;
            }
            else
            {
                //chance calculation
                //float percent = (float)moveAcc / (float)enemyEvasion;
                int value = random.Next(0, 100); //chance is 50/50

                if (value <= 50)
                {
                    doesHit = true;
                }
                else
                {
                    doesHit = false;
                }
            }

            this.ownMoveHits = doesHit;

            //send move message through the chat
        }

        #endregion

        //the function that handles both events etc
        //set booleans for turn tracking
        bool settedOwn = false;
        bool settedEnemy = false;
        public void turn()
        {
            //Console.WriteLine("1 more check");

            //get enemy move(only for story)
            if (enemyMove != null)
            {
                settedEnemy = true;
            }
            else
            {
                //if bot choose random move detect if gonna hit
                if (isBot == true)
                {
                    //get random value
                    int number = new Random().Next(0, enemyChosen.getMoves().Count() - 1);

                    //calculate hit chance
                    bool doesHit = false;

                    //
                    MoveList ml = enemyChosen.getMoves()[number];
                    int enemyEvasion = ownChosen.getEvasiveness();
                    int moveAcc = ml.getAccuracy() * enemyChosen.getAccuracy();

                    //if acc is higher or equal to 100 then move always hits
                    if (moveAcc > enemyEvasion || moveAcc == 100)
                    {
                        doesHit = true;
                    }
                    else
                    {
                        //chance calculation
                        //float percent = (float)moveAcc / (float)enemyEvasion;
                        int value = random.Next(0, 100); //chance is 50/50

                        if (value <= 50)
                        {
                            doesHit = true;
                        }
                        else
                        {
                            doesHit = false;
                        }                   
                    }

                    //set enemy move
                    setEnemyMove(ml, doesHit);
                }
                else
                {
                    //check chat for the getAttackNumber command for move number and hit indicator bool
                }
            }

            //get own move
            if (ownMove != null)
            {
                settedOwn = true;
            }


            //check if can battle
            if (settedOwn == true && settedEnemy == true)
            {
                //turn up
                turnCount++;

                chat.addTurnHeader(turnCount);

                //Console.WriteLine("Turn " + turnCount + " Has ended");

                //before move ailment handlings
                handleCharacterAilments(ownChosen, ailmentHandlings.BeforeMove);
                handleCharacterAilments(enemyChosen, ailmentHandlings.BeforeMove);

                //checks if one of the character moves is equal to null, then character switched
                if (ownMove == null)
                {
                    //only handle enemymove
                    handleEnemyMove();

                    //handleOwn will detect that character switched
                    handleOwnMove();
                }
                else if (enemyMove == null)
                {
                    //only handle own move
                    handleOwnMove();

                    //handleEnemy will detect that character switched
                    handleEnemyMove();
                }
                else
                {
                    //detect faster character
                    if (ownChosen.getSpeed() > enemyChosen.getSpeed() && ownMove.getPriority() > enemyMove.getPriority())
                    {
                        handleOwnMove();

                        handleEnemyMove();
                    }
                    else if (enemyChosen.getSpeed() > ownChosen.getSpeed() && ownMove.getPriority() < enemyMove.getPriority())
                    {
                        handleEnemyMove();

                        handleOwnMove();
                    }
                    else
                    {
                        if (ownMove.getPriority() > enemyMove.getPriority())
                        {
                            //own priority is first
                            handleOwnMove();

                            handleEnemyMove();
                        }
                        else if (ownMove.getPriority() < enemyMove.getPriority())
                        {
                            //enemy priority is first
                            handleEnemyMove();

                            handleOwnMove();
                        }
                        else if (ownMove.getPriority() == enemyMove.getPriority())
                        {
                            //check speed
                            if (ownChosen.getSpeed() > enemyChosen.getSpeed())
                            {
                                handleOwnMove();

                                handleEnemyMove();
                            }
                            else if (enemyChosen.getSpeed() > ownChosen.getSpeed())
                            {
                                handleEnemyMove();

                                handleOwnMove();
                            }
                            else
                            {
                                //their both same speed, randomize the first one
                                //use chat to allocate which player is acctually going first
                                //but for bot use this
                                if (isBot == true)
                                {
                                    handleOwnMove();

                                    handleEnemyMove();
                                }
                                else
                                {
                                    //use chat to see who goes first

                                }
                            }
                        }
                    }
                }

                //do after move ailment check
                handleCharacterAilments(ownChosen, ailmentHandlings.AfterMove);
                handleCharacterAilments(enemyChosen, ailmentHandlings.AfterMove);

                //do end turn ailment check
                handleCharacterAilments(ownChosen, ailmentHandlings.EndTurn);
                handleCharacterAilments(enemyChosen, ailmentHandlings.EndTurn);

                //check both health and if need for switching character
                checkHealth();

                //do autoheal/recovering health check

                //reset moves
                enemyMove = null;
                ownMove = null;

                //reset boolean values
                settedOwn = false;
                settedEnemy = false;

                //enable buttons
                ennabler();

                //check / dissable moves, dissable specific moves for self
                handleCharacterAilments(ownChosen, ailmentHandlings.ChoosingMove);

                //start turn ailmenthandling
                handleCharacterAilments(ownChosen, ailmentHandlings.StartTurn);
                handleCharacterAilments(enemyChosen, ailmentHandlings.StartTurn);
            }
        }

        #region UsingMoveCheckEvents

        /// <summary>
        /// Handles own move
        /// </summary>
        private void handleOwnMove()
        {
            //if move is chosen and hist
            if (ownMove != null && ownMoveHits == true)
            {
                useMove(ownChosen, enemyChosen, ownMove);
            }
            //if move is chosen and hit fails
            else if (ownMove != null && ownMoveHits == false)
            {
                //attack missed
                chat.addTurn("Own attack missed");
            }
            else if (ownMove == null)
            {
                //own character switched
                chat.addTurn("Own Character switched");
            }
        }

        /// <summary>
        /// Handles enemy move
        /// </summary>
        private void handleEnemyMove()
        {
            //if enemymove hits
            if (enemyMove != null && enemyMoveHits == true)
            {
                useMove(enemyChosen, ownChosen, enemyMove);
            }
            //if enemymove fails
            else if (enemyMove != null && enemyMoveHits == false)
            {
                //attack missed
                chat.addTurn("Enemy attack missed");
            }
            //if character switches
            else if (enemyMove == null)
            {
                //own character switched
                chat.addTurn("Enemy Character switched");
            }
        }

        #endregion

        /// <summary>
        /// Checks health and also checks available party members and is winning/losing condition checker
        /// </summary>
        public void checkHealth()
        {
            //check enemy health
            if (enemyChosen.getHealth() <= 0)
            {
                //check if enemy has recovery ability
                if (enemyChosen.healOnceAfter0 == true)
                {
                    int recoverHealth =  (enemyChosen.getMaxHealth() / 100) * enemyChosen.healPercentageAfter0;
                    enemyChosen.heal(recoverHealth);

                    enemyChosen.healOnceAfter0 = false;
                }
                else
                {
                    //need to switch character
                    List<Character> availableOptions = new List<Character>();
                    foreach (Character character in enemyParty)
                    {
                        if (character.getHealth() > 0)
                        {
                            availableOptions.Add(character);
                        }
                    }

                    //win condition
                    if (availableOptions.Count <= 0)
                    {
                        timer.Stop();

                        //show winning on screen with green bar and big text or something instead of messagebox
                        MessageBox.Show("Winner winner chicken dinner!");
                    }
                    else
                    {
                        //next character
                        if (isBot == true)
                        {
                            //get random from availables
                            int randNum = new Random().Next(0, availableOptions.Count);
                            //enemyChosen = availableOptions[randNum];
                            //enemyHasChanged = true;

                            //search enemy party for this character
                            int index = -1;
                            for(int i = 0; i < enemyParty.Count; i++)
                            {
                                Character enemy = enemyParty[i];
                                if (enemy == availableOptions[randNum])
                                {
                                    index = i;
                                }
                            }

                            if (index != -1)
                            {
                                changeEnemyCharacter(index);
                            }
                        }
                        else
                        {
                            //await party index response from player
                            //then use changeEnemy(index) event
                        }
                    }
                }
            }

            //check self health
            if (ownChosen.getHealth() <= 0)
            {
                //check if own has recovery ability
                if (ownChosen.healOnceAfter0 == true)
                {
                    int recoverHealth = (ownChosen.getMaxHealth() / 100) * ownChosen.healPercentageAfter0;
                    ownChosen.heal(recoverHealth);

                    ownChosen.healOnceAfter0 = false;
                }
                else
                {
                    //need to switch character using clickable usercontrols
                    //with index of party and health and conditions shown in the usercontol

                    //need to switch character
                    List<Character> availableOptions = new List<Character>();
                    foreach (Character character in ownParty)
                    {
                        if (character.getHealth() > 0)
                        {
                            availableOptions.Add(character);
                        }
                    }

                    //win condition
                    if (availableOptions.Count <= 0)
                    {
                        timer.Stop();

                        //show losing on screen with red bar and big text or something instead of messagebox
                        MessageBox.Show("You lost!");
                    }
                    else
                    {
                        //get character options
                        forceCharacterChange();
                    }
                }
            }

            updateBothCharacters();
        }

        /// <summary>
        /// forces the character to change the character
        /// </summary>
        private void forceCharacterChange()
        {
            btnMoves.Enabled = false;
            btnChange.Enabled = false;

            //if not able to switch back to current character then alter this function
            loadCharacters();

            //send the chosen character in the chat
        }

        public void useMove(Character self, Character enemy, MoveList move)
        {
            if (self.getHealth() > 0)
            {
                if (move != null)
                {
                    string Text = self.getName() + " used " + move.getName();
                    chat.addTurn(Text);

                    handleCharacterAilments(self, ailmentHandlings.DuringMove);
                    //Console.WriteLine(Text);

                    foreach (Move m in move.getMoves())
                    {
                        //detect which type it is and then handle the move
                        switch (m.getType())
                        {
                            case MoveType.attack:
                                //Do attack function with the needed info
                                attack(self, enemy, m);
                                break;

                            case MoveType.defence:
                                //Do defend function with the needed info

                                break;

                            case MoveType.magicattack:
                                //Do magic attack function with the needed info

                                break;

                            case MoveType.magicdefence:
                                //Do magic defend function with the needed info

                                break;

                            case MoveType.buff:
                                //Do buff function with the needed info

                                break;

                            case MoveType.debuff:
                                //Do debuff function with the needed info

                                break;

                            case MoveType.give:
                                //Do ailment function with the needed info

                                break;

                            case MoveType.take:
                                //Do ailment removal function with the needed info

                                break;

                            case MoveType.heal:
                                //Do healing function with the needed info

                                break;

                            case MoveType.timetravel:
                                //travel to turnnumber, current - number or chosen turn

                                break;

                            case MoveType.weather:
                                //

                                break;

                            default:
                                //do nothing when none of above is read

                                break;
                        }
                    }
                }
            }
            //else
            //{
            //    //Console.WriteLine("Character health is death level, if death character can't use move so switch out character");
            //}
        }

        private int getTypeAdventage(Character target, Move move)
        {
            bool isNullified = false;
            int adventageNumber = 0;

            //check types and calculate the accoding adventageNumber
            foreach (Elements element in target.getElements())
            {
                int newAdventageNumber = 0;

                if (isNullified == false)
                {
                    //set local bool


                    switch (move.getElement())
                    {
                        case Elements.Normal:
                            //
                            newAdventageNumber = tac.checkNormalMove(element, adventageNumber);
                            break;

                        case Elements.Fighting:
                            //
                            newAdventageNumber = tac.checkFightingMove(element, adventageNumber);
                            break;

                        default:
                            newAdventageNumber = adventageNumber + 1;
                            break;
                    }

                    //commented can be removed if not gonna be used
                    //checks actions
                    //if (newAdventageNumber == adventageNumber + 2)
                    //{
                    //    //Adventage has been detected
                    //}
                    //else if (newAdventageNumber == adventageNumber + 1)
                    //{
                    //    //Normal has been detected
                    //}
                    //else if (newAdventageNumber == adventageNumber - 2)
                    //{
                    //    //Disadventage has been detected
                    //}
                    //else
                    if (newAdventageNumber == 0 && adventageNumber == 0)
                    {
                        //Starting nullification has been detected
                        adventageNumber = 0;
                        isNullified = true;
                    }
                    else if (newAdventageNumber == 0 && adventageNumber != 0)
                    {
                        //Nullification other then start value has been detected
                        adventageNumber = 0;
                        isNullified = true;
                    }

                    //changes the adventageNumber
                    adventageNumber = newAdventageNumber;
                }
            }

            if (adventageNumber < 0)
            {
                //if only disadventages then adventage of 1
                adventageNumber = 1;
            }

            return adventageNumber;
        }

        public void attack(Character self, Character enemy, Move move)
        {
            //calculate number from move with character stats
            Console.WriteLine("Character self: " + self.getName() + ", amount: " + move.getAmount() + ", isbuildUp = " + move.getBuidUpBoolean());
            //handleOwnAilments(ailmentHandlings.DuringMove);

            for (int i = 0; i <= move.getAmount(); i++)
            {
                //Console.WriteLine("Number of amount is: " + i);
                //get move attack number
                int number = Convert.ToInt32(move.getNumber());

                //advantage calculations
                int adventage = getTypeAdventage(enemy, move);
                number = number + adventage;

                //check target
                if (move.getTarget() == TargetType.self)
                {
                    //number = Convert.ToInt32(move.getNumber());

                    self.getAttackedWithPhysicalDamage(number);

                    string text = "Damage delt to self is: " + number;
                    chat.addSideTurn(text); //is the damage to character from move
                    //updateBothCharacters();
                }
                else if (move.getTarget() == TargetType.single)
                {
                    //check blockage
                    blockTypes bt = enemy.checkBlockDamageTypeAndActive();

                    if (bt == blockTypes.Reversal)
                    {
                        number = number * 2;
                        self.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt because of reversal to self is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                        //chat.addTurn("");
                    }
                    else if (bt == blockTypes.Block)
                    {
                        //nobody gets damage
                        string text = "Damage got blocked";
                        chat.addSideTurn(text); //is the damage to character from move
                    }
                    else
                    {
                        //user attacks, then defence - number is applied if lower or equal to 0 it is 1 because always at least 1 attack
                        enemy.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                        //Console.WriteLine("The " + i + " hit has attacked with " + number);
                    }

                    //updateBothCharacters();
                }
                else if (move.getTarget() == TargetType.enemies)
                {
                    //number = Convert.ToInt32(move.getNumber());

                    //check blockage
                    blockTypes bt = enemy.checkBlockDamageTypeAndActive();

                    if (bt == blockTypes.Reversal)
                    {
                        number = number * 2;
                        self.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt because of reversal to self is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                    }
                    else if (bt == blockTypes.Block)
                    {
                        //nobody gets damage
                        string text = "Damage got blocked";
                        chat.addSideTurn(text); //is the damage to character from move
                    }
                    else
                    {
                        enemy.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                    }

                    
                }
                else if (move.getTarget() == TargetType.all)
                {
                    //number = Convert.ToInt32(move.getNumber());

                    //check blockage
                    blockTypes bt = enemy.checkBlockDamageTypeAndActive();

                    if (bt == blockTypes.Reversal)
                    {
                        number = number * 2;
                        self.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt because of reversal to self is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                    }
                    else if (bt == blockTypes.Block)
                    {
                        //nobody gets damage
                        string text = "Damage got blocked";
                        chat.addSideTurn(text); //is the damage to character from move
                    }
                    else
                    {
                        enemy.getAttackedWithPhysicalDamage(number);

                        string text = "Damage delt is: " + number;
                        chat.addSideTurn(text); //is the damage to character from move
                    }

                    //updateBothCharacters();
                }

                updateBothCharacters();
            }
        }

        public void updateBothCharacters()
        {
            updateEnemyCharacterInfo();
            Application.DoEvents();
            updateOwnCharacterInfo();
            Application.DoEvents();
        }

        //private void handleOwnAilments(ailmentHandlings ah)
        //{
        //    //if no ailments then no need to even loop through this
        //    if (ownChosen.getAilments() != null)
        //    {
        //        //start turn ailment handling
        //        if (ah == ailmentHandlings.StartTurn)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Bleeding:
        //                        //oowchy

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //        //choosing move influences
        //        else if (ah == ailmentHandlings.ChoosingMove)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Taunt:
        //                        //only allows to be attacked/attacking moves

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //        //after chosen but before move ailment handling
        //        else if (ah == ailmentHandlings.BeforeMove)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Paralysed:
        //                        //chance of hit has chance to be 0

        //                        break;

        //                    case Ailments.Asleep:
        //                        //chance of hit is 0 and wake up chance is 1 in 5

        //                        break;

        //                    case Ailments.Bleeding:
        //                        //oowchy

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //        //during move ailment handling
        //        else if (ah == ailmentHandlings.DuringMove)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Bleeding:
        //                        //oowchy

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //        //after move ailment handling
        //        else if (ah == ailmentHandlings.AfterMove)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Bleeding:
        //                        //oowchy

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //        //end turn handling
        //        else if (ah == ailmentHandlings.EndTurn)
        //        {
        //            foreach (Ailments ail in ownChosen.getAilments())
        //            {
        //                switch (ail)
        //                {
        //                    case Ailments.Bleeding:
        //                        //do bleading effect

        //                        break;

        //                    case Ailments.Poisoned:
        //                        //do asleep effect

        //                        break;

        //                    default:
        //                        //do nothing
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //}

        private void handleCharacterAilments(Character character, ailmentHandlings ah)
        {
            //if no ailments then no need to even loop through this
            if (character.getAilments() != null)
            {
                //start turn ailment handling
                if (ah == ailmentHandlings.StartTurn)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Bleeding:
                                //oowchy

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
                //choosing move influences
                else if (ah == ailmentHandlings.ChoosingMove)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Taunt:
                                //only allows to be attacked/attacking moves

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
                //after chosen but before move ailment handling
                else if (ah == ailmentHandlings.BeforeMove)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Paralysed:
                                //chance of hit has chance to be 0

                                break;

                            case Ailments.Asleep:
                                //chance of hit is 0 and wake up chance is 1 in 5

                                break;

                            case Ailments.Bleeding:
                                //oowchy

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
                //during move ailment handling
                else if (ah == ailmentHandlings.DuringMove)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Bleeding:
                                //oowchy

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
                //after move ailment handling
                else if (ah == ailmentHandlings.AfterMove)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Bleeding:
                                //oowchy

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
                //end turn handling
                else if (ah == ailmentHandlings.EndTurn)
                {
                    foreach (Ailments ail in character.getAilments())
                    {
                        switch (ail)
                        {
                            case Ailments.Bleeding:
                                //do bleading effect

                                break;

                            case Ailments.Poisoned:
                                //do asleep effect

                                break;

                            default:
                                //do nothing
                                break;
                        }
                    }
                }
            }
        }

        #region Enable/Dissable attack buttons
        public void dissabler()
        {
            //dissable battlebuttons
            foreach (BattleButton ba in flpAttacks.Controls)
            {
                ba.dissabler();
            }

            //dissable other buttons
            btnChange.Enabled = false;
            btnMoves.Enabled = false;
        }

        public void ennabler()
        {
            //enable battlebuttons
            foreach (BattleButton ba in flpAttacks.Controls)
            {
                ba.enabler();
            }

            //dissable other buttons
            btnChange.Enabled = true;
            btnMoves.Enabled = true;
        }

        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            turn();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //load changeCharacter usercontrolls
            loadCharacters();
        }

        private void loadCharacters()
        {
            flpAttacks.Controls.Clear();

            for(int i = 0; i < ownParty.Count; i++)
            {
                ChangeCharacter cc = new ChangeCharacter(this, ownParty[i], i);
                flpAttacks.Controls.Add(cc);
            }
        }

        private void loadAlternatives()
        {
            flpAttacks.Controls.Clear();

            if (ownChosen.checkIfIsAlternative() == false)
            {
                for (int i = 0; i < ownChosen.getAlternatives().Count(); i++)
                {
                    ChangeAlternative cc = new ChangeAlternative(ownChosen.getAlternatives()[i], this, i);
                    flpAttacks.Controls.Add(cc);
                }
            }
            else
            {
                //load the return to normal mode
                ChangeBackToOriginal cbfa = new ChangeBackToOriginal(this);
                flpAttacks.Controls.Add(cbfa);
            }
        }

        public void changeBackFromAlternative()
        {
            if (ownChosen.checkIfIsAlternative() == true)
            {
                ownChosen.switchToNormalFromAlternative();

                //indicates that a move has been used
                ownHasChanged = true;

                flpAttacks.Controls.Clear();

                //load attack options from character.moves
                loadAttacks();

                updateOwnCharacterInfo();

                //dissable attacks and buttons
                dissabler();

                //set ownMove to true
                settedOwn = true;
            }
        }

        //is move for changing to alternative form
        public void changeOwnAlternativeUsesMove(int index)
        {
            //changes self into alternative form from list
            changeOwnAlternative(index);

            //dissable attacks and buttons
            dissabler();

            //set ownMove to true
            settedOwn = true;
        }

        //is the handling of changing to alternative form
        public void changeOwnAlternative(int index)
        {
            //update the own values from character
            //ownChosen = ownParty[index];
            ownChosen.switchToAlternative(ownChosen.getAlternatives()[index]);

            ownHasChanged = true;

            flpAttacks.Controls.Clear();

            //load attack options from character.moves
            loadAttacks();

            updateOwnCharacterInfo();
        }

        private void btnMoves_Click(object sender, EventArgs e)
        {
            //load attacks
            loadAttacks();
        }

        private void btnAlternatives_Click(object sender, EventArgs e)
        {
            loadAlternatives();
        }

        #region multiplayer handlings

        private void BackgroundWorkerReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                Thread.Sleep(1000);

                if (client.Connected)
                {
                    //client connected

                    //
                    //ReceiveData(clientSave);

                    //
                    List<string> messages = ReceiveData(client);
                    worker.ReportProgress(0, messages);
                }
                else
                {
                    //client not connected/failed
                }
            }
        }

        private void BackgroundWorkerReceiver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<string> messages = (List<string>)e.UserState;

            for (int i = 0; i < messages.Count(); i++)
            {
                //lbChat.Items.Add(messages[i]);
                Application.DoEvents();
            }
        }

        private void backgroundWorkerSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                if (sendedMessage != string.Empty || sendedMessage != "")
                {
                    NetworkStream ns = client.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes(sendedMessage);
                    ns.Write(buffer, 0, buffer.Length);
                }
            }
            else
            {

            }
        }

        private List<string> ReceiveData(TcpClient client)
        {
            try
            {
                List<string> messages = new List<string>();

                if (client.Connected)
                {
                    NetworkStream ns = client.GetStream();

                    //checks if there is data to read from the networkstream
                    if (ns.CanRead)
                    {
                        byte[] receivedBytes = new byte[1024];
                        int byte_count;

                        if ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        {
                            messages.Add(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        }

                        //while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                        //{
                        //    messages.Add(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
                        //}
                    }
                }

                return messages;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        #endregion
    }
}
