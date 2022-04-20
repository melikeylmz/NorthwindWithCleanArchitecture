using Application.Features.Products.Commands.Dtos;
using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;
using Application.Features.Products.Rules;
using Core.Mailing;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand:IRequest<CreatedProductDto>
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
        {

            IProductRepository _productRepository;
            IMapper _mapper;
            ProductBusinessRules _productBusinessRules;
            IMailService _mailService;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, IMailService mailService)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
                _mailService = mailService;
            }

            public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                await _productBusinessRules.ProductNameShouldNotBeExistesd(request.ProductName);

                Mail mail = new Mail { ToFullName="melike yılmaz", ToEmail="melike.yilmaz@csgb.gov.tr",
                Subject="test",
                HtmlBody="test",
                TextBody="test",

                };

                _mailService.SendMail(mail);
                return _mapper.Map<CreatedProductDto>(await _productRepository.AddAsync(_mapper.Map<Product>(request)));
            }
        }

    }
}
