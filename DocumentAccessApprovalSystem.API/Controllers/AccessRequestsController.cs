using DocumentAccessApprovalSystem.API.DTOs;
using DocumentAccessApprovalSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DocumentAccessApprovalSystem.Application.Services;

namespace DocumentAccessApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessRequestsController : ControllerBase
    {
        private readonly IAccessRequestService _accessRequestService;

        public AccessRequestsController(IAccessRequestService accessRequestService)
        {
            _accessRequestService = accessRequestService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccessRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _accessRequestService.CreateAccessRequestAsync(dto.UserId, dto.DocumentId, dto.Reason, dto.RequestedAccessType);
            return CreatedAtAction(nameof(GetByUser), new { userId = request.UserId }, request);
        }

        // GET: api/AccessRequests/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _accessRequestService.GetByIdAsync(id);
            if (request == null)
                return NotFound();
            return Ok(request);
        }

        [Authorize(Roles = "User")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var requests = await _accessRequestService.GetRequestsByUserAsync(userId);
            return Ok(requests);
        }

        [Authorize(Roles = "Approver")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var requests = await _accessRequestService.GetPendingRequestsAsync();
            return Ok(requests);
        }
    }
}
