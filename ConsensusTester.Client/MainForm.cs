using ConsensusTester.Client.Services;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class MainForm : Form
    {
        private MiningForm _miningForm;
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
            _miningForm = new MiningForm(_publicKey);

            _miningForm.SpeedChanged += _miningForm_SpeedChanged;
            _miningForm.BlockCreated += _miningForm_BlockCreated;
            InitializeComponent();

            var block = _httpClient.GetLastBlock();
            LastVerifiedBlock.HashLabelProp.Text = block?.Hash;
            LastVerifiedBlock.MinerLabelProp.Text = block?.Miner;
            LastVerifiedBlock.DateLabelProp.Text = block?.Date.ToString();
        }

        private void _miningForm_BlockCreated()
        {
            var block = _httpClient.GetLastBlock();

            LastVerifiedBlock.HashLabelProp.Text = block?.Hash;
            LastVerifiedBlock.MinerLabelProp.Text = block?.Miner;
            LastVerifiedBlock.DateLabelProp.Text = block?.Date.ToString();
            LastVerifiedBlock.Visible = true;
        }

        private void _miningForm_SpeedChanged()
        {
            SpeedLabel.Text = "Speed : " + _miningForm?.HashSpeed;
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

                _miningTokenSource = new CancellationTokenSource();
                _isMining = false;
                _miningForm._isMining = false;
                button2.Text = "Mining";
                _miningForm.Close();
                SpeedLabel.Text = "Speed : 0";
            }
            else
            {
                button2.Text = "Stop";
                _isMining = true;

                _miningForm = new MiningForm(_publicKey);
                _miningForm.SpeedChanged += _miningForm_SpeedChanged;
                _miningForm.Show();
                _miningForm.Start();
            }
        }
    }
}