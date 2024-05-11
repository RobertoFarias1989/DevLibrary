using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Models;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<PaginationResult<BookViewModel>>
    {
        public string Query { get;   set; }
        public int Page { get;  set; } = 1;
    }
}
