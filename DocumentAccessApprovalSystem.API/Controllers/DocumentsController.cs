using DocumentAccessApprovalSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/documents
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }
    }
} 
