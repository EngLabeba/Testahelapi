using FluentValidation;

namespace Application.Features.DeviceFeatures.GetPaginated;

public sealed class GetPaginatedOfferValidator : AbstractValidator<GetPaginatedOfferRequest>
{
    public GetPaginatedOfferValidator()
	{
		RuleFor(x => x.PaginationInput).NotEmpty().WithErrorCode("not_null-PaginationInput");
	}
}