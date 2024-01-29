using AutoMapper;
using Onyx.Products.Domain.Models;
using Onyx.Products.Infrastructure.Repositories;
using Onyx.Products.Shared.Enums;

namespace Onyx.Products.Application.Services
{
    public class ProductsService : IProductsService
	{
        private readonly IMapper _mapper;
		private readonly IProductsRepository _productsRepository;

        public ProductsService(
            IMapper mapper,
            IProductsRepository productsRepository)
		{
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
		}

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productsRepository.GetAllAsync();
            return MapProducts(products);
        }

        public async Task<IEnumerable<Product>> GetProductsByColour(ColourEnum colour)
        {
            var products = await _productsRepository.GetByColourAsync(colour);
            return MapProducts(products);
        }

        private IEnumerable<Product> MapProducts(IEnumerable<Infrastructure.Entities.Product> products)
        {
            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}

