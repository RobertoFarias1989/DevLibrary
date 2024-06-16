using DevLibrary.Core.Entities;
using DevLibrary.Core.Models;

namespace DevLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        Task<PaginationResult<Book>> GetAllAsync(string query, int page = 1);
        Task<Book> GetDetailsByIdAsync(int id);
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateBookAsync(Book book);
    }
}
