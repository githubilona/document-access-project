using Microsoft.EntityFrameworkCore;
using DocumentAccessApprovalSystem.Domain;
using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }
        public DbSet<Decision> Decisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "user", Email = "user@user.com", Role = UserRole.User, CreatedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) },
                new User { Id = 2, Name = "approver", Email = "approver@approver.com", Role = UserRole.Approver, CreatedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, Name = "Project_documentation.docx", Description = "BankApp project documentatation", Classification = "Internal" },
                new Document { Id = 2, Name = "Quarterly_Report.xlsx", Description = "Q4 financial report", Classification = "Confidential" },
                new Document { Id = 3, Name = "", Description = "Human resources policies and procedures", Classification = "Internal" }
            );

            modelBuilder.Entity<AccessRequest>().HasData(
                new AccessRequest { Id = 1, UserId = 1, DocumentId = 1, Reason = "review finanical report ", RequestedAccessType = AccessType.Read, Status = AccessRequestStatus.Pending, CreatedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) },
                new AccessRequest { Id = 2, UserId = 1, DocumentId = 2, Reason = "edit financial report", RequestedAccessType = AccessType.Edit, Status = AccessRequestStatus.Pending, CreatedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Decision>().HasData(
                new Decision { Id = 1, AccessRequestId = 1, ApproverId = 2, IsApproved = true, Comment = "Approved", DecidedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) },
                new Decision { Id = 2, AccessRequestId = 2, ApproverId = 2, IsApproved = false, Comment = "Rejected -  user not allowed", DecidedAt = new DateTime(2025, 7, 13, 12, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
} 
