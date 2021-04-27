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
        //Picks 3 random words from the file CookedHanglexicon based on their length.
        private string WordPicker(string difficulty) 
        {
            Random randomNumber = new Random();
            string word = "";
            List<string> lexicon = File.ReadAllLines("../../../LexiconSort/CookedHanglexicon.txt").ToList();
            switch (difficulty)
            {
                case "hard":
                    word = lexicon[randomNumber.Next(0, 540)];
                    break;
                case "medium":
                    word = lexicon[randomNumber.Next(540, 748)];
                    break;
                case "easy":
                    word = lexicon[randomNumber.Next(748, 849)];
                    break;  
            }
            return word;
        }

        public string easyWord { get { return WordPicker("easy"); } }
        public string mediumWord { get { return WordPicker("medium"); } }
        public string hardWord { get { return WordPicker("hard"); } }
    }
}
