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
        public Hangman()
        {
            InitializeComponent();
        }

        private void letter_button(object sender, EventArgs e)
        {
           
        }


        private void Hangman_KeyPress(object sender, KeyPressEventArgs e)
        {
            char pressedKey = Char.ToUpper(e.KeyChar);
            if (Char.IsLetter(pressedKey))
            {

            }
            else
            {

            }
        }
    }
}
