using MediatR;

namespace DevLibrary.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public string Role { get;  set; }
    }
}
