using DevLibrary.Application.ViewModels;
using MediatR;

namespace DevLibrary.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDetailsViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
