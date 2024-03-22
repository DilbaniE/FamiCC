using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
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


        //Metod POST 
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] DocumentTypeViewModel documentTypeViewModel)
        {
            var id = await _documentTypeService.SaveDocumentTypeAsync(documentTypeViewModel);
            return Ok(id);
        }


        // Metod GETALL
        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var documentTypes = await _documentTypeService.GetAllDocumentTypesAsync();
            return Ok(documentTypes);
        }

        //METOD GETID
        [HttpGet]
        [Route("View/{id}")]
        public async Task<IActionResult> View(int id)
        {
            var documentType = await _documentTypeService.GetDocumentTypeByIdAsync(id);

            if (documentType == null)
                return NotFound("DocumentType not found");

            return Ok(documentType);
        }


        //METOD PUT
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] DocumentTypeViewModel documentTypeViewModel)
        {
            var isUpdated = await _documentTypeService.UpdateDocumentTypeAsync(documentTypeViewModel);

            if (isUpdated)
                return Ok("DocumentType updated successfully");
            else
                return NotFound("DocumentType not found or update failed");
        }

        //DELETE METOD 
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _documentTypeService.DeleteDocumentTypeAsync(id);

            if (isDeleted)
                return Ok("DocumentType deleted successfully");
            else
                return NotFound("DocumentType not found or delete failed");
        }
    }
}
