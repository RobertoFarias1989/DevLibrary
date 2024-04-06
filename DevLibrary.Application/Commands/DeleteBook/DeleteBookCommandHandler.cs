using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Unavailable();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
