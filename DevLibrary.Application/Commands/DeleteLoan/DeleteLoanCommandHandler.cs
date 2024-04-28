using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteLoanCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            //Informa a data do retorno do livro
            loan.ReturnedBook();

            await _loanRepository.SaveChangesAsync();

            //Consulta o livro que foi emprestado
            //Atualiza as quantidades em estoque e a quantidade emprestada
            var book = await _bookRepository.GetByIdAsync(loan.IdBook);

            book.ReturnedOnHand(loan.LoanedQuantity);

            await _bookRepository.SaveChangesAsync();            

            return Unit.Value;
        }
    }
}
