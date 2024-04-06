using DevLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllSync();
        Task<Book> GetDetailsByIdAsync(int id);
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task SaveChangesAsync();
    }
}
