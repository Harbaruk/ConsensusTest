using System;
using System.Collections.Generic;

namespace ConsensusTester.Client.Models
{
    public class BlockDetailedModel
    {
        public string Hash { get; set; }

        public IList<TransactionModel> Transactions { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Miner { get; set; }

        public long Nonce { get; set; }

        public string PreviousHash { get; set; }
    }
}