using FluentValidation;

namespace Application.Features.QrCodeFeatures.GenerateOfferShareQrCode;

public sealed class GenerateOfferShareQrCodeValidator : AbstractValidator<GenerateOfferShareQrCodeRequest>
{
    public GenerateOfferShareQrCodeValidator()
    {
        RuleFor(x => x.OfferShareId)
            .GreaterThan(0)
            .WithMessage("OfferShareId must be greater than 0")
            .WithErrorCode("invalid-OfferShareId");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000)
            .WithMessage("Size must be between 1 and 1000")
            .WithErrorCode("invalid-Size");
    }
}
