﻿using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetUser
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetDetailsByIdAsync(request.Id);

            if (user == null) return null;

            var loans = user.Loans
                .Where(l => l.IdUser == request.Id)
                .Select(l => new LoanDetailsViewModel(
                    l.Id,
                    l.IdUser,
                    l.IdBook,
                    l.LoanedQuantity,
                    l.LoanDate,
                    l.ExpectedReturnDate,
                    l.ReturnedDate
                )).ToList();

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
