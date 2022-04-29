using Application.Services.OutServices.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices.Adaptors
{
    public class FakeServiceAdaptor : IPosService
    {
      

        public bool MakePayment(PosRequest posRequest)
        {
            FakePosServices fakePosServices = new FakePosServices();

            return fakePosServices.MakePayment(posRequest.CreditCartNo,posRequest.HolderName, posRequest.ExpirationDate, posRequest.Csv,posRequest.Total);

        }
    }
}
