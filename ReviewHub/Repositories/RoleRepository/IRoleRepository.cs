using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        public Task<RoleModel> GetRoleByIdAsync(int roleId);
        public Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        public RoleModel AddRole(RoleModel role);
        public void UpdateRole(RoleModel role);
        public void DeleteRole(int roleId);
        public bool RoleExists(int roleId);
    }
}
