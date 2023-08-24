using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public RoleRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public RoleModel AddRole(RoleModel role)
        {
            try
            {
                _reviewHubContext.Roles.Add(
                    _mapper.Map<Role>(role)
                    );
                return role;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public void DeleteRole(int roleId)
        {
            var roleToDelete = _reviewHubContext.Roles.FirstOrDefault(role => role.Id == roleId);
            try
            {
                _reviewHubContext.Roles.Remove(roleToDelete);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            return _mapper.Map<IQueryable<RoleModel>>(
                await _reviewHubContext.Roles.ToListAsync()
                );
        }

        public async Task<RoleModel> GetRoleByIdAsync(int roleId)
        {
            return _mapper.Map<RoleModel>(
                await _reviewHubContext.Roles.FirstOrDefaultAsync(role => role.Id == roleId)
                );
        }

        public bool RoleExists(int roleId)
        {
            var role = _reviewHubContext.Roles.FirstOrDefault(r=> r.Id == roleId);
            return role != null;
        }

        public void UpdateRole(RoleModel role)
        {
            try
            {
                var existingRole = _reviewHubContext.Roles.FirstOrDefault(r => r.Id == role.Id);
                _reviewHubContext.Roles.Update(
                      _mapper.Map(role, existingRole)
                      );
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }
    }
}
