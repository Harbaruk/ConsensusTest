using System;
using System.Collections.Generic;

namespace ConsensusTester.DataAccess.Entities
{
    public class BlockEntity
    {
        public string Hash { get; set; }

        public DateTimeOffset Date { get; set; }

        public long Nonce { get; set; }

        public ICollection<TransactionEntity> Transactions { get; set; }

        public string BlockState { get; set; }

        public string Miner { get; set; }

        public string PreviousBlockHash { get; set; }
    }
}