using DevLibrary.Core.Entities;
using DevLibrary.Core.Repositories;
using DevLibrary.Core.Services;
using MediatR;

namespace DevLibrary.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    { 
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.Name, request.Email, passwordHash, request.Role);

            await _unitOfWork.UserRepository.AddUserAsync(user);

            await _unitOfWork.CompleteAsync();

            return user.Id;
        }
    }
}
