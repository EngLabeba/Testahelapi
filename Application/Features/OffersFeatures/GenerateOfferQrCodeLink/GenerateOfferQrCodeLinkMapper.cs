using AutoMapper;
using Domain.Entities;

namespace Application.Features.OffersFeatures.GenerateOfferQrCodeLink;

public sealed class GenerateOfferQrCodeLinkMapper : Profile
{
    public GenerateOfferQrCodeLinkMapper()
    {
        CreateMap<GenerateOfferQrCodeLinkRequest, Offer>();
        CreateMap<Offer, GenerateOfferQrCodeLinkResponse>()
            .ForMember(dest => dest.QrCodeData, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.QrCodeLink, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.QrCodeFormat, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.Success, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.CategoryName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.DiscountTypeName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.EmployeeName, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.EmployeeNameEnglish, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.IsCurrentlyValid, opt => opt.Ignore()); // Will be calculated in handler
    }
}
