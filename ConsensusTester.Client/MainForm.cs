using ConsensusTester.Client.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class MainForm : Form
    {
        private string _username;
        private string _privateKey;
        private string _publicKey;
        private readonly HttpClientService _httpClient;
        private CancellationTokenSource _miningTokenSource;
        private bool _isMining = false;

        public MainForm(string username, string privateKey, string publicKey)
        {
            _username = username;
            _privateKey = privateKey;
            _publicKey = publicKey;
            _httpClient = new HttpClientService(_publicKey);
            _miningTokenSource = new CancellationTokenSource();

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (_isMining)
            {
                _miningTokenSource.Cancel();
                _isMining = false;
                button2.Text = "Mining";
            }
            else
            {
                button2.Text = "Stop";
                _isMining = true;
                if (_httpClient.CheckTransactionsAmount())
                {
                    var transactions = _httpClient.GetUnverifiedTransactions();
                    var block = _httpClient.GetLastBlock() ?? "0000000000";
                    MiningForm mining = new MiningForm(new Models.BlockDetailedModel
                    {
                        Transactions = transactions,
                        PreviousHash = block
                    }, _publicKey);
                    mining.Show();
                    mining.Run(_miningTokenSource);
                }
            }
        }
    }
}