using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProponentTypeController : ControllerBase
    {
        private readonly IProponentTypeService _proponentTypeService;

        public ProponentTypeController(IProponentTypeService proponentTypeService)
        {
            _proponentTypeService = proponentTypeService;
        }
        // METODO SAVE
        [HttpPost]
        [Route("SaveProponentType")]
        public async Task<IActionResult> SaveProponentType([FromBody] ProponentTypeViewModel request)
        {
            var id = await _proponentTypeService.SaveProponentTypeAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"ProponentType created with ID: {id}");
        }
        // METODO VIEWV

        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var proponentTypes = await _proponentTypeService.GetAllProponentTypesAsync();
            return Ok(proponentTypes);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProponentTypeViewModel proponentTypeViewModel)
        {
            var result = await _proponentTypeService.UpdateProponentTypeAsync(id, proponentTypeViewModel);

            if (result)
                return Ok("ProponentType updated successfully.");

            return NotFound("ProponentType not found.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _proponentTypeService.DeleteProponentTypeAsync(id);

            if (result)
                return Ok("ProponentType deleted successfully.");

            return NotFound("ProponentType not found.");
        }

    }
}


