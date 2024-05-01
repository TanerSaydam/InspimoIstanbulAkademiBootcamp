using AutoMapper;
using ChatAppServer.WebAPI.Dtos;
using ChatAppServer.WebAPI.Models;

namespace ChatAppServer.WebAPI.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, User>();
    }
}
