using FluentValidation;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;


public class UpdatePharmacyBranchAddressCommandValidator : AbstractValidator<UpdatePharmacyBranchAddressCommandRequest>
{
    public UpdatePharmacyBranchAddressCommandValidator()
    {
        RuleFor(p => p.Id)
          .NotEmpty().WithMessage("Pharmacy Id is required.")
          .NotNull().WithMessage("Pharmacy Id is required.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Pharmacy Status is required.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .MaximumLength(250)
            .WithMessage("Address cannot exceed 250 characters.");

        RuleFor(x => x.ProvinceId)
            .NotNull()
            .WithMessage("ProvinceId is required.");

        RuleFor(x => x.DistrictId)
            .NotNull()
            .WithMessage("DistrictId is required.");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .When(x => x.Latitude.HasValue)
            .WithMessage("Latitude must be between -90 and 90.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .When(x => x.Longitude.HasValue)
            .WithMessage("Longitude must be between -180 and 180.");
    }
}
