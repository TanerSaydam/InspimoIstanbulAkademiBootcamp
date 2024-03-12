using AutoMapper;
using eBiletServer.Application.Extensions;
using eBiletServer.Application.Features.Auth.Register;
using eBiletServer.Domain.Entities;

namespace eBiletServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>()
            .ForMember(member => member.UserName, options =>
            {
                options.MapFrom(map => map.UserName.ReplaceAllTurkishLettersAndDeleteEmptySpace());
            })
            .ForMember(member => member.Email, options =>
            {
                options.MapFrom(map => map.Email.ReplaceAllTurkishLettersAndDeleteEmptySpace());
            })
            ;
    }
}
