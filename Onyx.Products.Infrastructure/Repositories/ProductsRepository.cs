using Microsoft.EntityFrameworkCore;
using Onyx.Products.Infrastructure.DbContexts;
using Onyx.Products.Infrastructure.Entities;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
	{
		private readonly ProductsDbContext _dbContext;

		public ProductsRepository(ProductsDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(ProductsDbContext));
		}

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByColourAsync(ColourEnum colour)
        {
            return await _dbContext.Products.Where(p => p.Colour == colour).ToListAsync();
        }
    }
}

