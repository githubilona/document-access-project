using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public interface IDecisionService
    {
        Task<Decision> DecideAsync(int requestId, int approverId, bool isApproved, string? comment);
    }
} 
