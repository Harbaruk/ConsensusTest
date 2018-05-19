using ConsensusTester.Services.Transactions.Models;
using System.Collections.Generic;

namespace ConsensusTester.Services.Transactions
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionModel model);

        TransactionModel GetTransaction(string id);

        int GetUnverifiedTransactions();

        ICollection<TransactionModel> GetAllUnverifiedTransactions();
    }
}