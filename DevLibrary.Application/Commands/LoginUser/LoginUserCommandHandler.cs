using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Repositories;
using DevLibrary.Core.Services;
using MediatR;

namespace DevLibrary.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;  
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //Se não existir, erro no login
            if (user == null)
            {
                return null;
            }

            //Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);

        }
    }
}
