using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Dtos
{
    public class CreatedCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
