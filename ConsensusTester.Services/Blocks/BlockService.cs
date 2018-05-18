using ConsensusTester.DataAccess.Entities;
using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Services.Blocks.Models;
using ConsensusTester.Services.Transactions.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsensusTester.Services.Blocks
{
    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateBlock(CreateBlockModel blockModel)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<BlockModel> GetBlocks()
        {
            return _unitOfWork.Repository<BlockEntity>()
                .Set
                .Where(x => x.BlockState == BlockState.Verified.ToString())
                .Select(x => new BlockModel
                {
                    Date = x.Date,
                    Id = x.Hash,
                    Miner = x.Miner
                })
                .TakeLast(10)
                .ToList();
        }

        public BlockDetailedModel GetBlocks(string id)
        {
            var block = _unitOfWork.Repository<BlockEntity>()
                .Include(x => x.Transactions)
                .FirstOrDefault(x => x.BlockState == BlockState.Verified.ToString()
                                 && x.Hash == id);

            if (block != null)
            {
                return new BlockDetailedModel
                {
                    Date = block.Date,
                    Hash = block.Hash,
                    Miner = block.Miner,
                    Nonce = block.Nonce,
                    PreviousHash = block.PreviousBlockHash,
                    Transactions = block.Transactions.Select(x => new TransactionModel
                    {
                        Date = x.Date,
                        Description = x.Description,
                        Id = x.Id,
                        Owner = x.Owner,
                        State = x.State
                    }).ToList()
                };
            }
            return null;
        }

        public void VerifyBlock(VerifyBlockModel verifyBlock)
        {
            throw new System.NotImplementedException();
        }
    }
}