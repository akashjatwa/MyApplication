using Microsoft.AspNetCore.Mvc;
using CampBookingApi.Models;
using CampBookingApi.Services;

namespace CampBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer is null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            var created = _customerService.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Customer updatedCustomer)
        {
            var customer = _customerService.Update(id, updatedCustomer);
            if (customer is null) return NotFound();
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!_customerService.Delete(id))
                return NotFound();
            return NoContent();
        }
    }
}
