using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.DeviceFeatures.GetPaginated;

public sealed record GetPaginatedOfferRequest(
    PaginationInput PaginationInput,
    int? CategoryId = null,
    string? UserId = null,
    double? UserLatitude = null,
    double? UserLongitude = null) : IRequest<PaginatedList<GetPaginatedOfferResponse>>;