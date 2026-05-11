using AutoMapper;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class ProductQuantityReadDTO : Profile
{
    public ProductQuantityReadDTO()
    {
        CreateMap<Orderdetail, ProductQuantityReadDTO>();
    }
}