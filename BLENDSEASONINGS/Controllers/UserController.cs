using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLENDSEASONINGS.Repos;
using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            List<User> users = _userRepo.GetUsers();
            if (users == null) return NotFound();
            return Ok(users);
        }


        // GET: UserController/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            User user = _userRepo.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            if (newUser == null)
            {
                return NotFound();

            }
            else
            {
                _userRepo.AddUser(newUser);
                return Ok(newUser);
            }
        }


    }
}
