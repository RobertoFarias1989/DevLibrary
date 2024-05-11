using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Models;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<PaginationResult<BookViewModel>>
    {
        public GetAllBooksQuery(string query, int page)
        {
            Query = query;
            Page = page;
        }

        public string Query { get;   set; }
        public int Page { get; set; }
    }
}
