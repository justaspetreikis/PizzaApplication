using Microsoft.AspNetCore.Mvc;
using PizzaOrderApp.Data.Dtos;
using PizzaOrderApp.Interfaces;

namespace PizzaOrderApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaOrderController : Controller
    {
        private readonly IPizzaOrderService _pizzaOrderService;

        public PizzaOrderController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPizzaOrderAsync([FromBody] PizzaOrderRequest order)
        {
            try
            {
                return Ok(await _pizzaOrderService.SavePizzaOrderAsync(order));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating pizza order: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPizzaOrdersAsync()
        {
            var orders = await _pizzaOrderService.GetAllPizzaOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("toppings")]
        public async Task<IActionResult> GetPizzaToppingsAsync()
        {
            var toppings = await _pizzaOrderService.GetAllToppingsAsync();
            return Ok(toppings);
        }

        [HttpGet("sizes")]
        public async Task<IActionResult> GetPizzaSizesAsync()
        {
            var sizes = await _pizzaOrderService.GetAllPizzaSizesAsync();
            return Ok(sizes);
        }
    }
}
