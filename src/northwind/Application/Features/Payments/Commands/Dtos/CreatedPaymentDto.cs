using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.Dtos
{
    public  class CreatedPaymentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
