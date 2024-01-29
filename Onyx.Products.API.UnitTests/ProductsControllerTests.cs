using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Onyx.Products.Application.Services;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.API.UnitTests;

public class ProductsControllerTests
{
    [Fact]
    public async Task Get_Returns_OkResult()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mapperMock = new Mock<IMapper>();
        var productsServiceMock = new Mock<IProductsService>();

        var controller = new ProductsController(loggerMock.Object, mapperMock.Object, productsServiceMock.Object);

        // Act
        var result = await controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetByColour_Returns_OkResult()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mapperMock = new Mock<IMapper>();
        var productsServiceMock = new Mock<IProductsService>();

        var controller = new ProductsController(loggerMock.Object, mapperMock.Object, productsServiceMock.Object);
        var colour = ColourEnum.Red; // or any desired colour

        // Act
        var result = await controller.Get(colour);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Get_WithException_Returns_StatusCode500()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mapperMock = new Mock<IMapper>();
        var productsServiceMock = new Mock<IProductsService>();

        productsServiceMock.Setup(x => x.GetAllProducts()).ThrowsAsync(new Exception("Simulated Exception"));

        var controller = new ProductsController(loggerMock.Object, mapperMock.Object, productsServiceMock.Object);

        // Act
        var result = await controller.Get();

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task GetByColour_WithException_Returns_StatusCode500()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mapperMock = new Mock<IMapper>();
        var productsServiceMock = new Mock<IProductsService>();

        // Set up mock behavior to throw an exception when GetProductsByColour is called
        productsServiceMock.Setup(x => x.GetProductsByColour(It.IsAny<ColourEnum>())).ThrowsAsync(new Exception("Simulated Exception"));

        var controller = new ProductsController(loggerMock.Object, mapperMock.Object, productsServiceMock.Object);
        var colour = ColourEnum.Red;

        // Act
        var result = await controller.Get(colour);

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}
