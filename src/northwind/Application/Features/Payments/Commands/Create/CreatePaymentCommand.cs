using Application.Features.Payments.Commands.Dtos;
using Application.Features.Payments.Rules;
using Application.Services.BalanceService;
using Application.Services.OutServices;
using Application.Services.OutServices.Request;
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
            CreatePaymentBussinessRules _createPaymentBussinessRules;
            IUserBalanceService _userBalanceService;

            public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository, IPosService postService, CreatePaymentBussinessRules createPaymentBussinessRules, IUserBalanceService userBalanceService)
            {
                _mapper = mapper;
                _paymentRepository = paymentRepository;
                _postService = postService;
                _createPaymentBussinessRules = createPaymentBussinessRules;
                _userBalanceService = userBalanceService;
            }

            public async Task<CreatedPaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {


                _createPaymentBussinessRules.CheckExpirationDate(request.ExpirationDate);
                PosRequest  posRequest=new PosRequest { Total=request.Total,CreditCartNo=request.CreditCartNo,
                ExpirationDate=request.ExpirationDate, Csv=request.Csv,HolderName=request.HolderName
                };
                var UserBalance = (await _userBalanceService.GetBalancesAsync(request.UserId));
                if (request.Total <= UserBalance.Balance)
                {
                    if (_postService.MakePayment(posRequest))
                {
                    var payment = _mapper.Map<Payment>(request);
                        var addPayment = await _paymentRepository.AddAsync(payment);
                        CreatedPaymentDto  createdPaymentDto = _mapper.Map<CreatedPaymentDto>(addPayment);
                        var userBalance= new UserBalance { UserId=UserBalance.UserId,Id=UserBalance.Id, Balance=UserBalance.Balance-request.Total };
                        
                         _userBalanceService.UpdateUserBalance(userBalance);
                       
                        
                        return createdPaymentDto;


                    }

                    else

                        throw new BusinessException("Hatalı kredi kartı ");

            }
                else throw new BusinessException("Yetersiz Bakiye ");
        }
        }
    }
}
