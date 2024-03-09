using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Vehicles.Queries.GetAllVehicles;
public sealed record GetAllVehicleQueryResponse(
    Guid Id,
    string Brand,
    string Model,
    string Plate,
    int Year,
    int KM,
    ColorEnum Color);
