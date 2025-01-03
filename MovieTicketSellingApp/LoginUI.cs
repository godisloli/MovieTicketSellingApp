using System;
using System.IO;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class LoginUI : Form
    {
        SignUpUI signUpUI;
        Menu menu;
        private readonly string filePath = "userdata.dtb";
        private readonly string rememberFile = "rememberMe.dat";

        public LoginUI()
        {
            InitializeComponent();
            LoadRememberedUser();
        }
        private void LoadRememberedUser()
        {
            if (File.Exists(rememberFile))
            {
                string[] data = File.ReadAllLines(rememberFile);
                if (data.Length >= 2)
                {
                    usernameTxt.Text = data[0];
                    passwordTxt.Text = data[1];
                    rememberMeChk.Checked = true;
                }
            }
        }

        private void RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (signUpUI == null || signUpUI.IsDisposed)
            {
                signUpUI = new SignUpUI
                {
                    Owner = this
                };
                signUpUI.FormClosed += signUpUI_FormClosed;
            }
            signUpUI.Show();
            Hide();
        }

        void signUpUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            signUpUI = null;
            Show();
        }

        void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu = null;
            Show();
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateUser(username, password))
            {
                if (rememberMeChk.Checked)
                {
                    RememberUser(username, password);
                }
                else
                {
                    ClearRememberedUser();
                }

                if (menu == null || menu.IsDisposed)
                {
                    menu = new Menu
                    {
                        Owner = this
                    };
                    menu.FormClosed += menu_FormClosed;
                }
                menu.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            if (!File.Exists(filePath))
                return false;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] data = line.Split(':');
                if (data.Length == 2 &&
                    data[0].Equals(username, StringComparison.OrdinalIgnoreCase) &&
                    data[1] == password)
                {
                    return true;
                }
            }
            return false;
        }

        private void RememberUser(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(rememberFile, false))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
            }
        }

        private void ClearRememberedUser()
        {
            if (File.Exists(rememberFile))
            {
                File.Delete(rememberFile);
            }
        }
    }
}
