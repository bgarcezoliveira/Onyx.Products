using Microsoft.EntityFrameworkCore;
using Onyx.Products.Infrastructure.Entities;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Infrastructure.DbContexts
{
    public class ProductsDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; } = null!;

		public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
			: base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Initialise DB with dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Name = "Smartphone",
                    Price = 599.99m,
                    Category = CategoryEnum.Electronics,
                    Description = "High-end smartphone with advanced features",
                    Colour = ColourEnum.Black
                },
                new Product
                {
                    Id = new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
                    Name = "T-shirt",
                    Price = 19.99m,
                    Category = CategoryEnum.Clothing,
                    Description = "Cotton T-shirt for casual wear",
                    Colour = ColourEnum.Blue
                },
                new Product
                {
                    Id = new Guid("aefe7a31-8dcc-4ff0-9b2d-5f148e2989c6"),
                    Name = "Coffee Maker",
                    Price = 49.99m,
                    Category = CategoryEnum.Home,
                    Description = "Programmable coffee maker for home use",
                    Colour = ColourEnum.White
                },
                new Product
                {
                    Id = new Guid("befe7a31-8dcc-4ff0-9b2d-5f148e2989c7"),
                    Name = "Lipstick",
                    Price = 9.99m,
                    Category = CategoryEnum.Beauty,
                    Description = "Matte lipstick in bold red shade",
                    Colour = ColourEnum.Red
                },
                new Product
                {
                    Id = new Guid("cefe7a31-8dcc-4ff0-9b2d-5f148e2989c8"),
                    Name = "Harry Potter and the Philosopher's Stone",
                    Price = 12.99m,
                    Category = CategoryEnum.Books,
                    Description = "First book in the Harry Potter series",
                    Colour = ColourEnum.Yellow
                },
                new Product
                {
                    Id = new Guid("defe7a31-8dcc-4ff0-9b2d-5f148e2989c9"),
                    Name = "LEGO Star Wars Millennium Falcon",
                    Price = 149.99m,
                    Category = CategoryEnum.Toys,
                    Description = "Buildable LEGO model of the Millennium Falcon",
                    Colour = ColourEnum.Grey
                },
                new Product
                {
                    Id = new Guid("eefe7a31-8dcc-4ff0-9b2d-5f148e2989ca"),
                    Name = "Football",
                    Price = 29.99m,
                    Category = CategoryEnum.Sports,
                    Description = "Official size and weight football",
                    Colour = ColourEnum.Black
                },
                new Product
                {
                    Id = new Guid("fefe7a31-8dcc-4ff0-9b2d-5f148e2989cb"),
                    Name = "Car Vacuum Cleaner",
                    Price = 39.99m,
                    Category = CategoryEnum.Automotive,
                    Description = "Portable vacuum cleaner for cars",
                    Colour = ColourEnum.Blue
                },
                new Product
                {
                    Id = new Guid("1ffe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
                    Name = "Multivitamin Tablets",
                    Price = 24.99m,
                    Category = CategoryEnum.Health,
                    Description = "Daily multivitamin tablets for adults",
                    Colour = ColourEnum.White
                },
                new Product
                {
                    Id = new Guid("2ffe7a31-8dcc-4ff0-9b2d-5f148e2989cd"),
                    Name = "Sofa",
                    Price = 499.99m,
                    Category = CategoryEnum.Furniture,
                    Description = "3-seater sofa with fabric upholstery",
                    Colour = ColourEnum.Blue
                },
                new Product
                {
                    Id = new Guid("3ffe7a31-8dcc-4ff0-9b2d-5f148e2989ce"),
                    Name = "Apples",
                    Price = 2.49m,
                    Category = CategoryEnum.Groceries,
                    Description = "Fresh, juicy apples",
                    Colour = ColourEnum.Red
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Notebook",
                    Price = 4.99m,
                    Category = CategoryEnum.Office,
                    Description = "A5 size ruled notebook",
                    Colour = ColourEnum.Black
                },
                new Product
                {
                    Id = new Guid("4ffe7a31-8dcc-4ff0-9b2d-5f148e2989cf"),
                    Name = "Dog Collar",
                    Price = 14.99m,
                    Category = CategoryEnum.Books,
                    Description = "Adjustable dog collar for medium-sized dogs",
                    Colour = ColourEnum.Blue
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

