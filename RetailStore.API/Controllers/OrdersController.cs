using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController(IOrderService service, ILogger<OrdersController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetOrders();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Orders");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetOrderById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Order by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            try
            {
                var result = await service.CreateOrder(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating Order");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderDto dto)
        {
            try
            {
                var result = await service.UpdateOrder(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating Order");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteOrder(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting Order");
                return BadRequest(x);
            }
        }
    }
}
