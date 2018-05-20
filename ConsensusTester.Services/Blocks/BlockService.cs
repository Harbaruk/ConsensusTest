using ConsensusTester.DataAccess.Entities;
using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Services.Blocks.Models;
using ConsensusTester.Services.Options;
using ConsensusTester.Services.Transactions.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace ConsensusTester.Services.Blocks
{
    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<ConsensusOptions> _options;

        public BlockService(IUnitOfWork unitOfWork, IOptions<ConsensusOptions> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public void CreateBlock(CreateBlockModel blockModel)
        {
            var transactions = _unitOfWork.Repository<TransactionEntity>().Set
                                        .Where(x => blockModel.Transactions.Contains(x.Id)).ToList();
            _unitOfWork.Repository<BlockEntity>().Insert(new BlockEntity
            {
                BlockState = BlockState.Unverified.ToString(),
                Date = blockModel.Date,
                Hash = blockModel.Hash,
                Miner = blockModel.Miner,
                Nonce = blockModel.Nonce,
                PreviousBlockHash = blockModel.PrevBlockHash,
                Transactions = transactions
            });

            foreach (var trans in transactions)
            {
                trans.State = TransactionState.Verified.ToString();
            }
            _unitOfWork.SaveChanges();
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

        public BlockDetailedModel GetLastBlock()
        {
            var lastBlock = _unitOfWork.Repository<BlockEntity>().Include(x => x.Transactions)
                .LastOrDefault();

            if (lastBlock != null)
            {
                return new BlockDetailedModel
                {
                    Date = lastBlock.Date,
                    Hash = lastBlock.Hash,
                    Miner = lastBlock.Miner,
                    Nonce = lastBlock.Nonce,
                    PreviousHash = lastBlock.PreviousBlockHash,
                    Transactions = lastBlock.Transactions.Select(x => new TransactionModel
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

        public BlockDetailedModel GetLastUnverifiedBlock()
        {
            var block = _unitOfWork.Repository<BlockEntity>().Include(x => x.Transactions)
                .FirstOrDefault(x => x.BlockState == BlockState.Unverified.ToString());

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
            var block = _unitOfWork.Repository<BlockEntity>().Include(x => x.Verifications)
                .FirstOrDefault(x => x.Hash == verifyBlock.Id);

            if (block != null)
            {
                block.Verifications.Add(new BlockVerificationEntity { UserPublicKey = verifyBlock.User });

                if (block.Verifications.Count >= _options.Value.VerificationNeeded)
                {
                    block.BlockState = BlockState.Verified.ToString();
                }
                _unitOfWork.SaveChanges();
            }
        }
    }
}