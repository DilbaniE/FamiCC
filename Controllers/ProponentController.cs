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
    }
}
