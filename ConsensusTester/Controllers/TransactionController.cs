using ConsensusTester.Services.Transactions;
using ConsensusTester.Services.Transactions.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsensusTester.Controllers
{
    [Produces("application/json")]
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateTransaction([FromBody] TransactionModel transaction)
        {
            _transactionService.CreateTransaction(transaction);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTransaction(string id)
        {
            return Ok(_transactionService.GetTransaction(id));
        }

        [HttpGet]
        [Route("unverified_count")]
        public IActionResult GetUnverifiedTransactionsCount()
        {
            return Ok(_transactionService.GetUnverifiedTransactions());
        }

        [HttpGet]
        [Route("unverified")]
        public IActionResult GetUnverifiedTransactions()
        {
            return Ok(_transactionService.GetAllUnverifiedTransactions());
        }

        [HttpGet]
        [Route("generate")]
        public IActionResult GenerateTransactions()
        {
            _transactionService.Generate();
            return Ok();
        }
    }
}