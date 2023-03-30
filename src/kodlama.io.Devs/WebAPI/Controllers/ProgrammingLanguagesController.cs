using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {

            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new GetListProgrammingLanguageQuery() { PageRequest = pageRequest };
            var aa = getListProgrammingLanguageQuery;
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
