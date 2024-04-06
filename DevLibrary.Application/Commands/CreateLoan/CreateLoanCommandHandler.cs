using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.IdUser, request.IdBook);

            await _loanRepository.AddLoanAsync(loan);

            return Unit.Value;
        }
    }
}
