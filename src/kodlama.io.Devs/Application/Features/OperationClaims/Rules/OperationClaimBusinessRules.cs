using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(o => o.Name == name);
            if (result != null) throw new BusinessException("Operation claim name already exists.");
        }

        public async Task OperationClaimShouldExistWhenRequested(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(o => o.Id == id);
            if (result == null) throw new BusinessException("Operation claim does not exist.");

        }
    }
}
