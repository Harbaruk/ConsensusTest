using ConsensusTester.DataAccess.Entities;
using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Services.Blocks.Models;
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

        public ICollection<BlockModel> GetBlocks()
        {
            return _unitOfWork.Repository<BlockEntity>()
                .Set
                .Select(x => new BlockModel
                {
                    Date = x.Date,
                    Id = x.Hash,
                    Miner = x.Miner
                })
                .TakeLast(10)
                .ToList();
        }
    }
}