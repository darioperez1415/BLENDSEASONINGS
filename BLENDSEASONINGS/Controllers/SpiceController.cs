using BLENDSEASONINGS.Models;
using BLENDSEASONINGS.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpiceController : ControllerBase
    {
        private readonly ISpiceRepository _spiceRepository;
        
        public SpiceController(ISpiceRepository spiceRepository)
        {
            _spiceRepository = spiceRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Spice> spices = _spiceRepository.GetAllSpices();
            if(spices == null) return NotFound();
            return Ok(spices);
        }

        [HttpGet("{id}")]

        public IActionResult Details(int id)
        {
            var match = _spiceRepository.GetSpiceById(id);

            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }
    }
}
