using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentAccessApprovalSystem.Domain;
using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocumentsAsync();
        Task<Document?> GetDocumentByIdAsync(int id);
    }
} 
