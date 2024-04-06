using DevLibrary.Application.ViewModels;
using MediatR;

namespace DevLibrary.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailsViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
