using Application.Features.ProgrammingLanguages.Constants;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetAllProgrammingLanguage
{
    public class GetAllProgrammingLanguageQuery : IRequest<GetAllProgrammingLanguageModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        //todo: constructor ile de değer atanabilir.
        public string[] Roles => new[] { ProgrammingLanguageOperationClaims.Admin, ProgrammingLanguageOperationClaims.Read };

        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetAllProgrammingLanguageQuery, GetAllProgrammingLanguageModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<GetAllProgrammingLanguageModel> Handle(GetAllProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GetAllProgrammingLanguageModel mappedProgrammingLanguageListModel = _mapper.Map<GetAllProgrammingLanguageModel>(programmingLanguages);

                return mappedProgrammingLanguageListModel;
            }
        }
    }
}
