using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Interfaces
{
    public interface IAccessRequestService
    {
        Task<AccessRequest> CreateAccessRequestAsync(int userId, int documentId, string reason, AccessType accessType);
        Task<List<AccessRequest>> GetAccessRequestsByUserAsync(int userId);
        Task<List<AccessRequest>> GetPendingAccessRequestsAsync();
        Task<AccessRequest?> GetAccessRequestsByIdAsync(int id);
    }
}
