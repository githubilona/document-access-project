using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApprovalSystem.Infrastructure.Repositories
{
    public class DecisionRepository : IDecisionRepository
    {
        private readonly ApplicationDbContext _context;

        public DecisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Decision?> GetByIdAsync(int id)
        {
            return await _context.Decisions.FindAsync(id);
        }

        public async Task<List<Decision>> GetAllAsync()
        {
            return await _context.Decisions.ToListAsync();
        }

        public async Task<Decision?> GetByAccessRequestIdAsync(int accessRequestId)
        {
            return await _context.Decisions
                .FirstOrDefaultAsync(d => d.AccessRequestId == accessRequestId);
        }

        public async Task<Decision> CreateAsync(Decision decision)
        {
            _context.Decisions.Add(decision);
            await _context.SaveChangesAsync();
            return decision;
        }

        public async Task<Decision> UpdateAsync(Decision decision)
        {
            _context.Decisions.Update(decision);
            await _context.SaveChangesAsync();
            return decision;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var decision = await _context.Decisions.FindAsync(id);
            if (decision == null)
                return false;

            _context.Decisions.Remove(decision);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Decisions.AnyAsync(d => d.Id == id);
        }
    }
} 
