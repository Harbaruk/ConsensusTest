using ConsensusTester.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsensusTester.Client.Services
{
    public class HttpClientService
    {
        private HttpClient _httpClient;
        private readonly string _url = "http://localhost:62324/api";
        private readonly string _user;

        public HttpClientService(string user)
        {
            _httpClient = new HttpClient();
            _user = user;
        }

        public void CreateTransaction(TransactionModel transaction)
        {
            var content = new StringContent(GenerateJsonData(transaction), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_url}/transaction/create", content);
        }

        private string GenerateJsonData(object transaction)
        {
            return JsonConvert.SerializeObject(transaction);
        }

        public bool CheckTransactionsAmount()
        {
            return Int32.Parse(_httpClient.GetAsync($"{_url}/transaction/unverified_count").Result.Content.ReadAsStringAsync().Result) >= 100;
        }

        public IList<TransactionModel> GetUnverifiedTransactions()
        {
            return JsonConvert.DeserializeObject<List<TransactionModel>>
                (_httpClient.GetAsync($"{_url}/transaction/unverified")
                .Result
                .Content
                .ReadAsStringAsync()
                .Result);
        }

        public bool CheckForBlockVerify()
        {
            return JsonConvert.DeserializeObject<BlockDetailedModel>(_httpClient.GetAsync($"{_url}/blocks/unverified/{_user}").Result.Content.ReadAsStringAsync().Result) != null;
        }

        public BlockDetailedModel GetLastBlock()
        {
            return JsonConvert.DeserializeObject<BlockDetailedModel>
                (_httpClient.GetAsync($"{_url}/blocks/last_block")
                .Result
                .Content
                .ReadAsStringAsync()
                .Result);
        }

        public void VerifyBlock(string blockId, string user)
        {
            var content = new StringContent(GenerateJsonData(new VerifyBlockModel { Id = blockId, User = user }), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_url}/blocks/verify", content);
        }

        public BlockDetailedModel GetUnverifiedBlock()
        {
            return JsonConvert.DeserializeObject<BlockDetailedModel>
                (_httpClient.GetAsync($"{_url}/blocks/unverified/{_user}").Result.Content.ReadAsStringAsync().Result);
        }

        public void CreateBlock(CreateBlockModel blockModel)
        {
            var content = new StringContent(GenerateJsonData(blockModel), Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{_url}/blocks/create", content).Wait();
        }
    }
}