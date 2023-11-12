using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PigLatinTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnglish.Text = "";
            txtPigLatin.Text = "";
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string eng = txtEnglish.Text.Trim();
            if (!String.IsNullOrEmpty(txtEnglish.Text))
            {
                // Splits on "space" character
                string[] words = eng.Split(' ');
                string piglatin = "";
                
                foreach (string word in words)
                {
                    piglatin += TranslateWord(word) + " ";
                }
                txtPigLatin.Text = piglatin;
            } else
            {
                MessageBox.Show("You must enter some text to translate.", "Enter");
                txtEnglish.Focus();
            }
        }

        private string TranslateWord(string word)
        {
            char c = word[0];
            if(c == 'a' || c == 'e' || c == 'i' || c == 'o' ||  c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                word += "way";
            } else
            {
                if(c == 'y' || c == 'Y')
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                    c = word[0];
                }
                while (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u' && c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U' && c != 'y' && c != 'Y')
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                    c = word[0];
                }

                word += "ay";
            }

            return word;

        }

    }
}
