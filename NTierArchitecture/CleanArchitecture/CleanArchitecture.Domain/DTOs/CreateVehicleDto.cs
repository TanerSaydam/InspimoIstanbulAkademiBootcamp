using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.DTOs;
public sealed record CreateVehicleDto(
    string Brand,
    string Model,
    int Year,
    int KM,
    ColorEnum Color);
