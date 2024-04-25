using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            
            //verificar primeiro se existem o usuário e o livro
            var user = _userRepository.GetByIdAsync(request.IdUser);

            var book = _bookRepository.GetByIdAsync(request.IdBook);

            //ver com o pessoal no sábado se esta é forma mais adequada
            if(user is null || book is null)
            {
                throw new ArgumentException("User, book or both of them are not existed.");
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

            await _loanRepository.AddLoanAsync(loan);

            //propósito aqui é reduzir a quantidade em estoque do livro emprestado
            var loanedBook = await _bookRepository.GetByIdAsync(request.IdBook);

            if(loanedBook != null)
            {
                loanedBook.DecreaseOnHand(request.LoanedQuantity);

                await _bookRepository.SaveChangesAsync();
            }            

            return Unit.Value;
        }
    }
}
