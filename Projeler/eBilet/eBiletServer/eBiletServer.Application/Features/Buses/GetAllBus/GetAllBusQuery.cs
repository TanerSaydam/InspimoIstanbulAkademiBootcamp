using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Utilities;
using MediatR;

namespace eBiletServer.Application.Features.Buses.GetAllBus;
public sealed record GetAllBusQuery() : IRequest<Result<List<Bus>>>;
