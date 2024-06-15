using DevLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevLibrary.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevLibraryDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DevLibraryDbContext dbContext, IBookRepository bookRepository, ILoanRepository loanRepository, IUserRepository userRepository)
        {
            _dbContext = dbContext;     
            BookRepository = bookRepository;
            LoanRepository = loanRepository;
            UserRepository = userRepository;
        }

        public IBookRepository BookRepository { get; }

        public ILoanRepository LoanRepository { get; }

        public IUserRepository UserRepository { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();

                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
