using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onyx.Products.Infrastructure.DbContexts;
using Onyx.Products.Infrastructure.Repositories;

namespace Onyx.Products.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string? productsDBConnectionString)
    {
        serviceCollection.AddDbContext<ProductsDbContext>(options => options.UseSqlite(productsDBConnectionString));
        serviceCollection.AddScoped<IProductsRepository, ProductsRepository>();
        return serviceCollection;
    }
}

