namespace DevLibrary.Application.ViewModels
{
    public class LoanDetailsViewModel
    {
        public LoanDetailsViewModel(int id, int idUser, int idBook, DateTime loanDate, DateTime returnedDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
            ReturnedDate = returnedDate;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnedDate { get; private set; }
    }
}
