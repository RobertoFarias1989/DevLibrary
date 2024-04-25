using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;

        public DeleteLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            loan.ReturnedBook();

            await _loanRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
