using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Drawing.Text;

namespace Hangman
{
    public partial class Hangman : Form
    {
        public string difficulty;
        public int guessesLeft = 8;
        public string hiddenWord = "";
        
        public Hangman()
        {
            InitializeComponent();
        }
        //Event that happens when program is started
        private void Hangman_Load(object sender, EventArgs e)
        {
            //Moves the panels to their correct locations
            //They are moved to the side in the desinger so they don't cover everything
            winPanel.Location = new Point(12, 323);
            menuPanel.Location = new Point(15, 12);
            gameoverPanel.Location = new Point(12, 323);
            //Creates a pfc
            PrivateFontCollection pfc = new PrivateFontCollection();
            //Adds the font to it
            pfc.AddFontFile("../../digital-7 (mono).ttf");
            //Loops through all controls of the form and changes font to the custom one
            foreach(Control ctrl in this.Controls)
            {
                ctrl.Font = new Font(pfc.Families[0], ctrl.Font.Size, FontStyle.Regular);
            }
            //Loops throgh panels and their controls and changes font since this.controls does not include controls in panels
            foreach(Panel panel in Controls.OfType<Panel>())
            {
                foreach(Control ctrl in panel.Controls)
                {
                    ctrl.Font = new Font(pfc.Families[0], ctrl.Font.Size, FontStyle.Regular);
                }
            }

        }
        private void difficultyBtn_Click(object sender, EventArgs e)
        {
            difficulty = ((Button)sender).Text.ToLower();
            menuPanel.Enabled = false;
            menuPanel.Hide();
            Startup();
        }
        private void restartBtn_Click(object sender, EventArgs e)
        {
            //Resets the font if it changes for some obscure reason
            Hangman_Load(sender, null);
            //resets the game
            menuPanel.Enabled = true;
            menuPanel.Show();
            gameoverPanel.Hide();
            winPanel.Hide();
            guessesLeftLabel.Text = "Guesses left: 8";
            hiddenWord = "";
            //Makes potential hidden buttons visible
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Visible = true;
            }
        }
        //Function for starting and resetting the game
        private void Startup()
        {
            //Resetting from possible previous plays
            wordDisplay.Text = "";
            guessesLeft = 8;
            pictureBox.Image = Properties.Resources._8;
            //Get a word from the Hangmanlexicon class
            HangmanLexicon getWord = new HangmanLexicon();
            switch (difficulty)
            {
                case "easy":
                    hiddenWord = getWord.easyWord;
                    break;
                case "medium":
                    hiddenWord = getWord.mediumWord;
                    break;
                case "hard":
                    hiddenWord = getWord.hardWord;
                    break;
            }
            //Displays a "_" for each letter in the word
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                wordDisplay.Text += "_";
            }
        }
        //Event for  keyboard input
        private void Hangman_KeyPress(object sender, KeyPressEventArgs pressedKey)
        {
            //Checks if the pressed key is letter
            if (char.IsLetter(pressedKey.KeyChar) && hiddenWord != "")
            {
                //Feeds GuessChecker the guessed letter
                GuessChecker(char.ToUpper(pressedKey.KeyChar));
            }

        }
        //Event for on clickable on screen buttons
        private void LetterClick(object pressedButton, EventArgs e)
        {
            //Feeds GuessChecker the guessed letter
            GuessChecker(char.Parse(((Button)pressedButton).Text));
        }
        //Function for checking the guesses
        private void GuessChecker(char guessedLetter)
        {
            bool alreadyGuessed = false;
            //Hides the guessed letter by checking if the letter matches the text on any of the buttons
            foreach (var button in this.Controls.OfType<Button>())
            {
                if (button.Text == guessedLetter.ToString())
                {
                    //If the button is already hidden set alreadyGuessed to true
                    if(button.Visible == false)
                    {
                        alreadyGuessed = true;
                    }
                    button.Hide();
                }
            }
            //Making a wip char[] from wordDisplay so the individual letters may be changed because strings are immutable
            char[] wipWordDisplay = wordDisplay.Text.ToCharArray();
            //Checks if hiddenword isn't empty to fix crash due to keypress in menu
            if (hiddenWord.Contains(guessedLetter))
            {
                //Looks for the letter in the word and replaces "_" in WordDisplay with it
                for(int i = 0; i < hiddenWord.Length; i++)
                {
                    if (hiddenWord[i] == guessedLetter)
                    {
                        wipWordDisplay[i] = guessedLetter;
                    }
                }
                //Converts the wip char[] back to a string in order to display it
                wordDisplay.Text = new string(wipWordDisplay);
                //Checks if the game is won
                if (wordDisplay.Text == hiddenWord)
                {
                    Win();
                }
            }
            else if(!alreadyGuessed)
            {
                WrongGuess();
            }
        }
        //Function for wrong guess

        private void WrongGuess()
        {
            if(guessesLeft > 0)
            {
                guessesLeft--;
            }
            //Updates guessesLeftLabel
            guessesLeftLabel.Text=$"Guesses left: {guessesLeft}";
            //Gets the resource corresponding to the amount of guesses left
            pictureBox.Image = Properties.Resources.ResourceManager.GetObject(guessesLeft.ToString()) as Bitmap;
            //Checks if the game is over
            if (guessesLeft == 0)
            {
                lossWordWasLabel.Text = $"The word was {hiddenWord}";
                gameoverPanel.Show();
            }
        }
        private void Win()
        {
            winWordWasLabel.Text = $"The word was {hiddenWord}";
            winPanel.Show();
            pictureBox.Image = Properties.Resources.Win;
        }
    }
}
