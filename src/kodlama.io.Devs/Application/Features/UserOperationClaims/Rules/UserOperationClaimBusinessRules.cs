using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task DoesUserHaveThisOperationClaim(int userId, int operationClaimId)
        {
            UserOperationClaim? result =
                 await _userOperationClaimRepository.GetAsync(u => u.UserId == userId && u.OperationClaimId == operationClaimId);
            if (result != null) throw new BusinessException("User already has this operation claim.");
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User operation claim does not exists.");
        }
    }
}
