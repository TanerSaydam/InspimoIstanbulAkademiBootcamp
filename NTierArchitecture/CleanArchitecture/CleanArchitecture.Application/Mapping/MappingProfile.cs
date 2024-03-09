using AutoMapper;
using CleanArchitecture.Application.Features.Vehicles.Commands.CreateVehicle;
using CleanArchitecture.Application.Features.Vehicles.Commands.UpdateVehicle;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<UpdateVehicleCommand, Vehicle>();
    }
}
