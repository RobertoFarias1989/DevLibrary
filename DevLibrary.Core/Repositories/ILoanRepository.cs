using DevLibrary.Core.Entities;

namespace DevLibrary.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task AddLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task<Loan> GetByIdAsync(int id); 
    }
}
