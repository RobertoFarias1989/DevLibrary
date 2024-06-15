using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLoanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

            //Informa a data do retorno do livro
            loan.ReturnedBook();

            await _unitOfWork.CompleteAsync();

            //Consulta o livro que foi emprestado
            //Atualiza as quantidades em estoque e a quantidade emprestada
            var book = await _unitOfWork.BookRepository.GetByIdAsync(loan.IdBook);

            book.ReturnedOnHand(loan.LoanedQuantity);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
