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
    public class AdjuntDocumentController : ControllerBase
    {
        private readonly IAdjuntDocumentService _adjuntDocumentService;

        public AdjuntDocumentController(IAdjuntDocumentService adjuntDocumentService)
        {
            _adjuntDocumentService = adjuntDocumentService;
        }

        //[HttpPost]
        //[Route("SaveAdjuntDocument")]
        //public async Task<IActionResult> SaveAdjuntDocument([FromBody] AdjuntDocument request)
        //{
        //    //return StatusCode(StatusCodes.Status200OK, "Hola");
        //    await _DBContext.AdjuntDocuments.AddAsync(request);
        //    await _DBContext.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status200OK, "OK");
        //}
        //[HttpPost]
        //[Route("SaveAdjuntDocument")]
        //public async Task<IActionResult> SaveAdjuntDocument([FromBody] AdjuntDocumentViewModel request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var adjuntDocument = new AdjuntDocument
        //    {
        //        Urls = request.Urls,
        //        NameDocument = request.NameDocument
        //    };

        //    _DBContext.AdjuntDocuments.Add(adjuntDocument);
        //    await _DBContext.SaveChangesAsync();

        //    return StatusCode(StatusCodes.Status200OK, "OK");
        //}

        //*******************************************************************************************

        [HttpPost]
        [Route("SaveAdjuntDocument")]
        public async Task<IActionResult> SaveAdjuntDocument([FromBody] AdjuntDocumentViewModel request)
        {
            var id = await _adjuntDocumentService.SaveAdjuntDocumentAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"AdjuntDocument created with ID: {id}");
        }

        [HttpGet]
        [Route("ViewAdjuntDocument")]
        public async Task<IActionResult> AdjuntDocument()
        {
            var adjuntDocuments = await _adjuntDocumentService.GetAdjuntDocumentsAsync();
            return StatusCode(StatusCodes.Status200OK, adjuntDocuments);
        }

        [HttpPut]
        [Route("UpdateAdjuntDocument/{id}")]
        public async Task<IActionResult> UpdateAdjuntDocument(int id, [FromBody] AdjuntDocumentViewModel request)
        {
            var result = await _adjuntDocumentService.UpdateAdjuntDocumentAsync(id, request);

            if (!result)
                return NotFound();

            return StatusCode(StatusCodes.Status200OK, "AdjuntDocument updated successfully");
        }

        [HttpDelete]
        [Route("DeleteAdjuntDocument/{id}")]
        public async Task<IActionResult> DeleteAdjuntDocument(int id)
        {
            var result = await _adjuntDocumentService.DeleteAdjuntDocumentAsync(id);

            if (!result)
                return NotFound();

            return StatusCode(StatusCodes.Status200OK, "AdjuntDocument deleted successfully");
        }



    }

}
