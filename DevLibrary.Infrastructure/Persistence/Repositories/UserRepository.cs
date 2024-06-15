using DevLibrary.Core.Entities;
using DevLibrary.Core.Models;
using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibrary.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
     
        private readonly DevLibraryDbContext _dbContext;
        private const int PAGE_SIZE = 2;

        public UserRepository(DevLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PaginationResult<User>> GetAllAsync(string query, int page)
        {
            IQueryable<User> users = _dbContext.Users;

            if (!string.IsNullOrEmpty(query))
            {
                users = users.Where(u => u.Name.Contains(query) || u.Equals(query));
            }

            return await users.GetPaged<User>(page, PAGE_SIZE);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(u => u.Loans)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            
        }

    }
}
