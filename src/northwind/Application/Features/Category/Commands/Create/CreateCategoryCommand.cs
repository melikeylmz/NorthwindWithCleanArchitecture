using Application.Features.Category.Commands.Dtos;
using Application.Features.Category.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Create
{
    public  class CreateCategoryCommand:IRequest<CreatedCategoryDto>, ILoggableRequest
    {
        public string CategoryName { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
        {
            ICategoryRepository _categoryRepository;
            IMapper _mapper;
            CategoryBusinessRules _categoryBusinessRules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.MaxCategoryLimit();
                await _categoryBusinessRules.CategoryNameShouldNotBeExisted(request.CategoryName);
                return _mapper.Map<CreatedCategoryDto>(await _categoryRepository.AddAsync(_mapper.Map<Domain.Entities.Category>(request)));
            }

        }
        }
    }

