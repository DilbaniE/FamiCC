using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProponentDocumentController : ControllerBase
    {
        private readonly IProponentDocumentService _proponentDocumentService;

        public ProponentDocumentController(IProponentDocumentService proponentDocumentService)
        {
            _proponentDocumentService = proponentDocumentService;
        }
        //request POST
        [HttpPost]
        [Route("SaveProponentDocument")]
        public async Task<IActionResult> SaveProponentDocument([FromBody] ProponentDocumentViewModel request)
        {
            var id = await _proponentDocumentService.SaveProponentDocumentAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"ProponentDocument created with ID: {id}");
        }

        //Request GET
        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var proponentDocuments = await _proponentDocumentService.GetAllProponentDocumentsAsync();
            return Ok(proponentDocuments);
        }


    }
}
