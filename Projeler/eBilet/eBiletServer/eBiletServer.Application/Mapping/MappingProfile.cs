using AutoMapper;
using eBiletServer.Application.Extensions;
using eBiletServer.Application.Features.Auth.Register;
using eBiletServer.Application.Features.Buses.CreateBus;
using eBiletServer.Application.Features.Buses.UpdateBus;
using eBiletServer.Application.Features.Routes.CreateRoute;
using eBiletServer.Application.Features.Routes.UpdateRoute;
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

        CreateMap<CreateBusCommand, Bus>();
        CreateMap<UpdateBusCommand, Bus>();

        CreateMap<CreateRouteCommand, Route>()
            .ForMember(member => member.Date, options =>
            {
                options.MapFrom(map => DateTime.SpecifyKind(Convert.ToDateTime(map.Date), DateTimeKind.Utc));
            });

        CreateMap<UpdateRouteCommand, Route>()
            .ForMember(member => member.Date, options =>
            {
                options.MapFrom(map => DateTime.SpecifyKind(Convert.ToDateTime(map.Date), DateTimeKind.Utc));
            });
    }
}
