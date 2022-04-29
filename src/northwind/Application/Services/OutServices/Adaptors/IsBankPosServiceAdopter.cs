using Application.Services.OutServices.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices.Adaptors
{
    internal class IsBankPosServiceAdopter : IPosService
    {
      

        public bool MakePayment(PosRequest posRequest)
        {
            IsBankPosService isBankPosService = new IsBankPosService();

            return isBankPosService.Pay(posRequest.Total,posRequest.CreditCartNo, posRequest.HolderName, posRequest.ExpirationDate, posRequest.Csv);

        }
    } 
}
