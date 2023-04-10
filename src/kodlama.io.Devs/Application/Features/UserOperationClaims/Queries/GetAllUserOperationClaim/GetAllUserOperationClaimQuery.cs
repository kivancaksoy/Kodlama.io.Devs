using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetAllUserOperationClaim
{
    public class GetAllUserOperationClaimQuery : IRequest<GetAllUserOperationClaimModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = new[] { UserOperationClaimOperationClaims.Admin };

        public class GetAllUserOperationClaimQueryHandler : IRequestHandler<GetAllUserOperationClaimQuery, GetAllUserOperationClaimModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetAllUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetAllUserOperationClaimModel> Handle(GetAllUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                     index: request.PageRequest.Page,
                     size: request.PageRequest.PageSize,
                     include: u => u.Include(c => c.User).Include(d => d.OperationClaim)
                     );

                GetAllUserOperationClaimModel getAllUserOperationModel = _mapper.Map<GetAllUserOperationClaimModel>(userOperationClaims);

                return getAllUserOperationModel;
            }
        }
    }
}
