using AutoMapper;
using PersonelServer.DTOs;
using PersonelServer.Models;

namespace PersonelServer.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePersonelDto, Personel>()
            .ForMember(prp => prp.FirstName, opt => opt.MapFrom(src => src.FirstName.Trim()))
            .ForMember(prp => prp.LastName, opt => opt.MapFrom(src => src.LastName.Trim()))
            .ForMember(prp => prp.Email, opt => opt.MapFrom(src => src.Email.ToLower().Trim()))
            .ForMember(prp => prp.FullAddress, opt => opt.MapFrom(src => src.FullAddress.Trim()));

        CreateMap<Personel, GetAllPersonelDto>()            
            .ForMember(dest => dest.ProfessionName, opt => opt.MapFrom(src => src.Profession!.Name));
    }
}
