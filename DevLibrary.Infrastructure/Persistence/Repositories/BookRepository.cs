using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibrary.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DevLibraryDbContext _dbContext;

        public BookRepository(DevLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllSync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Books
                .Include(b => b.Loans)
                .SingleOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
