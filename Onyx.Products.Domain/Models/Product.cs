using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public ColourEnum Colour { get; set; }
    }
}

