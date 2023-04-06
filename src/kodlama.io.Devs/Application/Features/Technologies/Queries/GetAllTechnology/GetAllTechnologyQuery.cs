using Application.Features.Technologies.Models;
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

namespace Application.Features.Technologies.Queries.GetAllTechnology
{
    public class GetAllTechnologyQuery : IRequest<GetAllTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetAllTechnologyQuery, GetAllTechnologyModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<GetAllTechnologyModel> Handle(GetAllTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(
                    include: t => t.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize
                    );

                GetAllTechnologyModel mappedTechnologyListModel = _mapper.Map<GetAllTechnologyModel>(technologies);

                return mappedTechnologyListModel;
            }
        }
    }
}
