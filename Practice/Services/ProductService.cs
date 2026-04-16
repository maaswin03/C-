using Practice.Models;
using Practice.Data;

namespace Practice.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductsById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                _context.SaveChanges();
            }

            return existingProduct;
        }

        public Product DeleteProduct(int id)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                _context.SaveChanges();
            }

            return existingProduct;
        }
    }
}