using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class SettingsValues
    {
        //make this a singleton
        //thread safety singleton
        private static SettingsValues instance = null;
        private static readonly object padlock = new object();

        //settings variables
        string path = Functions.getSettingsPath() + "Settings.txt";
        public IPAddress ip { get; set; }
        public int port { get; set; }

        private SettingsValues()
        {
            loadSettingsFromFile();
        }

        /// <summary>
        /// singleton method
        /// </summary>
        public static SettingsValues Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SettingsValues();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// loads the variables from the file
        /// </summary>
        private void loadSettingsFromFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    //load from file
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Count() != 0)
                    {
                        // Display the file contents by using a foreach loop.
                        foreach (string line in lines)
                        {
                            string[] splitted = line.Split('-');
                            ip = IPAddress.Parse(splitted[0]);
                            port = Convert.ToInt32(splitted[1]);
                        }
                    }
                    else
                    {
                        loadDefaults();
                    }
                }
                else
                {
                    File.Create(path).Close();
                    loadSettingsFromFile();
                }
            }
            catch (Exception ex)
            {
                loadDefaults();
            }
        }

        private void loadDefaults()
        {
            string settings = "127.0.0.1" + "-" + "5000" + "";

            //add the list items
            File.WriteAllText(path, settings);

            loadSettingsFromFile();
        }

        /// <summary>
        /// Updates the file using the variables
        /// </summary>
        public void updateFileFromLocals()
        {
            try
            {
                //settings line should look kinda like:
                //true-...-...-(etc)
                string settings = ip + "-" + port;

                //add the list items
                File.WriteAllText(path, settings);
            }
            catch (Exception ex)
            {

            }
        }

        //then make all values get set values for easier set and getting the values
    }
}
