using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models; // Namespace correto
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get() => _orderService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
            
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            _orderService.Add(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Order order)
        {
            _orderService.Update(order);
            return NoContent();
        }
    }
}

