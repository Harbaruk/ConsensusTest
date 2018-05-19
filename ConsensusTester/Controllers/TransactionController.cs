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
    }
}