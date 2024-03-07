using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities;

public sealed class Vehicle : Entity
{
    public string Brand { get; set; } = string.Empty;
    public string Model {  get; set; } = string.Empty;
    public string Plate {  get; set; } = string.Empty;
    public int Year { get; set; }
    public int KM { get; set; }
    public ColorEnum Color { get; set; } = ColorEnum.Red;
}

