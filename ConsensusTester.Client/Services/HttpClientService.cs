using ConsensusTester.Client.Models;
using Newtonsoft.Json;
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
            _httpClient.PostAsync($"{_url}/transaction", content);
        }

        private string GenerateJsonData(object transaction)
        {
            return JsonConvert.SerializeObject(transaction);
        }

        public bool CheckTransactionsAmount()
        {
            return false;
        }

        public bool CheckForBlockVerify()
        {
            return false;
        }

        public void VerifyBlock(string blockId, string user)
        {
        }
    }
}