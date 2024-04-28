namespace DevLibrary.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
        }

        public int Id { get;  set; }
        public int IdUser { get;  set; }
        public int IdBook { get;  set; }

    }
}
