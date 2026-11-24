using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;

namespace web_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> Get(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
                return NotFound();
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            var addedOrder = await _orderService.Add(order);
            return CreatedAtAction(nameof(Get), new { id = addedOrder.Id }, addedOrder);
        }
    }
}
 
   
 
