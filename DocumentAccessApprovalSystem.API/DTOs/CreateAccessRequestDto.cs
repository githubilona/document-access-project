using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.API.DTOs
{
    public class CreateAccessRequestDto
    {
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public AccessType RequestedAccessType { get; set; }
    }
} 
