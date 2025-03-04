using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController(ICustomerService service, ILogger<CustomersController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetCustomers();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Customers");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetCustomerById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving Customer by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            try
            {
                var result = await service.CreateCustomer(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating Customer");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto dto)
        {
            try
            {
                var result = await service.UpdateCustomer(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating Customer");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteCustomer(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting Customer");
                return BadRequest(x);
            }
        }
    }
}
