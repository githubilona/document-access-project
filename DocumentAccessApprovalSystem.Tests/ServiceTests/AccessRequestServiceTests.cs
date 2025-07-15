using System;
using System.Threading.Tasks;
using DocumentAccessApprovalSystem.Application;
using DocumentAccessApprovalSystem.Application.Services;
using DocumentAccessApprovalSystem.Domain;
using DocumentAccessApprovalSystem.Domain.Entities;
using DocumentAccessApprovalSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace DocumentAccessApprovalSystem.Tests.ServiceTests
{
    public class AccessRequestServiceTests
    {
        [Fact]
        public async Task CreateAccessRequestAsync_ShouldCreatePendingRequest()
        {
            // Arrange
            var mockAccessRequestRepo = new Mock<IAccessRequestRepository>();
            var mockDecisionRepo = new Mock<IDecisionRepository>();
            var mockUserRepo = new Mock<IUserRepository>();
            var mockDocumentRepo = new Mock<IDocumentRepository>();

            var user = new User { Id = 1, Name = "Test User", Email = "mail@mail.com", Role = UserRole.User, CreatedAt = DateTime.UtcNow };
            var document = new Document { Id = 1, Name = "Spec" };

            mockUserRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);
            mockDocumentRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(document);
            mockAccessRequestRepo.Setup(r => r.CreateAsync(It.IsAny<AccessRequest>()))
                .ReturnsAsync((AccessRequest req) => req);

            var service = new AccessRequestService(
                mockAccessRequestRepo.Object,
                mockDecisionRepo.Object,
                mockUserRepo.Object,
                mockDocumentRepo.Object
            );

            // Act
            var result = await service.CreateAccessRequestAsync(1, 1, "access reason", AccessType.Read);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.UserId);
            Assert.Equal(1, result.DocumentId);
            Assert.Equal("access reason", result.Reason);
            Assert.Equal(AccessType.Read, result.RequestedAccessType);
            Assert.Equal(AccessRequestStatus.Pending, result.Status);
        }
    }
}
