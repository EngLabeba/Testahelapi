using FluentValidation;

namespace Application.Features.DependentsFeatures.GetAll;

public sealed class GetAllDependentsValidator : AbstractValidator<GetAllDependentsRequest>
{
    public GetAllDependentsValidator()
    {
        // No validation rules needed since request has no parameters
        // This validator exists for consistency with the pattern
    }
}
