using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;
        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            loan.ReturnedBook(request.ReturnedDate);

            await _loanRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
