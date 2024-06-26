﻿using DevLibrary.Application.ViewModels;
using DevLibrary.Core.Models;
using DevLibrary.Core.Repositories;
using MediatR;

namespace DevLibrary.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginationResult<UserViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResult<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var paginationUsers =  await _unitOfWork.UserRepository.GetAllAsync(request.Query, request.Page);

            var userViewModel = paginationUsers
                .Data
                .Select(u => new UserViewModel(u.Id, u.Name, u.Email))
                .ToList();

            var paginationUsersViewModel = new PaginationResult<UserViewModel>(
                paginationUsers.Page,
                paginationUsers.TotalPages,
                paginationUsers.PageSize,
                paginationUsers.ItemsCount,
                userViewModel
                );

            return paginationUsersViewModel;
        }
    }
}
