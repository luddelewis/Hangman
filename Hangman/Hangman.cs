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
        public Hangman()
        {
            InitializeComponent();
        }
        private void Hangman_KeyPress(object sender, KeyPressEventArgs e)
        {
            wBtn.Hide();
            char pressedKey;
            pressedKey = char.ToUpper(e.KeyChar);
            if (char.IsLetter(pressedKey))
            {
                LetterChecker(pressedKey);
            }

        }
        private void LetterClick(object sender, EventArgs e)
        {
            ((Button)sender).Hide();
            LetterChecker(char.Parse(((Button)sender).Text));
        }
        private void Startup()
        {
            lives = 7;
            menuPanel.Visible = true;

        }
        private void LetterChecker(char letter)
        {

        }

        private void diffBtn_Click(object sender, EventArgs e)
        {
            difficulty = ((Button)sender).Text;
            menuPanel.Hide();
        }

        
    }
}
