using DocumentAccessApprovalSystem.Application.Interfaces;
using DocumentAccessApprovalSystem.Domain;
using DocumentAccessApprovalSystem.Domain.Interfaces;

namespace DocumentAccessApprovalSystem.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        public async Task<Document?> GetDocumentByIdAsync(int id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        public async Task<Document> CreateDocumentAsync(string name, string? description, string? classification)
        {
            var document = new Document
            {
                Name = name,
                Description = description,
                Classification = classification
            };

            return await _documentRepository.CreateAsync(document);
        }

        public async Task<Document?> UpdateDocumentAsync(int id, string name, string? description, string? classification)
        {
            var document = await _documentRepository.GetByIdAsync(id);
            if (document == null)
                return null;

            document.Name = name;
            document.Description = description;
            document.Classification = classification;

            return await _documentRepository.UpdateAsync(document);
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            return await _documentRepository.DeleteAsync(id);
        }
    }
}
