using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order:Entity
    {

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmplooyeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }

        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}
