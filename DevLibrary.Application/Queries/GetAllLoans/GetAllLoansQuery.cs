using DevLibrary.Application.ViewModels;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
    {

    }
}
