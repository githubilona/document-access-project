using DocumentAccessApprovalSystem.Application.Interfaces;
using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public class DecisionService : IDecisionService
    {
        private readonly IAccessRequestRepository _accessRequestRepository;
        private readonly IDecisionRepository _decisionRepository;
        private readonly IUserRepository _userRepository;

        public DecisionService(
            IAccessRequestRepository accessRequestRepository,
            IDecisionRepository decisionRepository,
            IUserRepository userRepository)
        {
            _accessRequestRepository = accessRequestRepository;
            _decisionRepository = decisionRepository;
            _userRepository = userRepository;
        }

        public async Task<Decision> DecideAsync(int requestId, int approverId, bool isApproved, string? comment)
        {
            var request = await _accessRequestRepository.GetByIdAsync(requestId);
            if (request == null)
            {
                throw new ArgumentException("Request not found", nameof(requestId));
            }

            if (request.Status != AccessRequestStatus.Pending)
            {
                throw new InvalidOperationException("Request has already been processed");
            }

            var approver = await _userRepository.GetByIdAsync(approverId);
            if (approver == null)
            {
                throw new ArgumentException("Approver not found", nameof(approverId));
            }

            if (approver.Role != UserRole.Approver && approver.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("User is not authorized to approve requests");
            }

            request.Status = isApproved ? AccessRequestStatus.Approved : AccessRequestStatus.Rejected;

            var decision = new Decision
            {
                AccessRequestId = requestId,
                ApproverId = approverId,
                IsApproved = isApproved,
                Comment = comment,
                DecidedAt = DateTime.UtcNow
            };

            await _decisionRepository.CreateAsync(decision);
            await _accessRequestRepository.UpdateAsync(request);

            return decision;
        }
    }
} 
