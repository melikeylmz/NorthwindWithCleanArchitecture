using Application.Features.Payments.Commands.Dtos;
using Application.Services.OutServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConserns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.Create
{
    public  class CreatePaymentCommand: IRequest<CreatedPaymentDto>
    {
        public string CreditCartNo { get; set; }
        public string HolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string Csv { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatedPaymentDto>

        {

            IMapper _mapper;
            IPaymentRepository _paymentRepository;
            IPosService _postService;

            public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository, IPosService postService)
            {
                _mapper = mapper;
                _paymentRepository = paymentRepository;
                _postService = postService;
            }

            public async Task<CreatedPaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                if (_postService.MakePayment(request.CreditCartNo, request.HolderName, request.ExpirationDate, request.Csv, request.Total))

                {
                    var payment = _mapper.Map<Payment>(request);
                    var addPayment =await _paymentRepository.AddAsync(payment);

                    return _mapper.Map<CreatedPaymentDto>(addPayment);
                  }

                  else

                  throw new BusinessException("Hatalı kredi kartı ");


            }
        }
    }
}
