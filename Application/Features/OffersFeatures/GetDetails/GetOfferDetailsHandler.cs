using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OffersFeatures.GetDetails;

public sealed class GetOfferDetailsHandler : IRequestHandler<GetOfferDetailsRequest, GetOfferDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;
    private readonly IMapper _mapper;

    public GetOfferDetailsHandler(
        IUnitOfWork unitOfWork,
        IOfferRepository offerRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
        _mapper = mapper;
    }

    public async Task<GetOfferDetailsResponse> Handle(GetOfferDetailsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Get offer with all related data
            var offer = await _offerRepository.GetOfferDetailsAsync(request.OfferId, cancellationToken);
            
            if (offer == null)
            {
                throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
            }

            await _unitOfWork.Save(cancellationToken);

            // Map offer to response
            var response = _mapper.Map<GetOfferDetailsResponse>(offer);

            // Set additional calculated properties
            response.IsCurrentlyValid = DateTime.UtcNow >= offer.ValidFrom && DateTime.UtcNow <= offer.ValidUntil;
            
            // Set category information
            if (offer.Category != null)
            {
                response.CategoryName = offer.Category.Name;
               
            }

            // Set discount type information
            if (offer.DiscountType != null)
            {
                response.DiscountTypeName = offer.DiscountType.Name;
            }

            // Set employee information
            if (offer.Employee != null)
            {
                response.EmployeeId = offer.Employee.Id;
                response.EmployeeName = offer.Employee.Name;
                response.EmployeeNameEnglish = offer.Employee.NameEnglish;
            }

            // Map locations (no distance calculation since user location is not provided)
            response.Locations = new List<OfferLocationDetails>();
            foreach (var location in offer.Locations)
            {
                var locationDetails = new OfferLocationDetails
                {
                    Id = location.Id,
                    Name = location.Name,
                    NameEnglish = location.Name,
                    Address = location.Address,
                    AddressEnglish = location.Address,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    DirectionsUrl = offer.DirectionsUrl
                };

                // No distance calculation since user location is not provided
                locationDetails.DistanceInKm = null;

                response.Locations.Add(locationDetails);
            }

            // Map platforms
            response.Platforms = offer.Platforms.Select(p => new OfferPlatformDetails
            {
                Id = p.Id,
                Name = p.Name,
                NameEnglish = p.Name,
                IconUrl = p.Icon
            }).ToList();

            // Map sharing methods
            response.SharingMethods = offer.SharingMethods.Select(sm => new OfferSharingMethodDetails
            {
                Id = sm.Id,
                Name = sm.Name,
                NameEnglish = sm.Name,
                IconUrl = sm.Icon,
            }).ToList();

            // No user-specific information since UserId is not provided
            response.IsSaved = false;
            response.DistanceInKm = null;

            return response;
        }
        catch (BusinessException)
        {
            throw new BusinessException(new Exception("Offer not found or inactive"), "offer_not_found", nameof(Offer));
        }
        catch (Exception exception)
        {
            throw new BusinessException(exception, "general_get_offer_details", nameof(Offer));
        }
    }
}
