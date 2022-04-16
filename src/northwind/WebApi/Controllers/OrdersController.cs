using Application.Features.Orders.Queries;
using Core.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get/{employeeId}")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromRoute] int employeeId)

        {
            GetOrderListForEmployeeQuery  getOrderListForEmployeeQuery = new GetOrderListForEmployeeQuery { PageRequest = pageRequest , EmployeeId= employeeId};
            var list = await _mediator.Send(getOrderListForEmployeeQuery);

            return Ok(list);



        }
    }
}
