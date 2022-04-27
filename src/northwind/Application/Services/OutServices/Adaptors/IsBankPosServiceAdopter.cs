using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices.Adaptors
{
    internal class IsBankPosServiceAdopter : IPosService
    {
        public bool MakePayment(string creditCartNo, string holderName, string expirationDate, string csv, decimal total)
        {
            IsBankPosService isBankPosService = new IsBankPosService();
            return isBankPosService.Pay(total, creditCartNo, holderName, expirationDate, csv);

        }
    } 
}
