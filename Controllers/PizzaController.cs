using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models; // Namespace correto
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<Pizza>> Get() => _pizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = _pizzaService.Get(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public IActionResult Post(Pizza pizza)
        {
            _pizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Pizza pizza)
        {
            _pizzaService.Update(pizza);
            return NoContent();
        }
    }
}
