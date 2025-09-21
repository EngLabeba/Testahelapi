using FluentValidation;

namespace Application.Features.OffersFeatures.GenerateOfferQrCode;

public sealed class GenerateOfferQrCodeValidator : AbstractValidator<GenerateOfferQrCodeRequest>
{
    public GenerateOfferQrCodeValidator()
    {
        RuleFor(x => x.OfferId)
            .GreaterThan(0)
            .WithMessage("OfferId must be greater than 0")
            .WithErrorCode("invalid-OfferId");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000)
            .WithMessage("Size must be between 1 and 1000")
            .WithErrorCode("invalid-Size");
    }
}
