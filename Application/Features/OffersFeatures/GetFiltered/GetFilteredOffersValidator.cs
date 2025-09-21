using FluentValidation;

namespace Application.Features.OffersFeatures.GetFiltered;

public sealed class GetFilteredOffersValidator : AbstractValidator<GetFilteredOffersRequest>
{
    public GetFilteredOffersValidator()
    {
        RuleFor(x => x.PaginationInput).NotEmpty().WithErrorCode("not_null-PaginationInput");
        
        RuleFor(x => x.FilterType)
            .IsInEnum()
            .WithMessage("FilterType must be a valid value (0=NoFilter, 1=NearestLocation, 2=LastInserted, 3=MaxUsed, 4=HigherEvaluation)")
            .WithErrorCode("invalid-FilterType");
            
        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .When(x => x.CategoryId.HasValue)
            .WithMessage("CategoryId must be greater than 0 when provided")
            .WithErrorCode("invalid-CategoryId");
            
        RuleFor(x => x.UserLatitude)
            .InclusiveBetween(-90, 90)
            .When(x => x.UserLatitude.HasValue)
            .WithMessage("UserLatitude must be between -90 and 90 degrees")
            .WithErrorCode("invalid-UserLatitude");
            
        RuleFor(x => x.UserLongitude)
            .InclusiveBetween(-180, 180)
            .When(x => x.UserLongitude.HasValue)
            .WithMessage("UserLongitude must be between -180 and 180 degrees")
            .WithErrorCode("invalid-UserLongitude");
    }
}
