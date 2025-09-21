using FluentValidation;

namespace Application.Features.OffersFeatures.GetSavedOffers;

public sealed class GetSavedOffersValidator : AbstractValidator<GetSavedOffersRequest>
{
    public GetSavedOffersValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required")
            .WithErrorCode("invalid-UserId");
    }
}
