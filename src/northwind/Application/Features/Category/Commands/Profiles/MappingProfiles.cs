using Application.Features.Category.Commands.Create;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.Category.Commands.Dtos;

namespace Application.Features.Category.Commands.Profiles
{
    public  class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Domain.Entities.Category, CreatedCategoryDto>().ReverseMap();
        }
    }
}
