using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices.Adaptors
{
    public class FakeServiceAdaptor : IPosService
    {
        public bool MakePayment(string creditCartNo, string holderName, string expirationDate, string csv, decimal total)
        {
          FakePosServices fakePosServices = new FakePosServices();

            return fakePosServices.MakePayment(creditCartNo, holderName, expirationDate, csv, total);
        }
    }
}
