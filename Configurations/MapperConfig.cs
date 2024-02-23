using AutoMapper;
using ZadarAPI.Dto.Kvart;
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
    }
}