using ConsensusTester.Client.Models;
using ConsensusTester.Client.Services;
using ConsensusTester.Client.Services.Helpers;
using System;
using System.Collections.Generic;
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

        private string User { get; set; }

        private CancellationTokenSource CancellationTokenSource { get; set; }

        public MiningForm(BlockDetailedModel model, string user)
        {
            InitializeComponent();
            Block = model;
            User = user;
            _httpClient = new HttpClientService(user);
        }

        public async void Run(CancellationTokenSource tokenSource)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource = tokenSource;
            Task<CreateBlockModel> task = new Task<CreateBlockModel>(Mining, tokenSource.Token);

            task.Start();

            var createdBlock = await task;
            if (createdBlock == null)
            {
                this.Close();
            }
            var isGood = VerifyBlock(Block.Transactions, createdBlock);

            _httpClient.CreateBlock(createdBlock);
        }

        private bool VerifyBlock(IList<TransactionModel> transactions, CreateBlockModel createdBlock)
        {
            var transactionHash = MerkleTree<TransactionModel>.Compute(Block.Transactions);
            var obj = new MiningBlock
            {
                Hash = transactionHash + Block.PreviousHash,
                PreviousBlockHash = User,
                Nonce = createdBlock.Nonce,
                Miner = User
            };

            using (SHA256Managed sha = new SHA256Managed())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, obj);

                    return createdBlock.Hash == Convert.ToBase64String(sha.ComputeHash(ms.ToArray()));
                }
            }
        }

        private CreateBlockModel Mining()
        {
            var transactionHash = MerkleTree<TransactionModel>.Compute(Block.Transactions);
            var obj = new MiningBlock
            {
                Hash = transactionHash + Block.PreviousHash,
                PreviousBlockHash = User,
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
                        if (CancellationTokenSource.IsCancellationRequested)
                        {
                            return null;
                        }
                        obj.Nonce++;
                        ms.Position = 0;
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ms, obj);

                        blockResultHash = Convert.ToBase64String(sha.ComputeHash(ms.ToArray()));
                        ThreadHelperClass.SetText(this, Output, blockResultHash);
                    }
                    while (!blockResultHash.Substring(0, 5).All(x => x == '0'));

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
    }
}