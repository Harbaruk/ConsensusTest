using ConsensusTester.Client.Models;
using ConsensusTester.Client.Services;
using ConsensusTester.Client.Services.Helpers;
using System;
using System.Collections.Generic;
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
        private System.Timers.Timer _blockUpdateTimer;
        private System.Timers.Timer _miningTimer;
        private bool _isMining = false;
        private TimeSpan _miningTime = new TimeSpan();
        private ChartForm _chartForm;

        public MainForm(string username, string publicKey, string privateKey)
        {
            _username = username;
            _blockUpdateTimer = new System.Timers.Timer(10000);
            _miningTimer = new System.Timers.Timer(1000);
            _blockUpdateTimer.Elapsed += _blockUpdateTimer_Elapsed;
            _miningTimer.Elapsed += _miningTimer_Elapsed;
            _blockUpdateTimer.Start();
            _privateKey = privateKey;
            _publicKey = publicKey;
            _chartForm = new ChartForm();

            _httpClient = new HttpClientService(_publicKey);
            _miningTokenSource = new CancellationTokenSource();
            _miningForm = new MiningForm(_publicKey);
            _miningForm.FormClosed += _miningForm_FormClosed;

            _miningForm.SpeedChanged += _miningForm_SpeedChanged;
            _miningForm.BlockCreated += _miningForm_BlockCreated;
            InitializeComponent();

            var block = _httpClient.GetLastBlock();

            PublicKeyLabel.Text = _publicKey;
            PrivateKeyLabel.Text = _privateKey.Substring(0, 2) + "********";
            UsernameLabel.Text = _username;
            LastVerifiedBlock.HashLabelProp.Text = block?.Hash;
            LastVerifiedBlock.MinerLabelProp.Text = block?.Miner;
            LastVerifiedBlock.DateLabelProp.Text = block?.Date.ToString();
            LastVerifiedBlock.Show();
        }

        private void _miningForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void _miningTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _miningTime = _miningTime.Add(new TimeSpan(0, 0, 1));
            ThreadHelperClass.SetText(this, TimeLabel, $"Time : {_miningTime.ToString("c")}");
        }

        private void _blockUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var block = _httpClient.GetLastBlock();
            if (block != null)
            {
                ThreadHelperClass.SetTextBlock(this, LastVerifiedBlock, block.Hash, block.Date.ToString(), block.Miner);
            }
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
            ThreadHelperClass.SetText(this, SpeedLabel, "Speed : " + _miningForm?.HashSpeed);
            _chartForm.AddSeries((int)_miningForm.HashSpeed);
        }

        private void CreateTransaction_Click(object sender, EventArgs e)
        {
            var block = _httpClient.GetUnverifiedBlock();

            List<string> list = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(MerkleTree<TransactionModel>.Compute(block.Transactions));
            }
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
                _miningTimer.Stop();
            }
            else
            {
                button2.Text = "Stop";
                _isMining = true;

                _miningForm = new MiningForm(_publicKey);
                _miningForm.SpeedChanged += _miningForm_SpeedChanged;
                _miningForm.Show();
                _miningForm.Start();
                _miningTimer.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _chartForm.Show();
        }
    }
}