using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLoansQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.LoanRepository.GetAllAsync();

            var loanViewModel = loan
                .Select(l=> new LoanViewModel(l.Id,l.IdUser,l.IdBook))
                .ToList();

            return loanViewModel;
        }
    }
}
