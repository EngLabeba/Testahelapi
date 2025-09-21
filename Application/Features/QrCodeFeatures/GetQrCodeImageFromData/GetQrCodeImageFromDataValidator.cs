using FluentValidation;

namespace Application.Features.QrCodeFeatures.GetQrCodeImageFromData;

public sealed class GetQrCodeImageFromDataValidator : AbstractValidator<GetQrCodeImageFromDataRequest>
{
    public GetQrCodeImageFromDataValidator()
    {
        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage("Data cannot be empty")
            .WithErrorCode("invalid-Data");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .LessThanOrEqualTo(1000)
            .WithMessage("Size must be between 1 and 1000")
            .WithErrorCode("invalid-Size");
    }
}
