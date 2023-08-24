using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public UserRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserModel AddUser(UserModel user)
        {
            try
            {
                _reviewHubContext.Users.Add(
                    _mapper.Map<User>(user)
                    );
                return user;
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

        public async void DeleteUser(int userId)
        {
            var userToDelete = await _reviewHubContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
            try
            {
                _reviewHubContext.Users.Remove(userToDelete);
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

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserModel>>(
                await _reviewHubContext.Users.ToListAsync()
                );
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            return _mapper.Map<UserModel>(await _reviewHubContext.Users.FirstOrDefaultAsync(user => user.Id == userId));
        }

        public void UpdateUser(UserModel user)
        {
            try
            {
                var existingUser = _reviewHubContext.Users.FirstOrDefault(u => u.Id == user.Id);
                _reviewHubContext.Users.Update(
                     _mapper.Map(user, existingUser)
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

        public bool UserExists(int userId)
        {
            var user = _reviewHubContext.Users.FirstOrDefault(u => u.Id == userId);
            return user != null;
        }
    }
}
