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
    public class GetAllGithubAddressQuery : IRequest<GithubAddressListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllGithubAddressQueryHandler : IRequestHandler<GetAllGithubAddressQuery, GithubAddressListModel>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public GetAllGithubAddressQueryHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<GithubAddressListModel> Handle(GetAllGithubAddressQuery request, CancellationToken cancellationToken)
            {

                IPaginate<GithubAddress> githubAddresses = await _githubAddressRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: g => g.Include(c => c.User)
                    );

                GithubAddressListModel mappedGithubAddressListModel = _mapper.Map<GithubAddressListModel>(githubAddresses);
                return mappedGithubAddressListModel;
            }
        }
    }
}
