using Application.Features.OperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : ControllerBase
    {


        IMediator _mediator;

        public OperationClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedOperationClaimCommand createdOperationClaim)

        {
            var createdOperation = await _mediator.Send(createdOperationClaim);

            return Created("", createdOperation);


        }

        [HttpPost("addUserOperationClaim")]
        public async Task<IActionResult> AddUserOperationClaim([FromBody] CreatedUserOperationClaimCommand createdUserOperationClaimCommand)

        {
            var createdUserOperationClaimDto = await _mediator.Send(createdUserOperationClaimCommand);

            return Created("", createdUserOperationClaimDto);


        }

    }
}
