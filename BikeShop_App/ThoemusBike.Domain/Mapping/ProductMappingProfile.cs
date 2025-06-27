using AutoMapper;
using ThoemusBike.Core;
using ThoemusBike.Data.Entities;

namespace ThoemusBike.Domain.Mapping;
public class ProductMappingProfile : Profile
{
	public ProductMappingProfile()
	{
        CreateMap<Product, ProductModel>()           
            .ReverseMap();

        CreateMap<NewProductModel, Product>();
    }
}
