using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.UserRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsersAsync().Result);
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"userId"})]
        public ActionResult<UserModel> GetUserById(int userId)
        {
            return _userRepository.UserExists(userId) == false ? 
                            NotFound("User not found!") : 
                            Ok(_userRepository.GetUserByIdAsync(userId).Result);
        }

        [HttpPost]
        public ActionResult AddUser(UserModel user)
        {
            _userRepository.AddUser(user);
            return CreatedAtRoute("GetUserById",
                                  new {userId = user.Id},
                                  user);
        }

        [HttpPut]
        public ActionResult UpdateUser(UserModel user)
        {
            if(_userRepository.UserExists(user.Id) == false)
            {
                return NotFound("User not found!");
            }

            _userRepository.UpdateUser(user);
            return Ok("User updated!");
        }

        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            if(_userRepository.UserExists(userId) == false)
            {
                return NotFound("User not found!");
            }

            _userRepository.DeleteUser(userId);
            return Ok("User deleted!");
        }

    }
}
