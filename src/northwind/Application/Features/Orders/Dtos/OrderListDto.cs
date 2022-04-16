using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class OrderListDto
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmplooyeeId { get; set; }
        public string ContractName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
    }
}
