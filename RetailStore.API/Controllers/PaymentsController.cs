using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController(IPaymentService service, ILogger<PaymentsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetPayments();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Payments");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetPaymentById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Payment by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentDto dto)
        {
            try
            {
                var result = await service.CreatePayment(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating Payment");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentDto dto)
        {
            try
            {
                var result = await service.UpdatePayment(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating Payment");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeletePayment(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting Payment");
                return BadRequest(x);
            }
        }
    }
}
