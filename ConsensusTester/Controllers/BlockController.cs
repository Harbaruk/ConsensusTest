using ConsensusTester.Services.Blocks;
using ConsensusTester.Services.Blocks.Models;
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBlocks(string id)
        {
            if (id == null)
            {
                return Ok(_blockService.GetBlocks());
            }
            return Ok(_blockService.GetBlocks(id));
        }

        [HttpPost]
        [Route("verify")]
        public IActionResult VerifyBlock([FromBody]VerifyBlockModel verifyBlock)
        {
            _blockService.VerifyBlock(verifyBlock);
            return Ok();
        }

        [HttpGet]
        [Route("unverified/{user}")]
        public IActionResult GetPendingBlocks(string user)
        {
            return Ok(_blockService.GetLastUnverifiedBlock(user));
        }

        [HttpGet]
        [Route("last_block")]
        public IActionResult GetLastBlock()
        {
            return Ok(_blockService.GetLastBlock());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateBlock([FromBody] CreateBlockModel blockModel)
        {
            _blockService.CreateBlock(blockModel);
            return Ok();
        }
    }
}