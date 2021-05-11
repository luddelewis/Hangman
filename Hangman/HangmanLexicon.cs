using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{

    class HangmanLexicon
    {
        //Picks 3 random words from the file SortedHanglexicon based on their length.
        //Shorter words are considerd harder since they have less letters
        private string WordPicker(string difficulty) 
        {
            Random randomNumber = new Random();
            string word = "";
            //Getting the lexicon
            List<string> lexicon = File.ReadAllLines("../../../LexiconSort/SortedHanglexicon.txt").ToList();
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
