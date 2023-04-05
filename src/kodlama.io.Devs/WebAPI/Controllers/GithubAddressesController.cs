using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using Application.Features.GithubAddresses.Queries.GetAllGithubAddress;
using Application.Features.GithubAddresses.Queries.GetByIdGithubAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAddressesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllGithubAddressQuery getAllGithubAddressQuery = new()
            {
                PageRequest = pageRequest,
            };
            GithubAddressListModel result = await Mediator.Send(getAllGithubAddressQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubAddressQuery getByIdGithubAddressQuery)
        {
            GithubAddressGetByIdDto result = await Mediator.Send(getByIdGithubAddressQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubAddressCommand createGithubAddressCommand)
        {
            CreatedGithubAddressDto result = await Mediator.Send(createGithubAddressCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAddressCommand updateGithubAddressCommand)
        {
            UpdatedGithubAddressDto result = await Mediator.Send(updateGithubAddressCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubAddressCommand deleteGithubAddressCommand)
        {
            DeletedGithubAddressDto result = await Mediator.Send(deleteGithubAddressCommand);
            return Ok(result);
        }
    }
}
