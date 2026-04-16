//Product structure for CRUD Operations
namespace Task_10.Models
{
    public class Product
    {
        public int Id { get; set; } //unique value

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Brand { get; set; }

        public string? Category { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public double Rating { get; set; }

        public int Stock { get; set; }

        public string? AvailabilityStatus { get; set; }

        public List<string>? Tags { get; set; }

    }
}