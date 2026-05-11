using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class DetalleOrdenProfile : Profile
{
    public DetalleOrdenProfile()
    {
        CreateMap<Orderdetail, DetalleOrdenReadDTO>();

        CreateMap<DetalleOrdenCreateDTO, Orderdetail>();

        CreateMap<DetalleOrdenUpdateDTO, Orderdetail>();
    }
}