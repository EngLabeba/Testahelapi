using FluentValidation;

namespace Application.Features.CategoryFeatures.GetAll;

public sealed class GetAllCategoriesValidator : AbstractValidator<GetAllCategoriesRequest>
{
    public GetAllCategoriesValidator()
    {
        // No validation needed for getting all categories
    }
}
