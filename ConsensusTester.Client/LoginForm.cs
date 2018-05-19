using System;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                var mainForm = new MainForm(Username.Text, PublicKey.Text, PrivateKey.Text);
                mainForm.Show();
                this.Hide();
                mainForm.FormClosed += MainForm_FormClosed;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateFields()
        {
            return !String.IsNullOrWhiteSpace(PublicKey.Text)
                || !String.IsNullOrWhiteSpace(PrivateKey.Text)
                || !String.IsNullOrWhiteSpace(Username.Text);
        }
    }
}