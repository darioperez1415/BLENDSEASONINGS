using BLENDSEASONINGS.Models;
using BLENDSEASONINGS.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlendController : ControllerBase
    {
        private readonly IBlendRepository _blendRepo;

        public BlendController(IBlendRepository blendRepository)
        {
            _blendRepo = blendRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Blend> blends = _blendRepo.GetAllBlends();
            if (blends == null) return NotFound();
            return Ok(blends);
        }
    }
}

