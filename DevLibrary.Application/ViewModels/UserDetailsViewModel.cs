namespace DevLibrary.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(int id,
            string name, string email,DateTime createdAt,bool active, string role, List<LoanDetailsViewModel> loans)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            Active = active;
            Role = role;
            Loans = loans;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Role { get; private set; }
        public List<LoanDetailsViewModel> Loans { get; private set; }
    }
}
