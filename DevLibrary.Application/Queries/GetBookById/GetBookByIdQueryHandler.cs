using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Entities;
using DevLibrary.Core.Enums;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetDetailsByIdAsync(request.Id);

            if(book == null) return null;

            var loans = book.Loans
                .Where(l => l.IdBook == book.Id)
                .Select(l => new LoanDetailsViewModel(                
                    l.Id,
                    l.IdUser,
                    l.IdBook,
                    l.LoanedQuantity,
                    l.LoanDate,                    
                    l.ExpectedReturnDate,
                    l.ReturnedDate
                )).ToList();

            var bookDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationYear,
                book.LoanQuantity,
                book.OnHand,
                Enum.GetName(typeof(BookStatusEnum),book.Status),
                loans
                ); ;

            return bookDetailsViewModel;
        }
    }
}
