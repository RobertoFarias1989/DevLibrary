using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetDetailsByIdAsync(request.Id);

            if (user == null) return null;

            var loans = user.Loans
                .Where(l => l.IdUser == request.Id)
                .Select(l => new LoanViewModel
                {
                    Id = l.Id,
                    IdUser = l.IdUser,
                    IdBook = l.IdBook,
                    LoanDate = l.LoanDate,
                    ExpectedReturnDate = l.ExpectedReturnDate,
                    ReturnedDate = l.ReturnedDate,
                }).ToList();

            var userDetailsViewModel = new UserDetailsViewModel
                (user.Id,
                user.Name,
                user.Email,
                user.CreatedAt,
                user.Active,
                user.Role,
                loans);

            return userDetailsViewModel;
        }
    }
}
