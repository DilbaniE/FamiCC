using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : ControllerBase
    {
        private readonly IRepresentativeService _representativeService;

        public RepresentativeController(IRepresentativeService representativeService)
        {
            _representativeService = representativeService;
        }

        [HttpPost]
        [Route("SaveRepresentative")]
        public async Task<IActionResult> SaveRepresentative([FromBody] RepresentativeViewModel request)
        {
            var id = await _representativeService.SaveRepresentativeAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"Representative created with ID: {id}");
        }
    }
}
