﻿using System;
using System.Collections.Generic;

namespace ConsensusTester.Services.Blocks.Models
{
    public class CreateBlockModel
    {
        public string Hash { get; set; }

        public ICollection<string> Transactions { get; set; }

        public long Nonce { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Miner { get; set; }

        public string PrevBlockHash { get; set; }
    }
}