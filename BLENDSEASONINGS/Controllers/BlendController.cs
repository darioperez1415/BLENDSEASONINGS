using BLENDSEASONINGS.Models;
using BLENDSEASONINGS.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlendController : Controller
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

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var match = _blendRepo.GetBlendById(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
    }
}
