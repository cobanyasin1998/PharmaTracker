﻿using FluentValidation;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyCommandRequest>
{
    public UpdatePharmacyCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Pharmacy Id is required.")
            .NotNull().WithMessage("Pharmacy Id is required.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Pharmacy Status is required.");


        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Pharmacy Name is required.")
            .NotNull().WithMessage("Pharmacy Name is required.")
            .MinimumLength(3).WithMessage("Pharmacy Name must not be less than 3 characters.")
            .MaximumLength(100).WithMessage("Pharmacy Name must not exceed 100 characters.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Pharmacy Description is required.")
            .NotNull().WithMessage("Pharmacy Description is required.")
            .MinimumLength(3).WithMessage("Pharmacy Description must not be less than 3 characters.")
            .MaximumLength(100).WithMessage("Pharmacy Description must not exceed 100 characters.");

        RuleFor(p => p.LicenseNumber)
            .NotEmpty().WithMessage("Pharmacy License Number is required.")
            .NotNull().WithMessage("Pharmacy License Number is required.")
            .MinimumLength(3).WithMessage("Pharmacy License Number must not be less than 3 characters.")
            .MaximumLength(100).WithMessage("Pharmacy License Number must not exceed 100 characters.");
    }
}
