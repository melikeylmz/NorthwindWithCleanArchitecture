using Application.Features.Payments.Commands.Create;
using Application.Features.Payments.Commands.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.Profiles
{
    public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<CreatePaymentCommand, Payment>().ReverseMap();
            CreateMap<CreatedPaymentDto, Payment>().ReverseMap();
        }
    }
}
