using System;

namespace ConsensusTester.Services.Blocks.Models
{
    public class BlockModel
    {
        public string Id { get; set; }

        public string Miner { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}