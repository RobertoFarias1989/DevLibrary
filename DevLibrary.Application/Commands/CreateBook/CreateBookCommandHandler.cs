using DevLibrary.Core.Entities;
using DevLibrary.Core.Enums;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var book = new Book(request.Title,
                request.Author,
                request.ISBN,
                request.PublicationYear);

            book.IncreaseOnHand(request.AddedQuantity);

            await _bookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
