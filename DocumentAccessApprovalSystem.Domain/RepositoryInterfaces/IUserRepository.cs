using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<User?> GetByEmailAsync(string email);
    }
} 
