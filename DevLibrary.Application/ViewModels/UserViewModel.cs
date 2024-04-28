namespace DevLibrary.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id,string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
