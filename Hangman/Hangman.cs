using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Hangman : Form
    {
        public string difficulty;
        public int lives;
        public string word;
        
        public Hangman()
        {
            InitializeComponent();
        }
        private void difficultyBtn_Click(object sender, EventArgs e)
        {
            difficulty = ((Button)sender).Text.ToLower();
            menuPanel.Hide();
            Startup();
        }
        private void restartBtn_Click(object sender, EventArgs e)
        {
            //resets the game
            menuPanel.Show();
            gameoverPanel.Hide();
            winPanel.Hide();

            //Makes potential hidden buttons visible
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Visible = true;
            }
        }
        private void Startup()
        {
            //Reset from possible previous plays
            wordDisplay.Text = "";
            lives = 8;
            pictureBox.Image = Properties.Resources._8;
            //Get a word from the wordgenerator class
            WordGenerator getWord = new WordGenerator();
            switch (difficulty)
            {
                case "easy":
                    word = getWord.easyWord;
                    break;
                case "medium":
                    word = getWord.mediumWord;
                    break;
                case "hard":
                    word = getWord.hardWord;
                    break;
            }
            //devhax, remove later
            label1.Text = word;

            //Displays a "_" for each letter in the word
            for (int i = 0; i < word.Length; i++)
            {
                wordDisplay.Text += "_";
            }
        }
        //This function is broken, needs fixing
        private void Hangman_KeyPress(object sender, KeyPressEventArgs e)
        {
            char pressedKey;
            pressedKey = char.ToUpper(e.KeyChar);
            if (char.IsLetter(pressedKey))
            {
                LetterChecker(pressedKey);
            }

        }
        //Function for on clickable on screen buttons
        private void LetterClick(object sender, EventArgs e)
        {
            LetterChecker(char.Parse(((Button)sender).Text));
        }
       
        private void LetterChecker(char letter)
        {
            //devhax again
            label2.Text = letter.ToString();
            //Hides the pressed letter
            foreach (var button in this.Controls.OfType<Button>())
            {
                if (button.Text == letter.ToString())
                {
                    button.Hide();
                }
            }
            //Making a wip chararray so individual letters may be changed
            char[] wipWordDisplay = wordDisplay.Text.ToCharArray();
            if (word.Contains(letter))
            {
                //Looks for the letter in the word and replaces "_" with it
                for(int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        wipWordDisplay[i] = letter;
                    }
                }
                //
                wordDisplay.Text = new string(wipWordDisplay);
                //Checks if the game is won
                if (wordDisplay.Text == word)
                {
                    Win();
                }
            }
            else
            {
                LoseLife();
            }
        }
        //Function for changing image and losing life
        private void LoseLife()
        {
            lives--;
            switch (lives)
            {
                case 7:
                    pictureBox.Image = Properties.Resources._7;
                    break;
                case 6:
                    pictureBox.Image = Properties.Resources._6;
                    break;
                case 5:
                    pictureBox.Image = Properties.Resources._5;
                    break;
                case 4:
                    pictureBox.Image = Properties.Resources._4;
                    break;
                case 3:
                    pictureBox.Image = Properties.Resources._3;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources._2;
                    break;
                case 1:
                    pictureBox.Image = Properties.Resources._1;
                    break;
                case 0:
                    //remove
                    label2.Text = "loss";
                    pictureBox.Image = Properties.Resources._0;
                    gameoverPanel.Show();
                    break;
            }
        }
        private void Win()
        {
            //remove
            label2.Text = "win";
            //Changes location to fix issue with inheritence if it is already there in the desinger
            winPanel.Location = new Point(72, 323);
            winPanel.Show();
            pictureBox.Image = Properties.Resources.Win;
        }

       
    }
}
