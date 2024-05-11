using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Models;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<PaginationResult<UserViewModel>>
    {
        public GetAllUsersQuery(string query, int page)
        {
            Query = query;
            Page = page;
        }

        public string Query { get;  set; }
        public int Page { get; set; }
    }
}
