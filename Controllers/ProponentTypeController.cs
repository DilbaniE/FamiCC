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

        [HttpPost]
        [Route("SaveProponentType")]
        public async Task<IActionResult> SaveProponentType([FromBody] ProponentTypeViewModel request)
        {
            var id = await _proponentTypeService.SaveProponentTypeAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"ProponentType created with ID: {id}");
        }
    }
}
