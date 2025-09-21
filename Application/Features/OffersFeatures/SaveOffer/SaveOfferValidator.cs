using FluentValidation;

namespace Application.Features.OffersFeatures.SaveOffer;

public sealed class SaveOfferValidator : AbstractValidator<SaveOfferRequest>
{
    public SaveOfferValidator()
    {
        RuleFor(x => x.OfferId)
            .GreaterThan(0)
            .WithMessage("OfferId must be greater than 0")
            .WithErrorCode("invalid-OfferId");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required")
            .WithErrorCode("invalid-UserId");

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage("Notes cannot exceed 500 characters")
            .WithErrorCode("invalid-Notes");
    }
}
