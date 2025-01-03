using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class SignUpUI : Form
    {
        private readonly string filePath = "userdata.dtb";

        public SignUpUI()
        {
            InitializeComponent();
        }

        private void RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Show();
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UserExists(username))
            {
                MessageBox.Show("Username already exists. Choose another one.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (reEnterTxt.Text != password)
            {
                MessageBox.Show("Re-Entered password does not match.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveUser(username, password);
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
        }

        private bool UserExists(string username)
        {
            if (!File.Exists(filePath))
                return false;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] data = line.Split(':');
                if (data[0].Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void SaveUser(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                writer.WriteLine($"{username}:{password}");
            }
        }

        private void ClearForm()
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            reEnterTxt.Text = "";
        }
    }
}
