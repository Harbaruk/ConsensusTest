using ConsensusTester.DataAccess.Entities;
using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Services.Transactions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsensusTester.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateTransaction(TransactionModel model)
        {
            _unitOfWork.Repository<TransactionEntity>().Insert(new TransactionEntity
            {
                Date = DateTimeOffset.Now,
                Description = model.Description,
                Owner = model.Owner,
                State = TransactionState.Unverified.ToString()
            });
        }

        public ICollection<TransactionModel> GetAllUnverifiedTransactions()
        {
            return _unitOfWork.Repository<TransactionEntity>().Set.
                Where(x => x.State == TransactionState.Unverified.ToString())
                .Select(x => new TransactionModel
                {
                    Date = x.Date,
                    Description = x.Description,
                    Id = x.Id,
                    Owner = x.Owner,
                    State = x.State
                }).ToList();
        }

        public TransactionModel GetTransaction(string id)
        {
            var transaction = _unitOfWork.Repository<TransactionEntity>().Set
                 .FirstOrDefault(x => x.Id == id);

            if (transaction != null)
            {
                return new TransactionModel
                {
                    Date = transaction.Date,
                    Description = transaction.Description,
                    Id = transaction.Id,
                    Owner = transaction.Owner,
                    State = transaction.State
                };
            }
            return null;
        }

        public int GetUnverifiedTransactions()
        {
            return _unitOfWork.Repository<TransactionEntity>().Set
                .Count(x => x.State == TransactionState.Unverified.ToString());
        }
    }
}