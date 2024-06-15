namespace DevLibrary.Core.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        ILoanRepository LoanRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}
