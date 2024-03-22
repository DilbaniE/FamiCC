using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposedController : ControllerBase
    {
        private readonly IProposedService _proposedService;

        public ProposedController(IProposedService proposedService)
        {
            _proposedService = proposedService;
        }

        [HttpPost]
        [Route("SaveProposed")]
        public async Task<IActionResult> SaveProposed([FromBody] ProposedViewModel request)
        {
            var id = await _proposedService.SaveProposedAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"Proposed created with ID: {id}");
        }
    }
}
