using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Technology does not exist.");
        }

        public async Task TechnologyNameCanNotDublicatedWhenInsertedOrUpdated(string name, int programmingLanguageId)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(t => t.Name == name && t.ProgrammingLanguageId == programmingLanguageId);
            if (result.Items.Any()) throw new BusinessException("Technology name exists.");
        }
    }
}
