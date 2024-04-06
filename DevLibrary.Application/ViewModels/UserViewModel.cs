namespace DevLibrary.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
