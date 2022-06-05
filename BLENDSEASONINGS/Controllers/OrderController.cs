using BLENDSEASONINGS.Models;
using BLENDSEASONINGS.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            List<Order> orders = _orderRepo.GetAllOrders();
            if(orders == null) return NotFound();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var match = _orderRepo.GetOrderById(id);

            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        [HttpPost]
        public IActionResult CreateNewOrder(Order newOrder)
        {
            if (newOrder == null)
            {
                return NotFound();
            }
            else
            {
                _orderRepo.CreateOrder(newOrder);
                return Ok(newOrder);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Order order)
        {
            int id = order.Id;
            var match = _orderRepo.GetOrderById(id);

            if (match == null)
            {
                return NotFound();
            }
            else
            {
                _orderRepo.UpdateOrder(order);
                return Ok(order);
            }
        }
    }
}
