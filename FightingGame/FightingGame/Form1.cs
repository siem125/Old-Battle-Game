using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FightingGame
{
    public partial class Form1 : Form
    {
        List<Character> ownParty;
        List<Character> enemyParty;

        List<Character> AllAvailabeOptions;

        string characterPaths = "";

        public Form1()
        {
            InitializeComponent();

            //load characters and create own and enemy party
            ownParty = new List<Character>();
            enemyParty = new List<Character>();
            AllAvailabeOptions = new List<Character>();


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

                AllAvailabeOptions.Add(character);
            }
        }

        private Character loadedCharacterFromMultipleFilesFromPath(string path)
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

        private void btnFillParty_Click(object sender, EventArgs e)
        {
            List<List<string>> tcpRecievedCharacters = new List<List<string>>();

            foreach (Character character in AllAvailabeOptions)
            {
                string charc = character.getTCPFormat();
                List<string> commands = Functions.readFromChars(charc);

                ownParty.Add(new Character(character));

                //simulate populating list from tcp
                tcpRecievedCharacters.Add(commands);
            }

            //simulate recreating characters from tcp retrieval
            foreach (List<string> splitedChar in tcpRecievedCharacters)
            {
                //do the reading from splitted string event to get character
                Character tcped = Functions.getCharacterFromTCP(splitedChar);
                enemyParty.Add(tcped);
            }

            btnBattle.Enabled = true;
        }

        private void btnBattle_Click(object sender, EventArgs e)
        {
            BattleArena ba = new BattleArena(ownParty, enemyParty);
            Functions.getMainForm(this).openChildForm(ba);
        }
    }
}
