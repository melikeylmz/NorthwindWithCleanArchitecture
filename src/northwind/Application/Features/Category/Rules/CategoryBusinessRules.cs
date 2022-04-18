using Application.Services.Repositories;
using Core.CrossCuttingConserns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Rules
{
    public class CategoryBusinessRules
    {

        ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameShouldNotBeExisted(string name)

        {

            Domain.Entities.Category? result = await _categoryRepository.GetAsync(p => p.CategoryName == name);
            if (result != null) throw new BusinessException("category zaten var");
        }


        public async Task MaxCategoryLimit()

        {
            int    result =( await _categoryRepository.GetListAsync()).Count;
            if (result >=15) throw new BusinessException("en fazla 15 category eklenir.");
        }
    }
}
