using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class OrdenProfile : Profile
{
    public OrdenProfile()
    {
        CreateMap<Order, OrdenReadDTO>()
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => src.Orderdetails));
        CreateMap<OrdenCreateDTO, Order>();
        CreateMap<OrdenUpdateDTO, Order>();
        CreateMap<Order, ClientWithOrdersDTO>()
            .ForMember(dest => dest.Products,
                opt => opt.MapFrom(src => src.Orderdetails.Select(d => d.Product)));
    }
}