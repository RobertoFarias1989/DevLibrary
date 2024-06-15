using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Models;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, PaginationResult<BookViewModel>>
    {       
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResult<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var paginationBooks = await _unitOfWork.BookRepository.GetAllAsync(request.Query, request.Page);

            var booksViewModel = paginationBooks
                .Data
                .Select(b => new BookViewModel(b.Id,b.Title,b.Author))
                .ToList();

            var paginationBooksViewModel = new PaginationResult<BookViewModel>(
                paginationBooks.Page,
                paginationBooks.TotalPages,
                paginationBooks.PageSize,
                paginationBooks.ItemsCount,
                booksViewModel
                );

            return paginationBooksViewModel;
        }
    }
}
