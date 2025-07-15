namespace DocumentAccessApprovalSystem.Domain.Entities
{
    public class AccessRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public AccessType RequestedAccessType { get; set; }
        public AccessRequestStatus Status { get; set; }
        public Decision? Decision { get; set; } // for Approver 
        public DateTime CreatedAt { get; set; }
    }

    public enum AccessType
    {
        Read,
        Edit
    }

    public enum AccessRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
