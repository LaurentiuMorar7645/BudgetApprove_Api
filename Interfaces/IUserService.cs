using BudgetApprovedApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApprovedApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> AddUserAsync(UserModel user);
    }
}
