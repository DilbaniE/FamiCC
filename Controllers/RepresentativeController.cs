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
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] RepresentativeViewModel representativeViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model state");

            var representativeId = await _representativeService.SaveRepresentativeAsync(representativeViewModel);
            return Ok(representativeId);
        }


        [Route("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var representatives = await _representativeService.GetAllRepresentativesAsync();
            return Ok(representatives);
        }

        // Update


        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RepresentativeViewModel representativeViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model state");

            var result = await _representativeService.UpdateRepresentativeAsync(id, representativeViewModel);
            if (!result)
                return NotFound("Representative not found");

            return Ok("Representative updated successfully");
        }

        //delete

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _representativeService.DeleteRepresentativeAsync(id);
            if (!result)
                return NotFound("Representative not found");

            return Ok("Representative deleted successfully");
        }




    }
}
