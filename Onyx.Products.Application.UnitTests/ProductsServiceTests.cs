using AutoMapper;
using Moq;
using Onyx.Products.Application.Services;
using Onyx.Products.Infrastructure.Repositories;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Application.UnitTests;

public class ProductsServiceTests
{
    [Fact]
    public async Task GetAllProducts_Returns_MappedProducts()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var productsRepositoryMock = new Mock<IProductsRepository>();

        var productsService = new ProductsService(mapperMock.Object, productsRepositoryMock.Object);

        var sourceProducts = new List<Infrastructure.Entities.Product>
            {
                new Infrastructure.Entities.Product { Id = Guid.NewGuid(), Name = "Product 1" },
                new Infrastructure.Entities.Product { Id = Guid.NewGuid(), Name = "Product 2" }
            };

        mapperMock.Setup(m => m.Map<IEnumerable<Domain.Models.Product>>(sourceProducts)).Returns(
            new List<Domain.Models.Product>
            {
                    new Domain.Models.Product { Id = Guid.NewGuid(), Name = "Product 1" },
                    new Domain.Models.Product { Id = Guid.NewGuid(), Name = "Product 2" }
            });

        productsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sourceProducts);

        // Act
        var result = await productsService.GetAllProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetProductsByColour_Returns_MappedProducts()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var productsRepositoryMock = new Mock<IProductsRepository>();

        var productsService = new ProductsService(mapperMock.Object, productsRepositoryMock.Object);
        var colour = ColourEnum.Red;

        var sourceProducts = new List<Infrastructure.Entities.Product>
            {
                new Infrastructure.Entities.Product { Id = Guid.NewGuid(), Name = "Red Product", Colour = ColourEnum.Red },
                new Infrastructure.Entities.Product { Id = Guid.NewGuid(), Name = "Blue Product", Colour = ColourEnum.Blue },
                new Infrastructure.Entities.Product { Id = Guid.NewGuid(), Name = "Red Product", Colour = ColourEnum.Red }
            };

        var redProducts = sourceProducts.Where(p => p.Colour == colour).ToList();

        mapperMock.Setup(m => m.Map<IEnumerable<Domain.Models.Product>>(redProducts)).Returns(
            redProducts.Select(p => new Domain.Models.Product { Id = p.Id, Name = p.Name }));

        productsRepositoryMock.Setup(repo => repo.GetByColourAsync(colour)).ReturnsAsync(redProducts);

        // Act
        var result = await productsService.GetProductsByColour(colour);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.All(result, p => Assert.Equal(ColourEnum.Red, p.Colour));
    }
}
