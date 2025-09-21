using FluentValidation;

namespace Application.Features.OffersFeatures.GetDetails;

public sealed class GetOfferDetailsValidator : AbstractValidator<GetOfferDetailsRequest>
{
    public GetOfferDetailsValidator()
    {
        RuleFor(x => x.OfferId)
            .GreaterThan(0)
            .WithMessage("OfferId must be greater than 0")
            .WithErrorCode("invalid-OfferId");
    }
}
