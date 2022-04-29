using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BalanceService
{
    public  interface IUserBalanceService
    {

      Task<UserBalance> UpdateUserBalance(UserBalance userBalance);
       Task<UserBalance> GetBalancesAsync( int userId);
    }
}
