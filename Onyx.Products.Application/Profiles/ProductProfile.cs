using AutoMapper;

namespace Onyx.Products.Application.Profiles
{
    public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Infrastructure.Entities.Product, Domain.Models.Product>().ReverseMap();
		}
	}
}

