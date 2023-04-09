using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetAllUserOperationClaim;
using Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllUserOperationClaimQuery getAllUserOperationClaimQuery = new() { PageRequest = pageRequest };

            GetAllUserOperationClaimModel result = await Mediator.Send(getAllUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        {
            GetByIdUserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet("[action]/{UserId}/{PageRequest.Page}/{PageRequest.PageSize}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdUserOperationClaimQuery getByUserIdUserOperationClaimQuery)
        {
            //getByUserIdUserOperationClaimQuery.PageRequest = pageRequest;
            GetByUserIdUserOperationClaimModel result = await Mediator.Send(getByUserIdUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(result);
        }
    }
}
