using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Rules
{
    public class GithubAddressBusinessRules
    {
        private readonly IGithubAddressRepository _githubAddressRepository;

        public GithubAddressBusinessRules(IGithubAddressRepository githubAddressRepository)
        {
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task GithubAddressCanNotBeDuplicatedWhenInsertedOrUpdated(string address)
        {
            IPaginate<GithubAddress> result = await _githubAddressRepository.GetListAsync(p => p.Address == address);
            if (result.Items.Any()) throw new BusinessException("Github address exists.");
        }

        public void GithubAddressShouldExistWhenRequested(GithubAddress githubAddress)
        {
            if (githubAddress == null) throw new BusinessException("Github address does not exist.");
        }
    }
}
