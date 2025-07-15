using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApprovalSystem.Infrastructure.Repositories
{
    public class AccessRequestRepository : IAccessRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public AccessRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccessRequest?> GetByIdAsync(int id)
        {
            return await _context.AccessRequests
                .Include(r => r.Decision)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<AccessRequest>> GetAllAsync()
        {
            return await _context.AccessRequests
                .Include(r => r.Decision)
                .ToListAsync();
        }

        public async Task<List<AccessRequest>> GetByUserAsync(int userId)
        {
            return await _context.AccessRequests
                .Include(r => r.Decision)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<AccessRequest>> GetPendingAsync()
        {
            return await _context.AccessRequests
                .Include(r => r.Decision)
                .Where(r => r.Status == AccessRequestStatus.Pending)
                .ToListAsync();
        }

        public async Task<AccessRequest> CreateAsync(AccessRequest accessRequest)
        {
            _context.AccessRequests.Add(accessRequest);
            await _context.SaveChangesAsync();
            return accessRequest;
        }

        public async Task<AccessRequest> UpdateAsync(AccessRequest accessRequest)
        {
            _context.AccessRequests.Update(accessRequest);
            await _context.SaveChangesAsync();
            return accessRequest;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var accessRequest = await _context.AccessRequests.FindAsync(id);
            if (accessRequest == null)
                return false;

            _context.AccessRequests.Remove(accessRequest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AccessRequests.AnyAsync(r => r.Id == id);
        }
    }
} 
