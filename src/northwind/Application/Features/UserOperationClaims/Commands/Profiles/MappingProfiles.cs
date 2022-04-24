

using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Dtos;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(p => p.User.Email))
                .ForMember(p => p.OperationClaimName, opt => opt.MapFrom(p => p.OperationClaim.Name))
                .ReverseMap()
                ;
            CreateMap<UserOperationClaim, CreatedUserOperationClaimCommand>().ReverseMap();
        }

    }
}