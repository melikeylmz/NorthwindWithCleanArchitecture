using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices
{
    public class IsBankPosService
    {
        public bool Pay(decimal total,string creditCartNo, string holderName, string expirationDate, string csv)

        {
            Random random = new Random();
            int number = random.Next(1, 100);

            return number % 2 == 0;

        }
    }
}
