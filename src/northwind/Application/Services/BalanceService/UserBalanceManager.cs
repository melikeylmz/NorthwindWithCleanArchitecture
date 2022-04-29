using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.BalanceService
{
    public class UserBalanceManager : IUserBalanceService
    {

        public IUserBalanceRepository _userBalance;

        public UserBalanceManager(IUserBalanceRepository userBalance)
        {
            _userBalance = userBalance;
        }
      
       public async Task<UserBalance> GetBalancesAsync(int userId)
        {
            return await _userBalance.GetAsync(s => s.UserId == userId);
        }

       public async Task<UserBalance> UpdateUserBalance(UserBalance userBalance)
        {

            var userBalanceUpdate = await _userBalance.UpdateAsync(userBalance);
            return userBalanceUpdate;
        }
      
    }
}
