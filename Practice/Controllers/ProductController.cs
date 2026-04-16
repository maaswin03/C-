using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using Practice.Services;

namespace Practice.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            try
            {
                
            }catch

            return _service.GetProducts();
        }

        [HttpGet("{id}")]
        public Product GetProductsById(int id)
        {
            return _service.GetProductsById(id);
        }

        [HttpPut("{id}")]
        public Product UpdateProduct(int id, Product product)
        {
            return _service.UpdateProduct(id, product);
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            return _service.AddProduct(product);
        }

        [HttpDelete("{id}")]
        public Product DeleteProduct(int id)
        {
            return _service.DeleteProduct(id);
        }
    }
}