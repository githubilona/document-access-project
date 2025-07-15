using DocumentAccessApprovalSystem.Domain;

namespace DocumentAccessApprovalSystem.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Document?> GetByIdAsync(int id);
        Task<List<Document>> GetAllAsync();
        Task<Document> CreateAsync(Document document);
        Task<Document> UpdateAsync(Document document);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 