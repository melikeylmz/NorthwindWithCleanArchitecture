using Application.Features.Payments.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePaymentCommand createPaymentCommand)

        {
            var createdPaymentDto = await _mediator.Send(createPaymentCommand);

            return Created("", createdPaymentDto);



        }
    }
}
