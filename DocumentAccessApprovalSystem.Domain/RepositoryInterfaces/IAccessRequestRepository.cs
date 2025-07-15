using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Domain.Interfaces
{
    public interface IAccessRequestRepository
    {
        Task<AccessRequest?> GetByIdAsync(int id);
        Task<List<AccessRequest>> GetAllAsync();
        Task<List<AccessRequest>> GetByUserAsync(int userId);
        Task<List<AccessRequest>> GetPendingAsync();
        Task<AccessRequest> CreateAsync(AccessRequest accessRequest);
        Task<AccessRequest> UpdateAsync(AccessRequest accessRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 
