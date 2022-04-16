using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Dtos;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries;
using Core.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)

        {
            CreatedProductDto createdProductDto = await _mediator.Send(createProductCommand);

            return Created("", createdProductDto);



        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)

        {
         
             var dto = await _mediator.Send(updateProductCommand);

            return Ok(dto);


        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)

        {
            var dto =await _mediator.Send(deleteProductCommand);

            return Ok(dto);



        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)

        {
            GetProductListQuery  getProductListQuery =new GetProductListQuery { PageRequest = pageRequest };
            var list = await _mediator.Send(getProductListQuery);

            return Ok(list);



        }
    }
}
