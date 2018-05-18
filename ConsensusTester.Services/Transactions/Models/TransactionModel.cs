using System;

namespace ConsensusTester.Services.Transactions.Models
{
    public class TransactionModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }

        public string State { get; set; }

        public string Owner { get; set; }
    }
}