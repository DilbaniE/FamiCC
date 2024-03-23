using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProponentController : ControllerBase
    {
        private readonly IProponentService _proponentService;

        public ProponentController(IProponentService proponentService)
        {
            _proponentService = proponentService;
        }

        [HttpPost]
        [Route("SaveProponent")]
        public async Task<IActionResult> SaveProponent([FromBody] ProponentViewModel request)
        {
            var id = await _proponentService.SaveProponentAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"Proponent created with ID: {id}");
        }

        //vireAll

        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var proponents = await _proponentService.GetAllProponentsAsync();
            return Ok(proponents);
        }

        //update

        [HttpPut]
        [Route("UpdateProponent/{id}")]
        public async Task<IActionResult> UpdateProponent(int id, [FromBody] ProponentViewModel request)
        {
            var result = await _proponentService.UpdateProponentAsync(id, request);
            if (!result)
                return NotFound($"Proponent with ID {id} not found");

            return Ok($"Proponent with ID {id} updated successfully");
        }





    }
}
