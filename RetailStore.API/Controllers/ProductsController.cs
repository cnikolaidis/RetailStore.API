using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace RetailStore.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController(IProductService service, ILogger<ProductsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await service.GetProducts();
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving products");
                return BadRequest(x);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await service.GetProductById(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error retrieving product by id");
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            try
            {
                var result = await service.CreateProduct(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error creating product");
                return BadRequest(x);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            try
            {
                var result = await service.UpdateProduct(dto);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error updating product");
                return BadRequest(x);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                logger.LogError(x, $"{GetType().Name}: Error deleting product");
                return BadRequest(x);
            }
        }
    }
}
