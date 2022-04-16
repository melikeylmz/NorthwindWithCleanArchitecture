using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<Order, OrderListDto>().ForMember(p => p.ContractName, opt => opt.MapFrom(p => p.Employee.FirstName +" " +p.Employee.LastName) );
            CreateMap<IPaginate<Order>, OrderListModel>().ReverseMap();
        }
    }
}
