namespace DevLibrary.Application.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnedDate { get; private set; }
    }
}
