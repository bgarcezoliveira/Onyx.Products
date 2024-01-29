using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Onyx.Products.Infrastructure.DbContexts;
using Onyx.Products.Infrastructure.Entities;
using Onyx.Products.Infrastructure.Repositories;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Infrastructure.UnitTests;

public class ProductsRepositoryTests
{
    [Fact]
    public async Task GetAllAsync_Returns_AllProducts()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product 1", Colour = ColourEnum.Red },
                new Product { Id = Guid.NewGuid(), Name = "Product 2", Colour = ColourEnum.Blue }
            };

        var dbContextMock = new Mock<ProductsDbContext>();
        dbContextMock.Setup<DbSet<Product>>(x => x.Products)
        .ReturnsDbSet(products);

        var repository = new ProductsRepository(dbContextMock.Object);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByColourAsync_Returns_ProductsByColour()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product 1", Colour = ColourEnum.Red },
                new Product { Id = Guid.NewGuid(), Name = "Product 2", Colour = ColourEnum.Blue }
            }.AsQueryable();

        var dbContextMock = new Mock<ProductsDbContext>();
        var dbSetMock = new Mock<DbSet<Product>>();

        dbSetMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
        dbSetMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
        dbSetMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
        dbSetMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

        dbContextMock.Setup(db => db.Products).Returns(dbSetMock.Object);

        var repository = new ProductsRepository(dbContextMock.Object);
        var targetColour = ColourEnum.Red;

        // Act
        var result = await repository.GetByColourAsync(targetColour);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(ColourEnum.Red, result.First().Colour);
    }
}
