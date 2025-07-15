namespace DocumentAccessApprovalSystem.Domain.Entities
{
    public class Decision
    {
        public int Id { get; set; }
        public int AccessRequestId { get; set; }
        public int ApproverId { get; set; }
        public bool IsApproved { get; set; }
        public string? Comment { get; set; }
        public DateTime DecidedAt { get; set; }
    }
}
