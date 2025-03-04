using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("deliveryDetails")]
    public class DeliveryDetailsController(IDeliveryDetailService service, ILogger<DeliveryDetailsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetDeliveryDetails();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving DeliveryDetails");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetDeliveryDetailById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving DeliveryDetail by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryDetailDto dto)
        {
            try
            {
                var result = await service.CreateDeliveryDetail(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating DeliveryDetail");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DeliveryDetailDto dto)
        {
            try
            {
                var result = await service.UpdateDeliveryDetail(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating DeliveryDetail");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteDeliveryDetail(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting DeliveryDetail");
                return BadRequest(x);
            }
        }
    }
}
