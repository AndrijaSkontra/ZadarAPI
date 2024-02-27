using AutoMapper;
using ZadarAPI.Dto.Kvart;
using ZadarAPI.Dto.Street;
using ZadarAPI.Models;

namespace ZadarAPI.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Kvart, CreateKvartDto>().ReverseMap();
        CreateMap<Kvart, GetKvartDto>().ReverseMap();
        CreateMap<Kvart, UpdateKvartDto>().ReverseMap();
        CreateMap<Kvart, KvartDto>().ReverseMap();
        CreateMap<Street, CreateStreetDto>().ReverseMap();
        CreateMap<Street, GetStreetDto>().ReverseMap();
        CreateMap<Street, UpdateStreetDto>().ReverseMap();
        CreateMap<Street, StreetDto>().ReverseMap();
    }
}