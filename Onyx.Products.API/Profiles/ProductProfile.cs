using AutoMapper;

namespace Onyx.Products.API.Profiles
{
    public class ProductAPIProfile : Profile
    {
        public ProductAPIProfile()
        {
            CreateMap<Domain.Models.Product, Shared.Models.Product>();
        }
    }
}

