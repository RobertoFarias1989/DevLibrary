namespace DevLibrary.Application.ViewModels
{
    public class LoanDetailsViewModel
    {
        public LoanDetailsViewModel(int id, int idUser, int idBook, int loanedQuantity, DateTime loanDate, DateTime expectedReturnDate, DateTime? returnedDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanedQuantity = loanedQuantity;
            LoanDate = loanDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnedDate = returnedDate;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public int LoanedQuantity { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime? ReturnedDate { get; private set; }
    }
}
