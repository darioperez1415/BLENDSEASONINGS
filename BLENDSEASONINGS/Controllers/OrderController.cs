﻿using BLENDSEASONINGS.Models;
using BLENDSEASONINGS.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLENDSEASONINGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            List<Order> orders = _orderRepo.GetAllOrders();
            if (orders == null) return NotFound();
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



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderRepo.DeleteOrder(id);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetOrderByUserId(string userId)
        {
            var matches = _orderRepo.GetOrdersByUserId(userId);
            if (matches == null)
            {
                return NotFound();
            }
            return Ok(matches);
        }



        [HttpGet("blendOrder/{orderId}")]
        public IActionResult GetBlendOrderByOrderId(int orderId)
        {
            var matches = _orderRepo.GetBlendOrderByOrderId(orderId);
            if (matches == null)
            {
                return NotFound();
            }
            return Ok(matches);
        }


        [HttpPost("blendOrder")]
        public IActionResult CreateNewBlendOrder(BlendOrder newBlendOrder)
        {
            if (newBlendOrder == null)
            {
                return NotFound();
            }
            else
            {
                _orderRepo.CreateBlendOrder(newBlendOrder);
                return Ok(newBlendOrder);
            }
        }


        [HttpPatch("blendOrder/{id}")]
        public IActionResult UpdateBlendOrder(BlendOrder blendOrder)
        {
            int id = blendOrder.Id;
            var match = _orderRepo.GetBlendOrderByOrderId(id);

            if (match == null)
            {
                return NotFound();
            }
            else
            {
                _orderRepo.UpdateBlendOrder(blendOrder);
                return Ok(blendOrder);
            }

        }
        [HttpDelete("blendOrder/{id}")]
        public void DeleteBlendOrder(int id)
        {
            _orderRepo.DeleteBlendOrder(id);
        }

    }
}
