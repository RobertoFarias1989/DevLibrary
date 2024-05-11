using DevLibrary.Core.Entities;
using DevLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Core.Repositories
{
    public interface IUserRepository
    {
        Task<PaginationResult<User>> GetAllAsync(string query, int page = 1);
        Task<User> GetByIdAsync(int id);
        Task<User> GetDetailsByIdAsync(int id);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
