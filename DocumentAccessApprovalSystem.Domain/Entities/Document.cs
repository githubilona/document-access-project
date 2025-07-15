namespace DocumentAccessApprovalSystem.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } //.
        public string? Classification { get; set; } // e.g. Internal, Confidential
    }
} 
