using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices.Request
{
    public class PosRequest
    {
        public string CreditCartNo { get; set; }
        public string HolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string Csv { get; set; }
        public decimal Total { get ;set; }
    }
}
