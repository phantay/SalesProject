using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI.BL
{
    public class Login
    {
    
        public Login()
        {
        }

        private bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearTexts(TextBox userName, TextBox passWord)
        {
            userName.Text = String.Empty;
            passWord.Text = String.Empty;
        }

        public bool CheckLogin(TextBox userName, TextBox passWord)
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                MessageBox.Show("Enter the user name!");
                return false;
            }
            else if (StringValidator(userName.Text) == true)
            {
                MessageBox.Show("Enter the text here");
                //ClearTexts(userName, passWord);
                return false;
            }
            else if (string.IsNullOrEmpty(passWord.Text))
            {
                MessageBox.Show("Enter the password!");
                //ClearTexts(userName, passWord);
                return false;
            }else
            {
                return true;
            }
        }
    }
}
