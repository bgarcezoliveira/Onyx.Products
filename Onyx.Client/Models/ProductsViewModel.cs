using Onyx.Products.Shared.Models;

namespace Onyx.Client.Models
{
    public class ProductsViewModel
	{
		public readonly string IdentityInformation;

        public ProductsViewModel(string identityInformation)
		{
            IdentityInformation = identityInformation;
		}
	}
}

