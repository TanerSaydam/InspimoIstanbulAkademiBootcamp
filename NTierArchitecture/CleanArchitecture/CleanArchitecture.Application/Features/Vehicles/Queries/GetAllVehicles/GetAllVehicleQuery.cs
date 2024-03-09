using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Features.Vehicles.Queries.GetAllVehicles;
public sealed record GetAllVehicleQuery() : IRequest<Result<List<GetAllVehicleQueryResponse>>>;