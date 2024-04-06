using DevLibrary.Core.Enums;

namespace DevLibrary.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int publicationYear, int onHand)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            OnHand = onHand;

            Status = BookStatusEnum.Available;
            Loans = new List<Loan>();
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public int OnHand { get; private set; }
        public BookStatusEnum Status { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void Update(string title, string author, string iSBN, int publicationYear, int onHand)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            OnHand = onHand;
        }

        public void Unavailable()
        {
            if(Status == BookStatusEnum.Available)
            {
                Status = BookStatusEnum.Unavailable;
            }
        }

        public void DecreaseOnHand(int onHand)
        {
            OnHand -= onHand;
        }
    }
}
