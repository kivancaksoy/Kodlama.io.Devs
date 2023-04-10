using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
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

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery : IRequest<GetByUserIdUserOperationClaimModel>, ISecuredRequest
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = new[] { UserOperationClaimOperationClaims.Admin };

        public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, GetByUserIdUserOperationClaimModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<GetByUserIdUserOperationClaimModel> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = 
                    await _userOperationClaimRepository.GetListAsync(
                        u => u.UserId == request.UserId, 
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize,
                        include: c => c.Include(d => d.User).Include(e => e.OperationClaim));

                GetByUserIdUserOperationClaimModel getByUserIdUserOperationClaimModel =
                    _mapper.Map<GetByUserIdUserOperationClaimModel>(userOperationClaims);
                return getByUserIdUserOperationClaimModel;
            }
        }
    }
}
