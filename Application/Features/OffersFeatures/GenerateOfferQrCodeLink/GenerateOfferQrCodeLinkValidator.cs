using FluentValidation;

namespace Application.Features.OffersFeatures.GenerateOfferQrCodeLink;

public sealed class GenerateOfferQrCodeLinkValidator : AbstractValidator<GenerateOfferQrCodeLinkRequest>
{
    public GenerateOfferQrCodeLinkValidator()
    {
        RuleFor(x => x.OfferId)
            .GreaterThan(0)
            .WithMessage("OfferId must be greater than 0")
            .WithErrorCode("invalid-OfferId");

        RuleFor(x => x.QrCodeFormat)
            .Must(BeValidFormat)
            .WithMessage("QrCodeFormat must be one of: qr-offer, qr-share, qr-custom")
            .WithErrorCode("invalid-QrCodeFormat");
    }

    private bool BeValidFormat(string? format)
    {
        if (string.IsNullOrEmpty(format)) return true; // Optional field
        
        var validFormats = new[] { "qr-offer", "qr-share", "qr-custom" };
        return validFormats.Contains(format.ToLower());
    }
}
