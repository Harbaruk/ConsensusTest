using System;

namespace ConsensusTester.Client.Models
{
    [Serializable]
    public class MiningBlock
    {
        public string Hash { get; set; }

        public long Nonce { get; set; }

        public string PreviousBlockHash { get; set; }

        public string Miner { get; set; }
    }
}