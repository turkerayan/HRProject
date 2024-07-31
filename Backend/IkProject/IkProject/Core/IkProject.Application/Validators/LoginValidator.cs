using FluentValidation;
using IkProject.Application.Features.Command;
using IkProject.Application.Features.Quaries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginQueryRequest>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Email)
                .NotEmpty().WithMessage("Email Adresi bos Birakilamaz")
                .EmailAddress().WithMessage("Gecerli bir email deildir");
                //.Must(e => e.EndsWith("@bilgeadamboost.com") || e.EndsWith("@bilgeadam.com")).WithMessage("Email Adresi @bilgeadamboost.com veya @bilgeadam.com ile bitmelidir");

            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("Sifre Bos Birakilamaz")
                .MinimumLength(8).WithMessage("Sifre en az 8 karakter olmalıdır")
                .Matches(@"[A-Z]").WithMessage("Sifre en az bir büyük harf içermelidir")
                .Matches(@"[a-z]").WithMessage("Sifre en az bir küçük harf içermelidir")
                .Matches(@"[0-9]").WithMessage("Sifre en az bir rakam içermelidir")
                .Matches(@"[^\w\d]").WithMessage("Sifre en az bir özel karakter içermelidir")
                .Must(ContainAtLeastThreeDigits).WithMessage("Sifre en az üç rakam içermelidir");
        }

        private bool ContainAtLeastThreeDigits(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            int digitCount = password.Count(char.IsDigit);
            return digitCount >= 3;
        }


    }
}
