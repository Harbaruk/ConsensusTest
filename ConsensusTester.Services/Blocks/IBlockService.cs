using ConsensusTester.Services.Blocks.Models;
using System.Collections.Generic;

namespace ConsensusTester.Services.Blocks
{
    public interface IBlockService
    {
        ICollection<BlockModel> GetBlocks();

        BlockDetailedModel GetBlocks(string id);

        void VerifyBlock(VerifyBlockModel blockModel);

        void CreateBlock(CreateBlockModel blockModel);

        BlockDetailedModel GetLastBlock();

        BlockDetailedModel GetLastUnverifiedBlock(string user);
    }
}