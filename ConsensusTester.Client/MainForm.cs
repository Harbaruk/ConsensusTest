using ConsensusTester.Client.Services;
using System;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class MainForm : Form
    {
        private string _username;
        private string _privateKey;
        private string _publicKey;
        private readonly HttpClientService _httpClient;

        public MainForm(string username, string privateKey, string publicKey)
        {
            _username = username;
            _privateKey = privateKey;
            _publicKey = publicKey;
            _httpClient = new HttpClientService(_publicKey);

            InitializeComponent();
        }

        private void CreateTransaction_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                _httpClient.CreateTransaction(new Models.TransactionModel
                {
                    Date = DateTimeOffset.Now,
                    Description = textBox1.Text,
                    Owner = _publicKey
                });
                textBox1.Clear();
            }
        }
    }
}