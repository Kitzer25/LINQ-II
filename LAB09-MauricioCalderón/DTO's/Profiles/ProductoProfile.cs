using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class ProductoProfile : Profile
{
    public ProductoProfile()
    {
        CreateMap<Product, ProductoReadDTO>();

        CreateMap<ProductoCreateDTO, Product>();

        CreateMap<ProductoUpdateDTO, Product>();
    }
}