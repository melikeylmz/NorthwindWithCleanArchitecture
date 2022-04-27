using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices
{
    public class FakePosServices
    {

        public bool MakePayment(string creditCartNo, string holderName, string expirationDate, string csv, decimal total)

        {
            Random random = new Random();
            int number = random.Next(1, 100);

            return number%2==0;

        }     
           
    }
}
