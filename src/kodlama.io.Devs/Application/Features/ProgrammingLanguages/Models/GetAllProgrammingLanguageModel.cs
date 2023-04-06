using Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class GetAllProgrammingLanguageModel : BasePageableModel
    {
        public IList<GetAllProgrammingLanguageDto> Items { get; set; }
    }
}
