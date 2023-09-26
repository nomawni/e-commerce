using AutoMapper;
using Products.Dtos;
using Products.Models;

namespace Products.Profiles;

public class ProductsProfile : Profile
{

    public ProductsProfile()
    {

        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}