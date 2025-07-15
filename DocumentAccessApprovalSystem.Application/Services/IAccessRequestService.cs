using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public interface IAccessRequestService
    {
        Task<AccessRequest> CreateAccessRequestAsync(int userId, int documentId, string reason, AccessType accessType);
        Task<List<AccessRequest>> GetRequestsByUserAsync(int userId);
        Task<List<AccessRequest>> GetPendingRequestsAsync();
        Task<AccessRequest?> GetByIdAsync(int id);
    }
} 
