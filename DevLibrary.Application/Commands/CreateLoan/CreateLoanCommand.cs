using MediatR;

namespace DevLibrary.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<Unit>
    {
        public int IdUser { get;  set; }
        public int IdBook { get;  set; }

        //criei esta propriedade somente para receber a quantidade emprestada e poder atualizar
        // a quantidade em estoque do respectivo livro
        public int LoanedQuantity { get; set; }

        //usuário informa a quantidade de dias do empréstimo e a data de expectativa de retorno
        //será calculada automaticamente
        public int NumberLoanDay { get;  set; }
    }
}
