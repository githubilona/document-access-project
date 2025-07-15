using DocumentAccessApprovalSystem.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DocumentAccessApprovalSystem.Application.Services;

namespace DocumentAccessApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecisionController : ControllerBase
    {
        private readonly IDecisionService _decisionService;

        public DecisionController(IDecisionService decisionService)
        {
            _decisionService = decisionService;
        }

        [Authorize(Roles = "Approver")]
        [HttpPost("{id}/decision")]
        public async Task<IActionResult> Decide(int id, [FromBody] DecisionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != dto.RequestId)
                return BadRequest("RequestId in URL and body do not match");

            var decision = await _decisionService.DecideAsync(dto.RequestId, dto.ApproverId, dto.IsApproved, dto.Comment);
            return Ok(decision);
        }
    }
} 
