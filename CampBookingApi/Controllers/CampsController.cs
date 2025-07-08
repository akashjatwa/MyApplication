using Microsoft.AspNetCore.Mvc;
using CampBookingApi.Models;
using CampBookingApi.Services;

namespace CampBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampService _campService;

        public CampsController(ICampService campService)
        {
            _campService = campService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Camp>> GetAll()
        {
            return Ok(_campService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Camp> GetById(int id)
        {
            var camp = _campService.GetById(id);
            if (camp is null) return NotFound();
            return Ok(camp);
        }

        [HttpPost]
        public ActionResult<Camp> Create(Camp camp)
        {
            var created = _campService.Create(camp);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Camp updatedCamp)
        {
            var camp = _campService.Update(id, updatedCamp);
            if (camp is null) return NotFound();
            return Ok(camp);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!_campService.Delete(id))
                return NotFound();
            return NoContent();
        }
    }
}
