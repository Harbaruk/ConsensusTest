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

        public bool Cancel { get; set; }

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
            Mining();
            Task<CreateBlockModel> task = new Task<CreateBlockModel>(Mining, tokenSource.Token);

            task.Start(uiContext);

            var createdBlock = await task;

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
                        obj.Nonce++;
                        ms.Position = 0;
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ms, obj);

                        blockResultHash = Convert.ToBase64String(sha.ComputeHash(ms.ToArray()));
                        Output.Text += Environment.NewLine + blockResultHash;
                    }
                    while (!blockResultHash.Substring(0, 1).All(x => x == '0'));

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