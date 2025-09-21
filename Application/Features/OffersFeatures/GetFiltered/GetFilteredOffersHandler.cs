using Application.Common.Exceptions;
using Application.Common.Models;
using Application.Common.Repositories;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Reflection;

namespace Application.Features.OffersFeatures.GetFiltered;

public sealed class GetFilteredOffersHandler : IRequestHandler<GetFilteredOffersRequest, PaginatedList<GetFilteredOffersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _OfferRepository;
    private readonly IMapper _mapper;

    public GetFilteredOffersHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository OfferRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _OfferRepository = OfferRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetFilteredOffersResponse>> Handle(GetFilteredOffersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Offers = await _OfferRepository.GetFilteredOffersAsync(
                request.PaginationInput, 
                request.CategoryId, 
                request.UserId, 
                request.UserLatitude, 
                request.UserLongitude, 
                request.FilterType,
                cancellationToken);
            
            await _unitOfWork.Save(cancellationToken);
            
            // Map offers to response with additional calculations
            var responseItems = new List<GetFilteredOffersResponse>();
            
            foreach (var offer in Offers.Items)
            {
                var response = _mapper.Map<GetFilteredOffersResponse>(offer);
                
                // Set additional properties
                response.CategoryId = offer.CategoryId;
                response.DiscountValue = offer.DiscountValue;
                response.DirectionsUrl = offer.DirectionsUrl;
                
                // Get location coordinates (use first location if multiple)
                var location = offer.Locations?.FirstOrDefault();
                if (location != null)
                {
                    response.Latitude = location.Latitude;
                    response.Longitude = location.Longitude;
                    
                    // Calculate distance if user location is provided and valid (not 0,0)
                    if (request.UserLatitude.HasValue && request.UserLongitude.HasValue && 
                        location.Latitude.HasValue && location.Longitude.HasValue &&
                        !(request.UserLatitude.Value == 0 && request.UserLongitude.Value == 0))
                    {
                        response.DistanceInKm = Application.Common.Utilities.DistanceCalculator.CalculateDistance(
                            request.UserLatitude.Value, 
                            request.UserLongitude.Value,
                            location.Latitude.Value, 
                            location.Longitude.Value);
                    }
                }
                
                // Check if offer is saved by user
                if (!string.IsNullOrEmpty(request.UserId))
                {
                    response.IsSaved = await _OfferRepository.ExistsAsync(o => 
                        o.Id == offer.Id && 
                        o.SavedOffers.Any(s => s.UserId == request.UserId));
                }
                
                responseItems.Add(response);
            }
            
            // For NearestLocation filter, sort by distance after calculating distances
            if (request.FilterType == OfferFilterType.NearestLocation && 
                request.UserLatitude.HasValue && request.UserLongitude.HasValue &&
                !(request.UserLatitude.Value == 0 && request.UserLongitude.Value == 0))
            {
                responseItems = responseItems
                    .Where(r => r.DistanceInKm.HasValue)
                    .OrderBy(r => r.DistanceInKm.Value)
                    .ToList();
            }
            
            return new PaginatedList<GetFilteredOffersResponse>(
                responseItems, 
                Offers.TotalCount, 
                Offers.PageNumber, 
                request.PaginationInput.TakenRows);
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_filtered", nameof(Offer));
        }
    }
}
