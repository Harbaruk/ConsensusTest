using System;

namespace ConsensusTester.DataAccess.Entities
{
    public class TransactionEntity
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }

        public string State { get; set; }

        public string Owner { get; set; }

        public BlockEntity Block { get; set; }
    }
}