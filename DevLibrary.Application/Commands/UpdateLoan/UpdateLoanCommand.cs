using MediatR;

namespace DevLibrary.Application.Commands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Day { get; set; }

    }
}
