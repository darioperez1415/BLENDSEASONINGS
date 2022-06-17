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

        [HttpGet("{id}")]
        public IActionResult SingleBlends(int id)
        {
            Blend blend = _blendRepo.GetSingleBlend(id);
            if (blend == null)
            {
                return NotFound();
            }
            else
            { 
            return Ok(blend);
            }
        }

        [HttpPost("/CreateNewBlend")]
        public IActionResult CreateBlendOrder(Blend blendOrder)
        {
            if (blendOrder == null) 
            {
                return NotFound();
            }
            else
            {
                _blendRepo.CreateBlendOrder(blendOrder);
                return Ok(blendOrder);
            }
        }
        [HttpDelete("{id}")]
        public void DeleteBlend(int id)
        {
           _blendRepo.DeleteBlend(id);
        }
    }
}

