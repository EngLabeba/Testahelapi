using AutoMapper;
using Domain.Entities;

namespace Application.Features.OffersFeatures.GenerateOfferQrCode;

public sealed class GenerateOfferQrCodeMapper : Profile
{
    public GenerateOfferQrCodeMapper()
    {
        CreateMap<GenerateOfferQrCodeRequest, Offer>();
        CreateMap<Offer, GenerateOfferQrCodeResponse>()
            .ForMember(dest => dest.QrCodeBase64, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.QrCodeData, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.Success, opt => opt.Ignore()) // Will be set manually in handler
            .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore()); // Will be set manually in handler
    }
}
