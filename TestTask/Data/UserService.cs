using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Data
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context) => _context = context;
        
        public async Task<User> GetUser()
        {
            var UserWithMostCountOrder = await _context.Users.
                OrderByDescending(x => x.Orders.Count()).FirstOrDefaultAsync();
            return UserWithMostCountOrder;
        }

        public async Task<List<User>> GetUsers()
        {
            var UserInActive = await _context.Users.Where(x => x.Status == Enums.UserStatus.Inactive).ToListAsync();
            return UserInActive;
        }
    }
}
