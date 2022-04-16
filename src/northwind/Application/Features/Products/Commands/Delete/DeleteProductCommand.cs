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

namespace Application.Features.Products.Commands.Delete
{
    public  class DeleteProductCommand:IRequest<DeletedProductDto>
    {

        public int ProductId { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductDto>
        {
            IProductRepository _productRepository;
            IMapper _mapper;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {

                var product = _mapper.Map<Product>(request);
                var deletedProduct = await _productRepository.DeleteAsync(product);

                return _mapper.Map<DeletedProductDto>(deletedProduct);
            }
        }
    }
}
