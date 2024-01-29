using Microsoft.Extensions.DependencyInjection;
using Onyx.Products.Application.Services;
using Onyx.Products.Infrastructure;

namespace Onyx.Products.Application
{
    public static class DependencyInjection
	{
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, string? dbConnectionString)
        {
            serviceCollection.AddScoped<IProductsService, ProductsService>();
            serviceCollection.AddInfrastructure(dbConnectionString);
            return serviceCollection;
        }
    }
}

