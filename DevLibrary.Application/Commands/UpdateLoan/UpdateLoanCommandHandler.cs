using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            loan.RenewLoan(request.Day);

            await _loanRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
