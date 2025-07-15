namespace DocumentAccessApprovalSystem.API.DTOs
{
    public class DecisionDto
    {
        public int RequestId { get; set; }
        public int ApproverId { get; set; }
        public bool IsApproved { get; set; }
        public string? Comment { get; set; }
    }
} 
