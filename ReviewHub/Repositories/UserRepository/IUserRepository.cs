using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserByIdAsync(int userId);
        public Task<IEnumerable<UserModel>> GetAllUsersAsync();
        public UserModel AddUser(UserModel user);
        public void UpdateUser(UserModel user);
        public void DeleteUser(int userId);
        public bool UserExists(int userId);
    }
}
