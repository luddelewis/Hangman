using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{

    class WordGenerator
    {
        private string WordPicker(string difficulty) 
        {
            Random rand = new Random();
            string word = "";
            List<string> lexicon = File.ReadAllLines("../../../LexiconSort/CookedHanglexicon.txt").ToList();
            switch (difficulty)
            {
                case "easy":
                    word = lexicon[rand.Next(0, 540)];
                    break;
                case "medium":
                    word = lexicon[rand.Next(540, 748)];
                    break;
                        case "hard":
                    word = lexicon[rand.Next(748, 849)];
                    break;  
            }
            return word;
        }

        public string easyWord { get { return WordPicker("easy"); } }
        public string mediumWord { get { return WordPicker("medium"); } }
        public string HardWord { get { return WordPicker("hard"); } }
    }
}
