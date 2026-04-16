//Product controller to handle get and return response

using Microsoft.AspNetCore.Mvc;
using Task_10.Models;
using Task_10.Services;
using Microsoft.AspNetCore.Authorization;

namespace Task_10.Controllers
{
    [ApiController]
    [Authorize]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        //GET Method to call GetProduct method in service and return response
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var response = await _service.GetProducts();

            if (response.Count == 0)
            {
                return NotFound();//if return response from service is empty
            }

            return Ok(response);
        }

        //GET Method to call GetProductById method in service and return response
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var response = await _service.GetProductById(id);

            if (response == null)
            {
                return NotFound();//if return response from service is empty
            }

            return Ok(response);
        }

        //POST Method to call AddProduct method in service and return response
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var response = await _service.AddProduct(product);

            if (response == null)
            {
                return BadRequest();//if return response from service is empty
            }

            return Ok(response);
        }

        //PUT Method to call UpdateProduct method in service and return response
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            var response = await _service.UpdateProduct(id, product);

            if (response == null)
            {
                return NotFound();//if return response from service is empty
            }

            return Ok(response);
        }

        //DELETE Method to call DeleteProduct method in service and return response
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var response = await _service.DeleteProduct(id);

            if (!response)
            {
                return NotFound(); //if return response from service is empty
            }

            return NoContent();
        }

    }
}