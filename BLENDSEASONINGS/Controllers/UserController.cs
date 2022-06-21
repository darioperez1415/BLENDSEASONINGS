using Microsoft.AspNetCore.Mvc;
using BLENDSEASONINGS.Repos;
using BLENDSEASONINGS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        // POST api/<Users>
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.CreateUser(user);
                return Ok(user);
            }
        }

        [Authorize]
        [HttpGet("Auth")]
        public async Task<IActionResult> GetUserAuthStatus()
        {
            string userId = User.FindFirst(claim => claim.Type == "user_id").Value;
            bool userexists = _userRepo.CheckUserExists(userId);
            if (!userexists)
            {
                User userFromToken = new User()
                {

                    Id = userId,

                };

                _userRepo.CreateUser(userFromToken);
                return Ok();
            }
            User existingUser = _userRepo.GetUserById(userId);
            return Ok(existingUser);
        }

    }
}
