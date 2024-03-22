using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace famiCCV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposedValueController : ControllerBase
    {
        private readonly IProposedValueService _proposedValueService;

        public ProposedValueController(IProposedValueService proposedValueService)
        {
            _proposedValueService = proposedValueService;
        }

        [HttpPost]
        [Route("SaveProposedValue")]
        public async Task<IActionResult> SaveProposedValue([FromBody] ProposedValueViewModel request)
        {
            var id = await _proposedValueService.SaveProposedValueAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"ProposedValue created with ID: {id}");
        }
    }
}
