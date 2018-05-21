using ConsensusTester.Client.Models;
using ConsensusTester.Client.Services;
using ConsensusTester.Client.Services.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class MiningForm : Form
    {
        private HttpClientService _httpClient;

        private BlockDetailedModel Block { get; set; }
        private long _hashPrev = 0;
        private long _hashCurr = 0;
        public long HashSpeed;

        public delegate void Speed();

        public delegate void NewBlock();

        public event NewBlock BlockCreated;

        public event Speed SpeedChanged;

        private string User { get; set; }

        private System.Timers.Timer _checkerTimer = new System.Timers.Timer(5000);
        private System.Timers.Timer _txTimer = new System.Timers.Timer(5000);

        private CancellationTokenSource _miningTokenSource { get; set; }

        public bool _isMining;

        public MiningForm(string user)
        {
            InitializeComponent();
            _httpClient = new HttpClientService(user);
            User = user;

            _miningTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _checkerTimer.Elapsed += _timer_Elapsed;
            _txTimer.Elapsed += _txTimer_Elapsed;
            _checkerTimer.Start();
            Thread.Sleep(1000);
            _txTimer.Start();
        }

        private void _txTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_httpClient.CheckTransactionsAmount())
            {
                var transactions = _httpClient.GetUnverifiedTransactions();
                var block = _httpClient.GetLastBlock()?.Hash ?? "0000000000";

                Block = new BlockDetailedModel
                {
                    Transactions = transactions,
                    PreviousHash = block
                };
                _txTimer.Stop();
                Task.Factory.StartNew(() => Run(), _miningTokenSource.Token);
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            HashSpeed = _hashCurr - _hashPrev;
            _hashPrev = _hashCurr;

            if (_httpClient.CheckForBlockVerify())
            {
                _checkerTimer.Stop();
                _txTimer.Stop();
                _miningTokenSource.Cancel();

                var block = _httpClient.GetUnverifiedBlock();
                if (VerifyBlock(block))
                {
                    _httpClient.VerifyBlock(block.Hash, User);
                }
                _miningTokenSource = new CancellationTokenSource();

                _txTimer.Start();
                _checkerTimer.Start();
            }
            SpeedChanged();
        }

        public async void Run()
        {
            Task<CreateBlockModel> task = new Task<CreateBlockModel>(Mining, _miningTokenSource.Token);
            task.Start();

            var createdBlock = await task;

            _txTimer.Stop();
            _checkerTimer.Stop();

            if (createdBlock != null)
            {
                _httpClient.CreateBlock(createdBlock);
                _txTimer.Start();
                _checkerTimer.Start();
            }
            _txTimer.Start();
            _checkerTimer.Start();
        }

        private bool VerifyBlock(BlockDetailedModel model)
        {
            foreach (var mod in model.Transactions)
            {
                mod.State = "Unverified";
            }
            var transactionHash = MerkleTree<TransactionModel>.Compute(model.Transactions.OrderBy(x => x.Id).ToList());
            var obj = new MiningBlock
            {
                Hash = transactionHash.TrimEnd('=') + model.PreviousHash.TrimEnd('='),
                PreviousBlockHash = model.PreviousHash.TrimEnd('='),
                Nonce = model.Nonce,
                Miner = model.Miner
            };

            using (SHA256Managed sha = new SHA256Managed())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Position = 0;
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, obj);

                    return model.Hash == Convert.ToBase64String(sha.ComputeHash(ms.ToArray()));
                }
            }
        }

        private CreateBlockModel Mining()
        {
            if (Block.Transactions.Count == 0)
            {
                return null;
            }
            var transactionHash = MerkleTree<TransactionModel>.Compute(Block.Transactions.OrderBy(x => x.Id).ToList());
            var obj = new MiningBlock
            {
                Hash = transactionHash.TrimEnd('=') + Block.PreviousHash.TrimEnd('='),
                PreviousBlockHash = Block.PreviousHash.TrimEnd('='),
                Nonce = -1,
                Miner = User
            };
            string blockResultHash;
            using (SHA256Managed sha = new SHA256Managed())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    do
                    {
                        if (_miningTokenSource.IsCancellationRequested)
                        {
                            return null;
                        }
                        obj.Nonce++;
                        _hashCurr = obj.Nonce;
                        ms.Position = 0;
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ms, obj);

                        blockResultHash = Convert.ToBase64String(sha.ComputeHash(ms.ToArray()));
                        ThreadHelperClass.SetText(this, Output, blockResultHash);
                    }
                    while (!blockResultHash.Substring(0, 2).All(x => x == '0'));

                    return new CreateBlockModel
                    {
                        Date = DateTimeOffset.Now,
                        Hash = blockResultHash,
                        Miner = User,
                        Nonce = obj.Nonce,
                        PrevBlockHash = Block.PreviousHash,
                        Transactions = Block.Transactions.Select(x => x.Id).ToList()
                    };
                }
            }
        }

        private void MiningForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _txTimer.Stop();
            _checkerTimer.Stop();
            _miningTokenSource.Cancel();
        }
    }
}