using AutoMapper;
using LAB08_MauricioCalderón.DTO_s.Operations.Create;
using LAB08_MauricioCalderón.DTO_s.Operations.Read;
using LAB08_MauricioCalderón.Models;

namespace LAB08_MauricioCalderón.DTO_s.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Client, ClienteReadDTO>();

        CreateMap<ClienteCreateDTO, Client>();

        CreateMap<ClienteUpdateDTO, Client>();
    }
}