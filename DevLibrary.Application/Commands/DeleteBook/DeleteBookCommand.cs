using MediatR;

namespace DevLibrary.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        //public string Status { get; private set; }
    }
}
