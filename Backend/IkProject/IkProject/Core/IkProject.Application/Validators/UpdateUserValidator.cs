using FluentValidation;
using IkProject.Domain.Identities;

namespace IkProject.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<AppUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone Number must be a valid phone number.");

            RuleFor(user => user.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 200).WithMessage("Address must be between 5 and 200 characters.");

            RuleFor(user => user.ImgPath)
                .NotEmpty().WithMessage("Image Path is required.")
                .Matches(@"\.(jpg|jpeg|png|gif)$").WithMessage("Image Path must be a valid image file path.");

        }
    }
}
