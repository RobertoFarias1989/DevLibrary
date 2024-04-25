using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            //só pode mudar o status de livros que estiverem available
            //perguntar se esta é a melhor forma de enviar uma mensagem para o usuário
            //que ele não pode realizar esta operação
            if(book.Status == Core.Enums.BookStatusEnum.Available)
            {
                book.Unavailable();

                await _bookRepository.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The book's status is already unavailable.");
            }
         

            return Unit.Value;
        }
    }
}
