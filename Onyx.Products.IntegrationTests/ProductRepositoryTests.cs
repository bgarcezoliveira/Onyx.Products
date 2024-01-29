using FluentAssertions;
using Onyx.Products.Infrastructure.Repositories;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.IntegrationTests;

public class ProductRepositoryTests : IClassFixture<SharedDatabaseFixture>
{
    private SharedDatabaseFixture Fixture { get; }

    public ProductRepositoryTests(SharedDatabaseFixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllProducts()
    {
        using (var context = Fixture.CreateContext())
        {
            var repository = new ProductsRepository(context);
            var products = await repository.GetAllAsync();

            Assert.Equal(23, products.Count());
        }
    }

    [Theory]
    [InlineData(ColourEnum.Black)]
    [InlineData(ColourEnum.Green)]
    [InlineData(ColourEnum.Red)]
    [InlineData(ColourEnum.Grey)]
    [InlineData(ColourEnum.Blue)]
    [InlineData(ColourEnum.Yellow)]
    public async Task GetByColourAsync_ReturnsProducts(ColourEnum colour)
    {
        using (var context = Fixture.CreateContext())
        {
            var exp = context.Products.Count(p => p.Colour == colour);

            var repository = new ProductsRepository(context);
            var products = await repository.GetByColourAsync(colour);

            products.Should().NotBeNull();
            products.Should().HaveCount(exp);
        }
    }
}
