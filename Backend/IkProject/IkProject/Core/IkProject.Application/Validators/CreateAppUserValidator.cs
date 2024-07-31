using FluentValidation;
using FluentValidation.Validators;
using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Validators
{
    public class CreateAppUserValidator : AbstractValidator<AppUser>
    {
        public CreateAppUserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(user => user.SecondName)
                .Length(0, 50).WithMessage("Second Name must be up to 50 characters.");

            RuleFor(user => user.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters.");

            RuleFor(user => user.SecondSurname)
                .Length(0, 50).WithMessage("Second Surname must be up to 50 characters.");

            RuleFor(user => user.BirthDate)
                .NotEmpty().WithMessage("Birthdate is required.")
                .LessThan(DateTime.Now).WithMessage("Birthdate must be in the past.");

            RuleFor(user => user.PlaceOfBirth)
                .NotEmpty().WithMessage("Place of Birth is required.")
                .Length(2, 100).WithMessage("Place of Birth must be between 2 and 100 characters.");

            RuleFor(user => user.IdentityNo)
                .NotEmpty().WithMessage("Identity Number is required.")
                .Length(11).WithMessage("Identity Number must be 11 characters.")
                .Must(ValidIdentityNo).WithMessage("Invalid identity number.");

            bool ValidIdentityNo(string tcKimlikNo)
            {
                if (tcKimlikNo.Length != 11 || !long.TryParse(tcKimlikNo, out _))
                {
                    return false;
                }

                int[] digits = tcKimlikNo.Select(d => int.Parse(d.ToString())).ToArray();

                if (digits[0] == 0)
                {
                    return false;
                }

                int sumOfOdd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
                int sumOfEven = digits[1] + digits[3] + digits[5] + digits[7];

                int digit10 = ((sumOfOdd * 7) - sumOfEven) % 10;
                if (digit10 != digits[9])
                {
                    return false;
                }

                int sumOfFirst10 = digits.Take(10).Sum();
                int digit11 = sumOfFirst10 % 10;
                if (digit11 != digits[10])
                {
                    return false;
                }

                return true;
            }



            RuleFor(user => user.Job)
                .NotEmpty().WithMessage("Job is required.")
                .Length(2, 100).WithMessage("Job must be between 2 and 100 characters.");

            RuleFor(user => user.Department)
                .NotEmpty().WithMessage("Department is required.")
                .Length(2, 100).WithMessage("Department must be between 2 and 100 characters.");

            RuleFor(user => user.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 200).WithMessage("Address must be between 5 and 200 characters.");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone Number must be a valid phone number.");

            RuleFor(user => user.Wage)
                .GreaterThan(0).WithMessage("Wage must be greater than 0.");

            RuleFor(user => user.ImgPath)
                .NotEmpty().WithMessage("Image Path is required.")
                .Matches(@"\.(jpg|jpeg|png|gif)$").WithMessage("Image Path must be a valid image file path.");

            RuleFor(user => user.Token)
                .Length(0, 100).WithMessage("Token must be up to 100 characters.");

        }
    }
}
