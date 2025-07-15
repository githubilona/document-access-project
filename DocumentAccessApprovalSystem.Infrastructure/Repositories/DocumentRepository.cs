using DocumentAccessApprovalSystem.Domain;
using DocumentAccessApprovalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApprovalSystem.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Document?> GetByIdAsync(int id)
        {
            return await _context.Documents.FindAsync(id);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> CreateAsync(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateAsync(Document document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return false;

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Documents.AnyAsync(d => d.Id == id);
        }
    }
} 