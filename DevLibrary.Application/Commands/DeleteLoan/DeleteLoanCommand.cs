using MediatR;

namespace DevLibrary.Application.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<Unit>
    {
        public DeleteLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        //public DateTime ReturnedDate { get; private set; }
    }
}
