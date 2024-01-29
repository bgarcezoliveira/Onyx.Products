using Onyx.Products.Infrastructure.Entities;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Infrastructure.Repositories
{
    public interface IProductsRepository
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<IEnumerable<Product>> GetByColourAsync(ColourEnum colour);
	}
}

