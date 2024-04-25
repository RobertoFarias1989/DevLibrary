using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Entities;
using DevLibrary.Core.Enums;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetDetailsByIdAsync(request.Id);

            if(book == null) return null;

            var loans = book.Loans
                .Where(l=> l.IdBook == book.Id)
                .Select(l=>new LoanViewModel 
                { 
                    Id = l.Id,
                    IdUser = l.IdUser,
                    IdBook = l.IdBook,
                    LoanDate = l.LoanDate,
                    ExpectedReturnDate = l.ExpectedReturnDate,
                    ReturnedDate = l.ReturnedDate
                }).ToList();

            var bookDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationYear,
                book.OnHand,
                Enum.GetName(typeof(BookStatusEnum),book.Status),
                loans
                ); ;

            return bookDetailsViewModel;
        }
    }
}
