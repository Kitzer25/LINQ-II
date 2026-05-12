using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class ProductQuantityProfile : Profile
{
    public ProductQuantityProfile()
    {
        CreateMap<Orderdetail, ProductQuantityReadDTO>()
            .ForMember(dest => dest.Product,
                opt => opt.MapFrom(src => src.Product.Name));
    }
}