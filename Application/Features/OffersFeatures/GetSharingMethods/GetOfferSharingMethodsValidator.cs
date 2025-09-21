using FluentValidation;

namespace Application.Features.OffersFeatures.GetSharingMethods;

public sealed class GetOfferSharingMethodsValidator : AbstractValidator<GetOfferSharingMethodsRequest>
{
    public GetOfferSharingMethodsValidator()
    {
        RuleFor(x => x.OfferId)
            .GreaterThan(0)
            .WithMessage("OfferId must be greater than 0")
            .WithErrorCode("invalid-OfferId");
    }
}
