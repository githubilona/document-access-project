using DocumentAccessApprovalSystem.Application.Interfaces;
using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public class AccessRequestService : IAccessRequestService
    {
        private readonly IAccessRequestRepository _accessRequestRepository;
        private readonly IDecisionRepository _decisionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDocumentRepository _documentRepository;

        public AccessRequestService(
            IAccessRequestRepository accessRequestRepository,
            IDecisionRepository decisionRepository,
            IUserRepository userRepository,
            IDocumentRepository documentRepository)
        {
            _accessRequestRepository = accessRequestRepository;
            _decisionRepository = decisionRepository;
            _userRepository = userRepository;
            _documentRepository = documentRepository;
        }

        public async Task<AccessRequest> CreateAccessRequestAsync(int userId, int documentId, string reason, AccessType accessType)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("User not found", nameof(userId));
            }

            var document = await _documentRepository.GetByIdAsync(documentId);

            if (document == null)
            {
                throw new ArgumentException("Document not found", nameof(documentId));
            }

            var request = new AccessRequest
            {
                UserId = userId,
                DocumentId = documentId,
                Reason = reason,
                RequestedAccessType = accessType,
                Status = AccessRequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            return await _accessRequestRepository.CreateAsync(request);
        }

        public async Task<List<AccessRequest>> GetAccessRequestsByUserAsync(int userId)
        {
            return await _accessRequestRepository.GetByUserAsync(userId);
        }

        public async Task<AccessRequest?> GetAccessRequestsByIdAsync(int id)
        {
            return await _accessRequestRepository.GetByIdAsync(id);
        }

        public async Task<List<AccessRequest>> GetPendingAccessRequestsAsync()
        {
            return await _accessRequestRepository.GetPendingAsync();
        }
    }
}
