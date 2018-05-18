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
        public IActionResult GetPendingBlocks([FromBody]VerifyBlockModel verifyBlock)
        {
            _blockService.VerifyBlock(verifyBlock);
            return Ok();
        }
    }
}