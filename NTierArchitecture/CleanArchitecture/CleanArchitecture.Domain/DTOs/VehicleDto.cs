using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.DTOs;
public sealed record VehicleDto(
    string Brand,
    string Model,
    string Plate,
    int Year,
    int KM,
    ColorEnum Color);
