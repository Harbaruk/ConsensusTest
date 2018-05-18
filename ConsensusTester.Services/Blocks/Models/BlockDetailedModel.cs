using ConsensusTester.Services.Transactions.Models;
using System;
using System.Collections.Generic;

namespace ConsensusTester.Services.Blocks.Models
{
    public class BlockDetailedModel
    {
        public string Hash { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Miner { get; set; }

        public long Nonce { get; set; }

        public string PreviousHash { get; set; }
    }
}