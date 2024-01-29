using Onyx.Products.Domain.Models;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Application.Services
{
    public interface IProductsService
	{
		Task<IEnumerable<Product>> GetAllProducts();
		Task<IEnumerable<Product>> GetProductsByColour(ColourEnum colour);
	}
}

