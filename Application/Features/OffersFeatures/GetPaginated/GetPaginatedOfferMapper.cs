using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.DeviceFeatures.GetPaginated;

public sealed class GetPaginatedOfferMapper : Profile
{
    public GetPaginatedOfferMapper()
    {
        CreateMap<GetPaginatedOfferRequest, Offer>();
        CreateMap<Offer, GetPaginatedOfferResponse>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.DiscountValue, opt => opt.MapFrom(src => src.DiscountValue))
            .ForMember(dest => dest.DirectionsUrl, opt => opt.MapFrom(src => src.DirectionsUrl))
            .ForMember(dest => dest.Latitude, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.Longitude, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.DistanceInKm, opt => opt.Ignore()) // Will be calculated in handler
            .ForMember(dest => dest.IsSaved, opt => opt.Ignore()); // Will be set manually in handler
        CreateMap<PaginatedList<Offer>, PaginatedList<GetPaginatedOfferResponse>>();
    }
}