using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibrary.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DevLibraryDbContext _dbContext;

        public LoanRepository(DevLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
           return await _dbContext.Loans.AsNoTracking().ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


    }
}
