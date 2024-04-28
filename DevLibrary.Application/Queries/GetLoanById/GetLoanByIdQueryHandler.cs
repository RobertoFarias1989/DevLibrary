using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetLoanById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanDetailsViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<LoanDetailsViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan == null) return null;

            var loanDetailsViewModel = new LoanDetailsViewModel(
                loan.Id,
                loan.IdUser,
                loan.IdBook,
                loan.LoanedQuantity,
                loan.LoanDate,
                loan.ExpectedReturnDate,
                loan.ReturnedDate
                );

            return loanDetailsViewModel;
        }
    }
}
