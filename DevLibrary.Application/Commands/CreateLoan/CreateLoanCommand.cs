using MediatR;

namespace DevLibrary.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<Unit>
    {
        public int IdUser { get;  set; }
        public int IdBook { get;  set; }
    }
}
