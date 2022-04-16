using Application.Features.Orders.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries
{
    public class GetOrderListForEmployeeQuery : IRequest<OrderListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int EmployeeId { get; set; }

        public class GetOrderListForEmployeeQueryHandler : IRequestHandler<GetOrderListForEmployeeQuery, OrderListModel>
        {


            IOrderRepository _orderRepository;
            IMapper _mapper;

            public GetOrderListForEmployeeQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderListModel> Handle(GetOrderListForEmployeeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> orders = await _orderRepository.GetListAsync(p => p.EmplooyeeId == request.EmployeeId, include: p => p.Include(p => p.Employee),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize



                    );
                OrderListModel orderListModel = _mapper.Map<OrderListModel>(orders);
                return orderListModel;
            }
        }
    }
}
