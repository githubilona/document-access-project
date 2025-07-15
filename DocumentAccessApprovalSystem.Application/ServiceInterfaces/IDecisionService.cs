using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Interfaces
{
    public interface IDecisionService
    {
        Task<Decision> DecideAsync(int requestId, int approverId, bool isApproved, string? comment);
    }
}
