using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.DTOs;
using PizzaStore.Services.IServices;

namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pizza = await _service.GetPizzaByIdAsync(id);
            if (pizza is null) return NotFound();
            return Ok(pizza);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizzas = await _service.GetAllPizzasAsync();
            return Ok(pizzas);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PizzaDto dto)
        {
            await _service.AddPizzaAsync(dto);
            return Ok("Pizza has been added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PizzaDto dto)
        {
            await _service.UpdatePizzaAsync(dto);
            return Ok("Pizza has been updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeletePizzaAsync(id);
            return Ok("Pizza has been deleted successfully");
        }
    }
}
