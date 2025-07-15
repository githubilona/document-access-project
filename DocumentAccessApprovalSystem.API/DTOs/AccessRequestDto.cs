using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.API.DTOs
{
    public class AccessRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int DocumentId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public AccessType RequestedAccessType { get; set; }
        public AccessRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DecisionDto? Decision { get; set; }
    }
} 
