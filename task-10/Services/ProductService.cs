//product Service to handle crud operations
using Microsoft.EntityFrameworkCore;
using Task_10.Models;
using Task_10.Data;

namespace Task_10.Services
{
    public class ProductService
    {

        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        //Method to get all products
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }

        //method to get products with the id alone
        public async Task<Product?> GetProductById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //method to add products
        public async Task<Product?> AddProduct(Product product)
        {
            try
            {
                var existing_product = await _context.Products.FindAsync(product.Id);
                if (existing_product == null)
                {
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    return product;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //method to update products
        public async Task<Product?> UpdateProduct(int id, Product product)
        {

            try
            {
                var existing_product = await _context.Products.FindAsync(id);

                if (existing_product != null)
                {
                    existing_product.Title = product.Title;
                    existing_product.Price = product.Price;
                    await _context.SaveChangesAsync();
                }
                return existing_product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

//method to delete product
        public async Task<bool> DeleteProduct(int id)
        {

            try
            {
                var existing_product = await _context.Products.FindAsync(id);

                if (existing_product != null)
                {
                    _context.Products.Remove(existing_product);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}