using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices
{
    public  interface IPosService
    {
        bool MakePayment(string creditCartNo, string holderName, string expirationDate, string csv, decimal total);
        
    }
}
