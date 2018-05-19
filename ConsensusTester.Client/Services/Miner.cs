using System;

namespace ConsensusTester.Client.Services
{
    public class Miner
    {
        private readonly HttpClientService _httpClient;
        private bool _isStarted = false;

        public Miner(string user)
        {
            _httpClient = new HttpClientService(user);
        }

        private bool CheckTransactionAmount()
        {
            return _httpClient.CheckTransactionsAmount();
        }

        private bool CheckBlocks()
        {
            return _httpClient.CheckForBlockVerify();
        }

        public void Run()
        {
            _isStarted = true;
            while (_isStarted)
            {
                if (CheckBlocks())
                {
                    var block = GetLastBlock();
                    var isGood = CheckBlocks(block);
                }
            }
        }

        private object CheckBlocks(object block)
        {
            throw new NotImplementedException();
        }

        private object GetLastBlock()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            _isStarted = false;
        }
    }
}