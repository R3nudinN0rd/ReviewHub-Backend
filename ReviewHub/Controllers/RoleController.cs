using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.RoleRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<RoleModel>> GetAllRoles()
        {
            return Ok(_roleRepository.GetAllRolesAsync().Result);
        }

        [HttpGet("{roleId}", Name = "GetRoleById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"roleId"})]
        public ActionResult GetRoleById(int roleId)
        {
            return _roleRepository.RoleExists(roleId) == false ?
                NotFound("Role not found!") :
                Ok(_roleRepository.GetRoleByIdAsync(roleId).Result);
        }

        [HttpPost]
        public ActionResult AddRole(RoleModel role)
        {
            _roleRepository.AddRole(role);
            return CreatedAtRoute("GetRoleById",
                                  new { roleId = role.Id },
                                  role);
        }

        [HttpPut]
        public ActionResult UpdateRole(RoleModel role)
        {
            if(_roleRepository.RoleExists(role.Id) == false)
            {
                return NotFound("Role not found!");
            }

            _roleRepository.UpdateRole(role);
            return Ok("Role updated!");
        }

        [HttpDelete]
        public ActionResult DeleteRole(int roleId)
        {
            if (_roleRepository.RoleExists(roleId) == false)
            {
                return NotFound("Role not found!");
            }

            _roleRepository.DeleteRole(roleId);
            return Ok("Role deleted!");
        }

    }
}
