using DevLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task AddLoanAsync(Loan loan);
        Task<Loan> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
