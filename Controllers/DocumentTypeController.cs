using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpPost]
        [Route("SaveDocumentType")]
        public async Task<IActionResult> SaveDocumentType([FromBody] DocumentType request)
        {
            var id = await _documentTypeService.SaveDocumentTypeAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"DocumentType created with ID: {id}");
        }

        [HttpGet]
        [Route("ViewDocumentType")]
        public async Task<IActionResult> DocumentType()
        {
            var documentTypes = await _documentTypeService.GetDocumentTypesAsync();
            return StatusCode(StatusCodes.Status200OK, documentTypes);
        }
    }
}
