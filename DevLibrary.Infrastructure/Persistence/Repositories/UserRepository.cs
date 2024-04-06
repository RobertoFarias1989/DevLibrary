﻿using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibrary.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
     
        private readonly DevLibraryDbContext _dbContext;

        public UserRepository(DevLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
