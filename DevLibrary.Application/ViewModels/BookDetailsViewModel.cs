namespace DevLibrary.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id,
            string title,
            string author,
            string iSBN,
            int publicationYear,
            int loanQuantity,
            int onHand,
            string status,
            List<LoanDetailsViewModel> loans)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            LoanQuantity = loanQuantity;
            OnHand = onHand;
            Status = status;
            Loans = loans;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public int LoanQuantity { get; private set; }
        public int OnHand { get; private set; }
        public string Status { get; private set; }
        public List<LoanDetailsViewModel> Loans { get; private set; }
    }
}
