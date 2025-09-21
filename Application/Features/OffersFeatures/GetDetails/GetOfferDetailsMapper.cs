using AutoMapper;
using Domain.Entities;

namespace Application.Features.OffersFeatures.GetDetails;

public sealed class GetOfferDetailsMapper : Profile
{
    public GetOfferDetailsMapper()
    {
        CreateMap<GetOfferDetailsRequest, Offer>();
        CreateMap<Offer, GetOfferDetailsResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.DiscountTypeName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.EmployeeName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.EmployeeNameEnglish, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.IsCurrentlyValid, opt => opt.Ignore()) // Will be calculated in handler
            .ForMember(dest => dest.Locations, opt => opt.Ignore()) // Will be mapped manually in handler
            .ForMember(dest => dest.Platforms, opt => opt.Ignore()) // Will be mapped manually in handler
            .ForMember(dest => dest.SharingMethods, opt => opt.Ignore()) // Will be mapped manually in handler
            .ForMember(dest => dest.IsSaved, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.DistanceInKm, opt => opt.Ignore()); // Will be calculated in handler

        // Map related entities
        CreateMap<OfferLocation, OfferLocationDetails>()
            .ForMember(dest => dest.DistanceInKm, opt => opt.Ignore()); // Will be calculated in handler

        CreateMap<OfferPlatform, OfferPlatformDetails>();
        CreateMap<OfferSharingMethod, OfferSharingMethodDetails>();
    }
}
