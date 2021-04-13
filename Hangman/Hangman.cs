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
        public char pressedKey;
        public Hangman()
        {
            InitializeComponent();
        }
        private void Hangman_KeyPress(object sender, KeyPressEventArgs e)
        {
            pressedKey = char.ToUpper(e.KeyChar);
            if (char.IsLetter(pressedKey))
            {
                LetterChecker();
            }
        }
        private void LetterClick(object sender, EventArgs e)
        {
            pressedKey = char.Parse(((Button)sender).Text);
            ((Button)sender).Hide();
            LetterChecker();
        }
        private void LetterChecker()
        {

        }
    }
}
