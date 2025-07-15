using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Domain.Interfaces
{
    public interface IDecisionRepository
    {
        Task<Decision?> GetByIdAsync(int id);
        Task<List<Decision>> GetAllAsync();
        Task<Decision?> GetByAccessRequestIdAsync(int accessRequestId);
        Task<Decision> CreateAsync(Decision decision);
        Task<Decision> UpdateAsync(Decision decision);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 