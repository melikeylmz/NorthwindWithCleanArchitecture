using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdatedProductDto>
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>

        {

            IProductRepository _productRepository;
            IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {

                Product product = _mapper.Map<Product>(request);
                var updatedProduct =await _productRepository.UpdateAsync(product);  
                return  _mapper.Map<UpdatedProductDto>(updatedProduct);
              
            }
        }


    }
}
