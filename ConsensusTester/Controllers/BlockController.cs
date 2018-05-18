using ConsensusTester.Services.Blocks;
using Microsoft.AspNetCore.Mvc;

namespace ConsensusTester.Controllers
{
    [Produces("application/json")]
    [Route("api/blocks")]
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService;

        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }
    }
}