using Application.Features.GithubAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetAllGithubAddress
{
    public class GetAllGithubAddressQuery : IRequest<GetAllGithubAddressModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllGithubAddressQueryHandler : IRequestHandler<GetAllGithubAddressQuery, GetAllGithubAddressModel>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public GetAllGithubAddressQueryHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<GetAllGithubAddressModel> Handle(GetAllGithubAddressQuery request, CancellationToken cancellationToken)
            {

                IPaginate<GithubAddress> githubAddresses = await _githubAddressRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: g => g.Include(c => c.User)
                    );

                GetAllGithubAddressModel mappedGithubAddressListModel = _mapper.Map<GetAllGithubAddressModel>(githubAddresses);
                return mappedGithubAddressListModel;
            }
        }
    }
}
