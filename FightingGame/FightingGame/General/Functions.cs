using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightingGame
{
    public abstract class Functions
    {
        //current project
        private static string binFolder = Environment.CurrentDirectory; //the bin debug folder
        private static string projectDir = Directory.GetParent(binFolder).Parent.FullName; //the plantpal/plantpal/ folder
        private static string gameFolder = projectDir + "\\GameFolder\\"; //the videos folder
        private static string ownedCharactersFolder = gameFolder + "OwnedCharacters\\"; //the setting folder
        private static string storiesFolder = gameFolder + "Stories\\";

        public static string getGameFolder()
        {
            return gameFolder;
        }

        public static string getOwnedFolder()
        {
            return ownedCharactersFolder;
        }

        public static string getStoriesFolder()
        {
            return storiesFolder;
        }

        public static string getHiddenCharacterFolder()
        {
            string hiddenFolder = gameFolder + "HiddenCharacter\\";
            return hiddenFolder;
        }

        public static string getSettingsPath()
        {
            string SettingsPath = gameFolder + "Settings\\";
            return SettingsPath;
        }

        /// <summary>
        /// This function needs the current form to get to the MainForm it is connected to.
        /// </summary>
        /// <param name="self">Here the control (this) will be used to get the MainForm</param>
        /// <returns></returns>
        public static MainForm getMainForm(Control self)
        {
            try
            {
                //
                Control parent = self.Parent;

                //loop though if there is a parent in the current control, if so then
                //it is not the homepage yet so keep looping and using the parent if there was one
                while (true)
                {
                    if (parent.Parent != null)
                    {
                        parent = parent.Parent;
                    }
                    else
                    {
                        break;
                    }
                }
                MainForm main = parent as MainForm;
                return main;
            }
            catch (Exception ex)
            {
                return new MainForm();
            }
        }

        #region local alternative character readings

        public static List<AlternativeCharacter> loadAlternativesFromPath(string baseCharacterPath, string path)
        {
            //foreach folder within the alternative folder
            List<AlternativeCharacter> alternativeForms = new List<AlternativeCharacter>(); //fill this list with the characters

            //checks if alternative folder exists
            if (Directory.Exists(path))
            {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    //string folder = the alternative path within owned character

                    //get base path as string, use baseAlternativePath as image ref and folder as data ref
                    //string altName = Path.GetFileName(folder); //get name from path
                    string baseAlternativePath = baseCharacterPath + "Alternative\\" + Path.GetFileName(folder) + "\\";

                    //Console.WriteLine(baseAlternativePath);

                    //search the folder structure and use these info to get the data
                    //do the json reading etc here
                    AlternativeCharacter character = GetAlternativeCharacter(folder, baseAlternativePath);
                    alternativeForms.Add(character);
                }
            }

            return alternativeForms;
        }

        public static AlternativeCharacter GetAlternativeCharacter(string alternativePath, string basePath)
        {
            //get files and directories
            //string dataPath = alternativePath + "\\Data\\";
            string[] Files = Directory.GetFiles(alternativePath);
            string[] Directories = Directory.GetDirectories(alternativePath);

            string informationFile = string.Empty;
            string effectsFile = string.Empty;
            string statsFile = string.Empty;
            string movesFolder = string.Empty;

            List<MoveList> moveList = new List<MoveList>();
            Moves moves = new Moves();

            //loop through all files
            foreach (string file in Files)
            {
                FileInfo f = new FileInfo(file);

                if (f.Name == "Information.json")
                {
                    informationFile = file;
                }
                else if (f.Name == "Effects.json")
                {
                    effectsFile = file;
                }
                else if (f.Name == "Stats.json")
                {
                    statsFile = file;
                }
            }

            //
            if (Directories.Count() > 0)
            {
                foreach (string file in Directories)
                {
                    DirectoryInfo f = new DirectoryInfo(file);

                    if (f.Name == "Moves")
                    {
                        movesFolder = file;
                    }
                }
            }
            else
            {
                //use the official move spawnlist from the basePath
            }

            //fill moveList
            string[] moveDir = Directory.GetFiles(movesFolder);

            foreach (string movePath in moveDir)
            {

                MoveList moveFile = JsonConvert.DeserializeObject<MoveList>(File.ReadAllText(movePath));
                moveList.Add(moveFile);
            }

            //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(jsonFile));
            AlternativeInfo info = JsonConvert.DeserializeObject<AlternativeInfo>(File.ReadAllText(informationFile));
            Effects effects = JsonConvert.DeserializeObject<Effects>(File.ReadAllText(effectsFile));
            Stats stats = JsonConvert.DeserializeObject<Stats>(File.ReadAllText(statsFile));
            moves.moves = moveList;

            //string baseCharacterPath = Functions.getStoriesFolder() + info.series + "\\Characters\\" + info.uniqueName + "\\"; //path where base info is stored

            //MessageBox.Show(baseCharacterPath);

            AlternativeCharacter character = new AlternativeCharacter(effects, info, moves, stats, basePath);
            return character;
        }

        #endregion

        public static Character getCharacterFromTCP(string tcp)
        {
            //read all values from the tcp character

            //split tcp into multiple strings on the characteristics like info, effects, moves and stats and handle that string 

            return null;
        }

        public static Character getCharacterFromTCP(List<string> commands)
        {
            //read all values from the tcp character
            //character values
            Effects effects = null;
            Info info = null;
            Moves moves = null;
            Stats stats = null;

            List<AlternativeCharacter> alternativeForms = new List<AlternativeCharacter>();

            //reader values
            int start = -1;
            int end = -1;
            string characterPart = "";

            for (int i = 0; i < commands.Count(); i++)
            {
                string currentRead = commands[i];

                if (currentRead == "<chareffects>" && characterPart == "")
                {
                    characterPart = "effects";
                    start = i;
                }
                else if (currentRead == "</chareffects>" && characterPart == "effects")
                {
                    end = i;
                }

                if (currentRead == "<charinfo>" && characterPart == "")
                {
                    characterPart = "info";
                    start = i;
                }
                else if (currentRead == "</charinfo>" && characterPart == "info")
                {
                    end = i;
                }

                if (currentRead == "<charmoves>" && characterPart == "")
                {
                    characterPart = "moves";
                    start = i;
                }
                else if (currentRead == "</charmoves>" && characterPart == "moves")
                {
                    end = i;
                }

                if (currentRead == "<charstats>" && characterPart == "")
                {
                    characterPart = "stats";
                    start = i;
                }
                else if (currentRead == "</charstats>" && characterPart == "stats")
                {
                    end = i;
                }

                if (currentRead == "<altlist>" && characterPart == "")
                {
                    characterPart = "alternative";
                    start = i;
                }
                else if (currentRead == "</altlist>" && characterPart == "alternative")
                {
                    end = i;
                }

                if (start != -1 && end != -1)
                {
                    //found two searchPoints
                    List<string> lister = new List<string>();

                    //loop through that specific point
                    for (int counter = start; counter < end; counter++)
                    {
                        string current = commands[counter];
                        lister.Add(current);
                    }

                    //give list and characterPart to function
                    if (characterPart == "effects")
                    {
                        effects = getEffectsFromTCP(lister);
                    }
                    else if (characterPart == "info")
                    {
                        info = getInfoFromTCP(lister);
                    }
                    else if (characterPart == "moves")
                    {
                        moves = getMovesFromTCP(lister);
                    }
                    else if (characterPart == "stats")
                    {
                        stats = getStatsFromTCP(lister);
                    }
                    else if (characterPart == "alternative")
                    {
                        //handle one or more alternative characters
                        alternativeForms = getAlternativesFromTCP(lister);
                    }

                    //reset the indexers
                    start = -1;
                    end = -1;
                    characterPart = "";
                }
            }

            //search stories folder if story/character exist else choose standarized folder for characters that do not exist
            //aka default or hidden character folder

            Character character = new Character(info, stats, moves, effects, alternativeForms, true);

            return character;
        }

        public static Effects getEffectsFromTCP(List<string> parts)
        {
            Effects effects = new Effects();

            //read the <effects></effects> commands
            int start = -1;
            int end = -1;
            string variable = "";

            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];

                if (part.Contains("<buffhealth>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 25;
                    variable = part.Substring(12, amount);
                    effects.buffHealth = Convert.ToInt32(variable);
                }
                else if (part.Contains("<buffattack>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 25;
                    variable = part.Substring(12, amount);
                    effects.buffAttackLevel = Convert.ToInt32(variable);
                }
                else if (part.Contains("<buffdefence>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 27;
                    variable = part.Substring(13, amount);
                    effects.buffDefenceLevel = Convert.ToInt32(variable);
                }
                else if (part.Contains("<buffmagicattack>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 35;
                    variable = part.Substring(17, amount);
                    effects.buffMagicAttackLevel = Convert.ToInt32(variable);
                }
                if (part.Contains("<buffmagicdefence>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 37;
                    variable = part.Substring(18, amount);
                    effects.buffMagicDefenceLevel = Convert.ToInt32(variable);
                }
                else if (part.Contains("<buffspeed>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 23;
                    variable = part.Substring(11, amount);
                    effects.buffSpeed = Convert.ToInt32(variable);
                }
                else if (part.Contains("<buffevasiveness>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 35;
                    variable = part.Substring(17, amount);
                    effects.buffEvasiveness = Convert.ToInt32(variable);
                }
                else if (part.Contains("<clonesamount>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 29;
                    variable = part.Substring(14, amount);
                    effects.clonesAmount = Convert.ToInt32(variable);
                }

                //ailemt checking
                else if (part == "<ailments>")
                {
                    start = i;
                }
                else if (part == "</ailments>")
                {
                    end = i;
                }

                //loop for ailments
                if (start != -1 && end != -1)
                {
                    List<Ailments> lister = new List<Ailments>();

                    //checks if there is at least one ailment
                    if (start != end - 1)
                    {
                        for (int teller = start + 1; teller < end - 1; teller++)
                        {
                            int amount = part.Count() - 17;
                            string current = parts[teller].Substring(8, amount);

                            Ailments option = (Ailments)Enum.Parse(typeof(Ailments), current);

                            lister.Add(option);
                        }
                    }

                    //set ailment list
                    effects.ailments = lister;
                }
            }

            return effects;
        }

        public static Info getInfoFromTCP(List<string> parts)
        {
            //read the <charinfo></charinfo> commands
            Info info = new Info();

            int start = -1;
            int end = -1;
            string variable = "";

            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];

                if (part.Contains("<level>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 15;
                    variable = part.Substring(7, amount);
                    info.level = Convert.ToInt32(variable);
                }
                else if (part.Contains("<evolutionlevel>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 33;
                    variable = part.Substring(16, amount);
                    info.evolutionLevel = Convert.ToInt32(variable);
                }
                else if (part.Contains("<uniquename>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 25;
                    variable = part.Substring(12, amount);
                    info.uniqueName = variable;
                }
                else if (part.Contains("<series>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 17;
                    variable = part.Substring(8, amount);
                    info.series = variable;
                }
                if (part.Contains("<name>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 13;
                    variable = part.Substring(6, amount);
                    info.name = variable;
                }
                else if (part.Contains("<maxhealth>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 23;
                    variable = part.Substring(11, amount);
                    info.maxHealth = Convert.ToInt32(variable);
                }
                else if (part.Contains("<currenthealth>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 31;
                    variable = part.Substring(15, amount);
                    info.currentHealth = Convert.ToInt32(variable);
                }

                //ailemt checking
                else if (part == "<elements>")
                {
                    start = i;
                }
                else if (part == "</elements>")
                {
                    end = i;
                }

                //loop for ailments
                if (start != -1 && end != -1)
                {
                    List<Elements> lister = new List<Elements>();

                    //checks if there is at least one ailment
                    if (start != end - 1)
                    {
                        for (int teller = start + 1; teller < end - 1; teller++)
                        {
                            string chosenPart = parts[teller];
                            int amount = chosenPart.Count() - 17;
                            string current = chosenPart.Substring(8, amount);

                            Elements option = (Elements)Enum.Parse(typeof(Elements), current);

                            lister.Add(option);
                        }
                    }

                    //set ailment list
                    info.elements = lister;
                }
            }

            return info;
        }

        public static AlternativeInfo getAlternativeInfoFromTCP(List<string> parts)
        {
            //read the <charinfo></charinfo> commands
            AlternativeInfo info = new AlternativeInfo();

            int start = -1;
            int end = -1;
            string variable = "";

            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];

                if (part.Contains("<uniquename>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 27;
                    variable = part.Substring(13, amount);
                    info.uniqueName = variable;
                }
                else if (part.Contains("<series>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 17;
                    variable = part.Substring(8, amount);
                    info.series = variable;
                }
                else if (part.Contains("<maxhealth>"))
                {
                    //remove the <buffhealth> tags from the part string and then set the buffhealth from this
                    int amount = part.Count() - 23;
                    variable = part.Substring(11, amount);
                    info.maxHealth = Convert.ToInt32(variable);
                }

                //ailemt checking
                else if (part == "<elements>")
                {
                    start = i;
                }
                else if (part == "</elements>")
                {
                    end = i;
                }

                //loop for ailments
                if (start != -1 && end != -1)
                {
                    List<Elements> lister = new List<Elements>();

                    //checks if there is at least one element
                    if (start != end - 1)
                    {
                        for (int teller = start + 1; teller < end - 1; teller++)
                        {
                            string chosenPart = parts[teller];
                            int amount = chosenPart.Count() - 17;
                            string current = chosenPart.Substring(8, amount);

                            Elements option = (Elements)Enum.Parse(typeof(Elements), current);

                            lister.Add(option);
                        }
                    }

                    //set ailment list
                    info.elements = lister;
                }
            }

            return info;
        }

        public static Moves getMovesFromTCP(List<string> parts)
        {
            //read the <charmoves></charmoces> commands
            Moves moves = new Moves();
            List<MoveList> movelists = new List<MoveList>();
            //string name, int amount, int priority, int accuracy, Elements elements, List<Move> moves

            int start = -1;
            int end = -1;

            //loop for collection
            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];
                
                //ailemt checking
                if (part == "<movelist>")
                {
                    start = i;
                }
                else if (part == "</movelist>")
                {
                    end = i;
                }

                //loop for found movelist(s)
                if (start != -1 && end != -1)
                {
                    //checks if there is at least one movelist
                    if (start != end - 1)
                    {
                        //string name, int amount, int priority, int accuracy, Elements elements, List<Move> moves
                        string name = "";
                        int amount = -1;
                        int priority = -1;
                        int accuracy = -1;
                        Elements elements = Elements.Normal;
                        List<Move> moveList = new List<Move>();

                        //loop function data
                        string variable = "";
                        int startpos = -1;
                        int endpos = -1;

                        //loop for movelist info
                        for (int teller = start + 1; teller <= end - 1; teller++)
                        {
                            //get the information from the current list reading all the values
                            string subpart = parts[teller];

                            if (subpart.Contains("<name>"))
                            {
                                int countNumber = subpart.Count() - 13;
                                variable = subpart.Substring(6, countNumber);
                                name = variable;
                            }
                            else if (subpart.Contains("<maxamount>"))
                            {
                                int countNumber = subpart.Count() - 23;
                                variable = subpart.Substring(11, countNumber);
                                amount = Convert.ToInt32(variable);
                            }
                            else if (subpart.Contains("<priority>"))
                            {
                                int countNumber = subpart.Count() - 21;
                                variable = subpart.Substring(10, countNumber);
                                priority = Convert.ToInt32(variable);
                            }
                            else if (subpart.Contains("<accuracy>"))
                            {
                                int countNumber = subpart.Count() - 21;
                                variable = subpart.Substring(10, countNumber);
                                accuracy = Convert.ToInt32(variable);
                            }
                            else if (subpart.Contains("<element>"))
                            {
                                int countNumber = subpart.Count() - 19;
                                variable = subpart.Substring(9, countNumber);
                                elements = (Elements)Enum.Parse(typeof(Elements), variable);
                            }
                            else if (subpart == "<moves>")
                            {
                                //get startpos from subpart
                                startpos = teller;
                            }
                            else if (subpart == "</moves>")
                            {
                                //get endpos from subpart
                                endpos = teller;
                            }

                            if (startpos != -1 && endpos != -1)
                            {
                                //check if there is at least something to loop for
                                if (startpos != endpos -1)
                                {
                                    //loop for <move></move> tags

                                    //Local data
                                    int StartMoveTag = -1;
                                    int EndMoveTag = -1;

                                    //loop for move(s) data to find if there is a move and add that move to the list
                                    for (int startPosition = startpos; startPosition < endpos - 1; startPosition++)
                                    {
                                        string loopRes = parts[startPosition];
                                        if (loopRes.Contains("<move>"))
                                        {
                                            StartMoveTag = startPosition;
                                        }
                                        else if (loopRes.Contains("</move>"))
                                        {
                                            EndMoveTag = startPosition;
                                        }

                                        if (StartMoveTag != -1 && EndMoveTag != -1)
                                        {
                                            if (StartMoveTag != EndMoveTag -1)
                                            {
                                                //loop for all moves within this positioning
                                                MoveType type = MoveType.none;
                                                TargetType target = TargetType.none;
                                                Elements element = Elements.Normal;
                                                string number = "";
                                                string chosen = "";
                                                string isbuildup = "";
                                                int turns = -1;
                                                int moveamount = -1;

                                                //loops for the move data for list that will be given to movelist
                                                for (int teller2 = StartMoveTag; teller2 < EndMoveTag; teller2++)
                                                {
                                                    //retrieve move and add it to the movelist
                                                    string currentString = parts[teller2];
                                                    if (currentString.Contains("<type>"))
                                                    {
                                                        int countNumber = currentString.Count() - 13;
                                                        variable = currentString.Substring(6, countNumber);
                                                        type = (MoveType)Enum.Parse(typeof(MoveType), variable);
                                                    }
                                                    else if (currentString.Contains("<target>"))
                                                    {
                                                        int countNumber = currentString.Count() - 17;
                                                        variable = currentString.Substring(8, countNumber);
                                                        target = (TargetType)Enum.Parse(typeof(TargetType), variable);
                                                    }
                                                    else if (currentString.Contains("<element>"))
                                                    {
                                                        int countNumber = currentString.Count() - 19;
                                                        variable = currentString.Substring(9, countNumber);
                                                        element = (Elements)Enum.Parse(typeof(Elements), variable);
                                                    }
                                                    else if (currentString.Contains("<number>"))
                                                    {
                                                        int countNumber = currentString.Count() - 17;
                                                        variable = currentString.Substring(8, countNumber);
                                                        number = variable;
                                                    }
                                                    else if (currentString.Contains("<chosen>"))
                                                    {
                                                        int countNumber = currentString.Count() - 17;
                                                        variable = currentString.Substring(8, countNumber);
                                                        chosen = variable;
                                                    }
                                                    else if (currentString.Contains("<isbuildupturns>"))
                                                    {
                                                        int countNumber = currentString.Count() - 33;
                                                        variable = currentString.Substring(16, countNumber);
                                                        isbuildup = variable;
                                                    }
                                                    else if (currentString.Contains("<turns>"))
                                                    {
                                                        int countNumber = currentString.Count() - 15;
                                                        variable = currentString.Substring(7, countNumber);
                                                        turns = Convert.ToInt32(variable);
                                                    }
                                                    else if (currentString.Contains("<amount>"))
                                                    {
                                                        int countNumber = currentString.Count() - 17;
                                                        variable = currentString.Substring(8, countNumber);
                                                        moveamount = Convert.ToInt32(variable);
                                                    }
                                                }

                                                if (type != MoveType.none && target != TargetType.none && moveamount != -1)
                                                {
                                                    Move move = new Move(type, target, element, number, chosen, isbuildup, turns, moveamount);
                                                    //Console.WriteLine(move);
                                                    moveList.Add(move);
                                                }
                                            }
                                        }
                                    }

                                    //reset the move searcher
                                    startpos = -1;
                                    endpos = -1;
                                }
                            }

                            //int amount = part.Count() - 17;
                            //string current = parts[teller].Substring(8, amount);
                        }

                        //add all variables to movelist
                        MoveList movelist = new MoveList(name, amount, priority, accuracy, elements, moveList);
                        movelists.Add(movelist);

                        Console.WriteLine("amount of elements in movelist is: " + moveList.Count());

                        //clear the Move list for move handling
                        //moveList.Clear();
                    }

                    //reset the movelist class counters
                    start = -1;
                    end = -1;
                }
            }

            
            moves.moves = movelists;

            return moves;
        }

        public static Stats getStatsFromTCP(List<string> parts)
        {
            //read the <charstats></charstats> commands and create a new stats using 
            Stats stats = new Stats();

            //get info through looping
            for (int i = 0; i < parts.Count(); i++)
            {
                string currentString = parts[i];

                if (currentString.Contains("<attack>"))
                {
                    int countNumber = currentString.Count() - 17;
                    stats.attack = Convert.ToInt32(currentString.Substring(8, countNumber));
                }
                else if (currentString.Contains("<defence>"))
                {
                    int countNumber = currentString.Count() - 19;
                    stats.defence = Convert.ToInt32(currentString.Substring(9, countNumber));
                }
                else if (currentString.Contains("<magicattack>"))
                {
                    int countNumber = currentString.Count() - 27;
                    stats.magicAttack = Convert.ToInt32(currentString.Substring(13, countNumber));
                }
                else if (currentString.Contains("<magicdefence>"))
                {
                    int countNumber = currentString.Count() - 29;
                    stats.magicDefense = Convert.ToInt32(currentString.Substring(14, countNumber));
                }
                else if (currentString.Contains("<speed>"))
                {
                    int countNumber = currentString.Count() - 15;
                    stats.speed = Convert.ToInt32(currentString.Substring(7, countNumber));
                }
                else if (currentString.Contains("<evasiveness>"))
                {
                    int countNumber = currentString.Count() - 27;
                    stats.evasiveness = Convert.ToInt32(currentString.Substring(13, countNumber));
                }
                else if (currentString.Contains("<accuracy>"))
                {
                    int countNumber = currentString.Count() - 21;
                    stats.accuracy = Convert.ToInt32(currentString.Substring(10, countNumber));
                }
            }

            //return stats
            return stats;
        }

        public static List<AlternativeCharacter> getAlternativesFromTCP(List<string> parts)
        {
            List<AlternativeCharacter> alternatives = new List<AlternativeCharacter>();

            //do stuff
            int start = -1;
            int end = -1;

            for(int i = 0; i < parts.Count(); i++)
            {
                string currentPart = parts[i];
                if (currentPart == "<altcharacter>")
                {
                    start = i;
                }
                else if (currentPart == "</altcharacter>")
                {
                    end = i;
                }

                //handle alternative character reading
                if (start != -1 && end != -1)
                {
                    //loop through the start / end index from parts and retrieve the alternative info
                    //and create a alternative from that
                    List<string> altCharacterParts = new List<string>();

                    //loop through alt character and fill list for only <alt>reader
                    for (int teller = start; teller < end; teller++)
                    {
                        altCharacterParts.Add(parts[teller]);
                    }

                    //give list to function and add alt to list
                    AlternativeCharacter alternative = getAlternativeFromParts(altCharacterParts);
                    alternatives.Add(alternative);
                }
            }

            return alternatives;
        }

        public static AlternativeCharacter getAlternativeFromParts(List<string> parts)
        {
            //variable setters
            Effects effects = new Effects();
            AlternativeInfo info = new AlternativeInfo();
            Stats stats = new Stats();
            Moves moves = new Moves();

            //loop variables
            int start = -1;
            int end = -1;
            string subject = "";

            //loop through parts
            for (int i = 0; i < parts.Count(); i++)
            {
                string current = parts[i];

                if (current == "<chareffects>")
                {
                    subject = "effects";
                    start = i;
                }
                else if (current == "</chareffects>")
                {
                    end = i;
                }
                if (current == "<altcharinfo>")
                {
                    subject = "info";
                    start = i;
                }
                else if (current == "</altcharinfo>")
                {
                    end = i;
                }
                if (current == "<charstats>")
                {
                    subject = "stats";
                    start = 1;
                }
                else if (current == "</charstats>")
                {
                    end = i;
                }
                if (current == "<charmoves>")
                {
                    subject = "moves";
                    start = i;
                }
                else if (current == "</charmoves>")
                {
                    end = i;
                }

                //loop through options
                if (start != -1 && end != -1)
                {
                    //fill giver list
                    List<string> giveList = new List<string>();

                    for (int j = start; j < end; j++)
                    {
                        string givePart = parts[j];
                        giveList.Add(givePart);
                    }

                    if (subject == "effects")
                    {
                        //handle effects
                        effects = getEffectsFromTCP(giveList);
                    }
                    else if (subject == "info")
                    {
                        //handle info
                        info = getAlternativeInfoFromTCP(giveList);
                    }
                    else if (subject == "stats")
                    {
                        //handle stats
                        stats = getStatsFromTCP(giveList);
                    }
                    else if (subject == "moves")
                    {
                        //handle moves
                        moves = getMovesFromTCP(giveList);
                    }

                    //reset values after the loop/value set
                    start = -1;
                    end = -1;
                    subject = "";
                }
            }

            AlternativeCharacter alternative = new AlternativeCharacter(effects, info, moves, stats);

            return alternative;
        }

        /// <summary>
        /// DO NOT TOUCH!!!!!!! Reads the given string and splits it based on < > / and combination within the three fitting the tcp method i created
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static List<string> readFromChars(string character)
        {
            List<string> commands = new List<string>();

            bool starter = true;
            string current = "";

            char[] chars = character.ToCharArray();
            for (int i = 0; i < chars.Count(); i++)
            {
                char c = chars[i];
                char future = (char)0;
                char futureExtra = (char)0;

                if (chars.Count() > i + 2)
                {
                    future = chars[i + 1];
                    futureExtra = chars[i + 2];
                }
                else
                {
                    if (chars.Count() > i + 1)
                    {
                        future = chars[i + 1];
                        futureExtra = (char)0;
                    }
                    else
                    {
                        future = (char)0;
                        futureExtra = (char)0;
                    }
                }

                if (c == '<' && starter == false && future != '/' && future != (char)0)
                {
                    //detects the true start command
                    starter = true;
                    current = c.ToString();
                }
                else if (c == '<' && starter == false && future == '/' && future != (char)0)
                {
                    //detects the true end command
                    starter = false;
                    current += c.ToString();
                }
                else if (c == '<' && starter == true && future != '/' && future != (char)0)
                {
                    //detects duplicate start like <character><info>
                    if (current != string.Empty)
                    {
                        commands.Add(current);
                    }

                    current = c.ToString();
                }
                else if (c == '>' && starter == false && future == '<' && futureExtra != '/' && future != (char)0 && futureExtra != (char)0)
                {
                    //detects the true end of command
                    current += c;
                    commands.Add(current);
                }
                else if (c == '>' && starter == false && future == '<' && futureExtra == '/' && future != (char)0 && futureExtra != (char)0)
                {
                    //detects end command after end command
                    commands.Add(current);
                    current = c.ToString();
                    starter = false;
                }
                else if (c == '>' && starter == true && future == '<' && futureExtra == '/' && future != (char)0 && futureExtra != (char)0)
                {
                    //detects the true end of command
                    current += c;
                    commands.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            return commands;
        }

        /// <summary>
        /// Getting the color from the element, using for backgrounds etc
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Color getColorFromElementType(Elements element)
        {
            if (element == Elements.Normal)
            {
                return Color.Gray;
            }

            return Color.White;
        }

        public static List<Character> getAllOwnedCharacters()
        {
            List<Character> lister = new List<Character>();

            //do stuff


            //fill AllAvailableOptions
            //foreach folder in the ownedcharacter map, use the paths and loop through it

            string[] dirs = Directory.GetDirectories(Functions.getOwnedFolder());
            foreach (string path in dirs)
            {
                Character character = loadedCharacterFromMultipleFilesFromPath(path);
                //CharacterInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterInfo>(s + "\\Data\\" + "info.json");

                //AllAvailabeOptions.Add(new Character(s, info, stats, moves, null));
                //enemyParty.Add(new Character(info, stats, moves, null));
                //ownParty.Add(new Character(info, stats, moves, null));

                lister.Add(character);
            }

            return lister;
        }

        private static Character loadedCharacterFromMultipleFilesFromPath(string path)
        {
            //get files and directories
            string dataPath = path + "\\Data\\";
            string[] Files = Directory.GetFiles(dataPath);
            string[] Directories = Directory.GetDirectories(dataPath);

            string informationFile = string.Empty;
            string effectsFile = string.Empty;
            string statsFile = string.Empty;
            string movesFolder = string.Empty;

            List<MoveList> moveList = new List<MoveList>();
            Moves moves = new Moves();

            //loop through all files
            foreach (string file in Files)
            {
                FileInfo f = new FileInfo(file);

                if (f.Name == "Information.json")
                {
                    informationFile = file;
                }
                else if (f.Name == "Effects.json")
                {
                    effectsFile = file;
                }
                else if (f.Name == "Stats.json")
                {
                    statsFile = file;
                }
            }

            //
            foreach (string file in Directories)
            {
                DirectoryInfo f = new DirectoryInfo(file);

                if (f.Name == "Moves")
                {
                    movesFolder = file;
                }
            }

            //fill moveList
            string[] moveDir = Directory.GetFiles(movesFolder);

            foreach (string movePath in moveDir)
            {

                MoveList moveFile = JsonConvert.DeserializeObject<MoveList>(File.ReadAllText(movePath));
                moveList.Add(moveFile);
            }

            //Character character = JsonConvert.DeserializeObject<Character>(File.ReadAllText(jsonFile));
            Info info = JsonConvert.DeserializeObject<Info>(File.ReadAllText(informationFile));
            Effects effects = JsonConvert.DeserializeObject<Effects>(File.ReadAllText(effectsFile));
            Stats stats = JsonConvert.DeserializeObject<Stats>(File.ReadAllText(statsFile));
            moves.moves = moveList;

            //character from stories folder path
            string storiesFolder = Functions.getStoriesFolder() + info.series + "\\Characters\\" + info.uniqueName + "\\"; //path where base info is stored

            string owned = path + "\\Data\\";

            //loads alternative modes
            string alternativePath = path + "\\Alternative\\";
            List<AlternativeCharacter> alternativeForms = Functions.loadAlternativesFromPath(storiesFolder, alternativePath);

            Character character = new Character(info, stats, moves, effects, alternativeForms, false, storiesFolder);
            return character;
        }
    }
}
