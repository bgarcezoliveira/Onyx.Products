using System.ComponentModel.DataAnnotations;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Infrastructure.Entities
{
    public class Product
	{
        [Key]
        [MaxLength]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public ColourEnum Colour { get; set; }
    }
}

