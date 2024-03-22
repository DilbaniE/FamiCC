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

        //METODO POSTSAVE
        [HttpPost]
        [Route("SaveProposedValue")]
        public async Task<IActionResult> SaveProposedValue([FromBody] ProposedValueViewModel request)
        {
            var id = await _proposedValueService.SaveProposedValueAsync(request);
            return StatusCode(StatusCodes.Status200OK, $"ProposedValue created with ID: {id}");
        }

        //METODO GETALL
        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var proposedValues = await _proposedValueService.GetAllProposedValuesAsync();
            return Ok(proposedValues);
        }

        //METODO UPDATE
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProposedValueViewModel proposedValueViewModel)
        {
            var result = await _proposedValueService.UpdateProposedValueAsync(id, proposedValueViewModel);

            if (result)
                return Ok("ProposedValue updated successfully.");

            return NotFound("ProposedValue not found.");
        }

        //METOD DDELETE
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _proposedValueService.DeleteProposedValueAsync(id);

            if (result)
                return Ok("ProposedValue deleted successfully.");

            return NotFound("ProposedValue not found.");
        }
    }
}
