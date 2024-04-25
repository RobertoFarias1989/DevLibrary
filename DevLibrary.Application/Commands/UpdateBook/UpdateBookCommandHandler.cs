using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear);

            //se o usuário tiver informado quantidades a serem adicionadas ou excluídas
            //ele atualiza o estoque do respectivo livro
            //no caso de reduzir a quantidade em estoque verifica também se ela não é negativa
            if (request.AddedQuantity != 0)
            {
                book.IncreaseOnHand(request.AddedQuantity);
            }
            else if(request.DecreseadQuantity != 0 && book.OnHand > 0)
            {
                book.DecreaseOnHand(request.DecreseadQuantity);
            }

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
