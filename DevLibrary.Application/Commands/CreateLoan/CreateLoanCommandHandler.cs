using DevLibrary.Core.Entities;
using DevLibrary.Core.Enums;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            
            //verificar primeiro se existem o usuário e o livro
            var user = _unitOfWork.UserRepository.GetByIdAsync(request.IdUser);

            var book = _unitOfWork.BookRepository.GetByIdAsync(request.IdBook);

            //ver com o pessoal no sábado se esta é forma mais adequada
            if(user is null || book is null)
            {
                throw new ArgumentException("User, book or both of them are not existed.");
            }

            //Livros com status unavailable não podem ser objeto de empréstimo

            if(book.Result.Status == BookStatusEnum.Unavailable)
            {
                throw new ArgumentException("This book is unavailable for a loan.");
            }

            //Somente um exemplar por empréstimo
            if (request.LoanedQuantity > 1)
                throw new Exception("Only one copy of the book can be loaned it");

            //Somente 5 dias por empréstimo
            if(request.NumberLoanDay > 5)
                throw new Exception("You only can get a book during 5 days.");

            //monta o objeto para ser salvo
            var loan = new Loan(request.IdUser, request.IdBook);

            loan.ExpectedReturnedDate(request.NumberLoanDay);

            await _unitOfWork.LoanRepository.AddLoanAsync(loan);

            await _unitOfWork.CompleteAsync();

            //propósito aqui é reduzir a quantidade em estoque do livro emprestado
            var loanedBook = await _unitOfWork.BookRepository.GetByIdAsync(request.IdBook);

            if(loanedBook != null)
            {
                loanedBook.DecreaseOnHand(request.LoanedQuantity);

                await _unitOfWork.CompleteAsync();
            }            

            return Unit.Value;
        }
    }
}
