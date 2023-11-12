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
                    piglatin += TranslateWordCaps(word) + " ";
                }
                txtPigLatin.Text = piglatin;
            } 
            else
            {
                MessageBox.Show("You must enter some text to translate.", "Enter");
                txtEnglish.Focus();
            }
        }

        private string TranslateWordCaps(string word)
        {
            string punct = "";

            // Check if word ends with a punctuation mark
            if (word.EndsWith(".") || word.EndsWith(",") || word.EndsWith(";") || word.EndsWith(":") || word.EndsWith("!") || word.EndsWith("?"))
            {
                punct = word.Substring(word.Length - 1);
                word = word.Remove(word.Length - 1, 1);
            }

            // Capitalization handling
            if (IsInitialCap(word))
                word = ToInitialCap(TranslateWord(word));
            if (IsUpper(word))
                word = TranslateWord(word).ToUpper();
            if (IsLower(word))
                word = TranslateWord(word).ToLower();

            word += punct;


            return word;
        }

        // Straight translation (no handling of capitalization/special characters)
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

        private bool IsUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (IsUpper(word[i]) == false)
                    return false;
            }
            
            return true;
        }

        private bool IsLower(string word)
        {
            for (int i = 0; i < word.Length; i++)
                if (IsLower(word[i]) == false)
                    return false;
            
            return true;
        }

        private bool IsInitialCap(string word)
        {
            char firstLetter = word[0];

            string otherLetters = word.Remove(0, 1);
            if (IsUpper(firstLetter) && IsLower(otherLetters))
                return true;
            
            return false;
        }

        private bool IsUpper(char c)
        {
            if (c >= 65 && c <= 90 || c.ToString() == "'")
                return true;
            else
                return false;
        }

        private bool IsLower(char c)
        {
            if (c >= 97 && c <= 122 || c.ToString() == "'")
                return true;
            else
                return false;
        }

        private string ToInitialCap(string word)
        {
            string firstLetter = word.Substring(0, 1).ToUpper();
            string otherLetters = word.Substring(1).ToLower();
            
            return firstLetter + otherLetters;
        }

    }
}
