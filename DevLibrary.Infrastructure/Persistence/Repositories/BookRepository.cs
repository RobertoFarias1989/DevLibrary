using DevLibrary.Core.Entities;
using DevLibrary.Core.Models;
using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibrary.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DevLibraryDbContext _dbContext;
        private const int PAGE_SIZE = 2;

        public BookRepository(DevLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Book>> GetAllAsync(string query, int page)
        {
            IQueryable<Book> books = _dbContext.Books;

            if (!string.IsNullOrEmpty(query))
            {
                books = books
                    .Where(b =>
                    b.Title.Contains(query) 
                    || b.Author.Contains(query) 
                    || b.PublicationYear.ToString().Contains(query));
            }

            return await books.GetPaged<Book>(page, PAGE_SIZE);
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
            
        }

    }
}
