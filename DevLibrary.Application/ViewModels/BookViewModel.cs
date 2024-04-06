namespace DevLibrary.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
    }
}
