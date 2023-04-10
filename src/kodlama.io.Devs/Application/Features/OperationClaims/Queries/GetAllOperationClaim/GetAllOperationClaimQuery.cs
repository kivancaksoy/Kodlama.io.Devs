using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetAllOperationClaim
{
    public class GetAllOperationClaimQuery : IRequest<GetAllOperationClaimModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { OperationClaimOperationClaims.Admin };

        public class GetAllOperationClaimQueryHandler : IRequestHandler<GetAllOperationClaimQuery, GetAllOperationClaimModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetAllOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetAllOperationClaimModel> Handle(GetAllOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                GetAllOperationClaimModel getAllOperationClaimModel = _mapper.Map<GetAllOperationClaimModel>(operationClaims);

                return getAllOperationClaimModel;
            }
        }
    }
}
