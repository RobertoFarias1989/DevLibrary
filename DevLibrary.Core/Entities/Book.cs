using DevLibrary.Core.Enums;

namespace DevLibrary.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;

            Status = BookStatusEnum.Available;
            Loans = new List<Loan>();
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public int LoanQuantity { get; private set; } 
        public int OnHand { get; private set; }
        public BookStatusEnum Status { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void Update(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public void Unavailable()
        {
            if(Status == BookStatusEnum.Available)
            {
                Status = BookStatusEnum.Unavailable;
            }
        }

        public void IncreaseOnHand(int increasedQuantity)
        {
            OnHand += increasedQuantity;
        }

        public void DecreaseOnHand(int decreasedQuantity)
        {
            LoanQuantity += decreasedQuantity;
            OnHand -= decreasedQuantity;
        }

        public void ReturnedOnHand(int returnedQuantity)
        {
            LoanQuantity -= returnedQuantity;
            OnHand += returnedQuantity;
        }
    }
}
