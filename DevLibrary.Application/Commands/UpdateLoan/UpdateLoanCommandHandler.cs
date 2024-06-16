using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {       
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

            //Só pode renovar o empréstimo de um livro que não foi entregue.
            if(loan.ReturnedDate == null)
            {
                loan.RenewLoan(request.RenewLoanedDay);

                await _unitOfWork.LoanRepository.UpdateLoanAsync(loan);

                await _unitOfWork.CompleteAsync();
            }
            else
            {
                //throw new Exception("It is not allow to renew a loan more than once.");

                throw new Exception("This book already returned.");
            }

            return Unit.Value;
        }
    }
}
