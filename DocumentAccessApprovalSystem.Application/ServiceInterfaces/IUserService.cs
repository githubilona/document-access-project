using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
    }
}
