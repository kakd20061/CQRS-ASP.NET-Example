using CQRS_Users.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Users.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetUsers();
        Task<bool> CreateUser(UserModel user);
        Task<bool> UpdateUser(UserModel user, UserModel passedUser);
        Task<bool> DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;

        // CRUD
        public async Task<UserModel> GetUserById(int id) => await _context.Users.FirstOrDefaultAsync(u => u.id == id);

        public async Task<List<UserModel>> GetUsers() => await _context.Users.ToListAsync();

        public async Task<bool> CreateUser(UserModel user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> UpdateUser(UserModel user, UserModel passedUser)
        {
            try
            {
                _context.Users.Entry(user).CurrentValues.SetValues(passedUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await GetUserById(id);
                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
