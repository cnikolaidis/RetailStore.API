using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("deliveryStatuses")]
    public class DeliveryStatusesController(IDeliveryStatusService service, ILogger<DeliveryStatusesController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetDeliveryStatuses();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving DeliveryStatuses");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetDeliveryStatusById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving DeliveryStatus by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryStatusDto dto)
        {
            try
            {
                var result = await service.CreateDeliveryStatus(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating DeliveryStatus");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DeliveryStatusDto dto)
        {
            try
            {
                var result = await service.UpdateDeliveryStatus(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating DeliveryStatus");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteDeliveryStatus(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting DeliveryStatus");
                return BadRequest(x);
            }
        }
    }
}
